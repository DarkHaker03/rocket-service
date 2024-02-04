using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

using Columns = DocumentFormat.OpenXml.Spreadsheet.Columns;
using Application.Features.Files.Options;

namespace Application.Features.Documents.Services;

public class ExcelService(IOptions<FilesOptions> options)
{
	public ICollection<T> Read<T>(string filePath) where T : class
	{
		var entityList = new List<T>();

		using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
		{
			Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
			Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
			IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
			
			var properties = typeof(T).GetProperties();

			var headerRow = rows.FirstOrDefault(q => q.RowIndex!.Value == 1);

			var stringTable = doc.WorkbookPart.GetPartsOfType<SharedStringTablePart>()
							.FirstOrDefault();


			//Пропускаем хедер
			foreach (var row in rows.Where(r => r.RowIndex?.Value != 1))
			{
				var entity = (T)Activator.CreateInstance(typeof(T));

				foreach (var cell in row.Descendants<Cell>())
				{
					
					var column = GetColumnReference(cell.CellReference);
					var headerCell = GetCellByColumnReference(headerRow, column);

					var prop = properties.FirstOrDefault(p => (p.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute)?.DisplayName == GetStringCellValue(stringTable,headerCell.InnerText));
					
					if (prop == null || (prop.PropertyType.IsClass && prop.PropertyType != typeof(string)))
					{
						continue;
					}
					
					if (cell.DataType == null)
					{
						if(!TrySetDatePropFromString(cell.CellValue.Text, prop, ref entity))
						{
							if (prop.PropertyType.IsEnum)
							{
								SetEnumValue(cell.CellValue.Text, prop, ref entity);
							}
							else if (prop.PropertyType == typeof(string))
							{
								SetStringCellValue(cell.CellValue.Text, prop, ref entity);
							}
							else if (double.TryParse(cell.CellValue.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var parsedNumber))
							{
								SetNumberPropFromString(parsedNumber, prop, ref entity);
							}
							else
							{
								throw new Exception($"Неизвестный тип ячейки. {cell.CellReference}"); ;
							}
						}
					}
					else if (cell.DataType == CellValues.SharedString)
					{
						var value = GetStringCellValue(stringTable, cell.InnerText);
						
						if (prop.PropertyType == typeof(string))
						{
							SetStringCellValue(value, prop, ref entity);
						}
						else if (double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var parsedNumber))
                        {
							SetNumberPropFromString(parsedNumber, prop, ref entity);
						}
						else if (Guid.TryParse(value, out var parsedGuid))
						{
							SetGuidProp(parsedGuid, prop, ref entity);
						}
						else
						{
							SetStringCellValue(value, prop, ref entity);
						}  
					}
					else if (cell.DataType == CellValues.Boolean)
					{
						switch (cell.InnerText)
						{
							case "0": prop.SetValue(entity, false);  break;
							default: prop.SetValue(entity, true); break;
						}
					}
				}

				var nullProp = entity.GetType().GetProperties().FirstOrDefault(p => p.GetValue(entity) == null || p.GetValue(entity) == default);

				if (nullProp != null)
				{
					throw new Exception($"Поле не может быть пустым, {nullProp.Name}");
				}

				entityList.Add(entity);
			}

		}

		return entityList;
	}

	public byte[] Write<T>(IEnumerable<T> data)
	{
		using (var stream = new MemoryStream())
		{
			using (var package = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
			{

				var book = FillTable(package, data);
				book.Workbook.Save();
				package.Save();
			}

			return stream.ToArray();
		}

	}

	private Row GetHeaderRow(Type type)
	{
		var props = type.GetProperties();
		var headerRow = new Row() { RowIndex = 1 };
		
		for (var x = new ExcelColumnEnumerator(); x.Position < props.Length; x.MoveNext())
		{
			var prop = props[x.Position];

			var displayName = (prop.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute)?.DisplayName ?? type.Name;

			var headerCell = new Cell() { CellReference = $"{x.Current}1", CellValue = new CellValue(displayName), DataType = CellValues.String };

			headerRow.Append(headerCell);
		}

		return headerRow;
	}

	private Row FillRow<T>(T data, int rowIndex)
	{
		var type = typeof(T);

		var props = type.GetProperties();
		var row = new Row() { RowIndex = UInt32Value.FromUInt32((uint)rowIndex)} ;
		var enumerator = new ExcelColumnEnumerator();

		for (var x = enumerator; x.Position < props.Length; x.MoveNext())
		{
			var prop = props[x.Position];

			var value = prop.GetValue(data)?.ToString() ?? "";

			var cell = new Cell() { CellReference = $"{x.Current}{rowIndex}", CellValue = new CellValue(value), DataType = CellValues.String};

			row.Append(cell);
		}

		return row;
	}

	private WorkbookPart FillTable<T>(SpreadsheetDocument package, IEnumerable<T> data)
	{
		var dataType = typeof(T);
		var workbookpart = package.AddWorkbookPart();
		workbookpart.Workbook = new Workbook();
		var sheets = package.WorkbookPart.Workbook.AppendChild(new Sheets());
		var headerRow = GetHeaderRow(dataType);

		var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
		var sheetData = new SheetData();
		worksheetPart.Worksheet = new Worksheet(sheetData);

		var sheet = new Sheet()
		{
			Id = package.WorkbookPart.
				GetIdOfPart(worksheetPart),
			SheetId = 1,
			Name = (dataType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute)?.Name ?? dataType.Name
		};

	
		sheetData.Append(headerRow);

		var rowIndex = 1;
		foreach (var item in data)
		{
			rowIndex++;
			var row = FillRow(item,rowIndex);
			sheetData.Append(row);
		}
		sheets.Append(sheet);
		return workbookpart;
	}

	private void SetGuidProp<T>(Guid guid, PropertyInfo prop, ref T entity)
	{
		prop.SetValue(entity, guid);
	}

	private void SetNumberPropFromString<T>(double value, PropertyInfo prop, ref T? entity) where T : class
	{
		if (prop.PropertyType.Name == "Int64")
		{
			prop.SetValue(entity, (long)value);
		}
		else if (prop.PropertyType.Name == "Int32")
		{
			prop.SetValue(entity, (int)value);
		}
		else if (prop.PropertyType.Name == "UInt64")
		{
			prop.SetValue(entity, (ulong)value);
		}
		else
		{
			prop.SetValue(entity, value);
		}
		
	}

	private bool TrySetDatePropFromString<T>(string date, PropertyInfo propertyInfo, ref T entity)
	{
		if (double.TryParse(date, out var result))
		{
			try
			{
				propertyInfo.SetValue(entity, DateTime.FromOADate(result).ToUniversalTime());
			}
			catch (ArgumentException)
			{
				return false;
			}

			return true;
		}

		return false;
	}

	private string GetColumnReference(string cellReference)
	{
		return Regex.Replace(cellReference.ToUpper(), @"[\d]", string.Empty);
	}

	private Cell? GetCellByColumnReference(Row row, string columnReference)
	{
		return row.Descendants<Cell>().FirstOrDefault(c => GetColumnReference(c.CellReference!) == columnReference);
	}

	private void SetStringCellValue<T>(string value, PropertyInfo propertyInfo, ref T entity)
	{
		propertyInfo.SetValue (entity, value);
	}
	
	private string GetStringCellValue(SharedStringTablePart stringTable, string cellValue)
	{
		return stringTable.SharedStringTable
								.ElementAt(int.Parse(cellValue)).InnerText;
	}

	private void SetEnumValue<T>(string value, PropertyInfo propertyInfo, ref T entity)
	{
		propertyInfo.SetValue(entity,Enum.Parse(propertyInfo.PropertyType, value));
	}
}
