using DocumentFormat.OpenXml.Packaging;
using System.Reflection;
using Microsoft.Extensions.Options;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using TopBorder = DocumentFormat.OpenXml.Wordprocessing.TopBorder;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using BottomBorder = DocumentFormat.OpenXml.Wordprocessing.BottomBorder;
using LeftBorder = DocumentFormat.OpenXml.Wordprocessing.LeftBorder;
using RightBorder = DocumentFormat.OpenXml.Wordprocessing.RightBorder;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using DocumentFormat.OpenXml;
using System.ComponentModel;
using System.IO;
using Application.Features.Files.Options;


namespace Application.Features.Documents.Services;

public class DocxService(IOptions<FilesOptions> options)
{
	private readonly FilesOptions _options = options.Value;

	public async Task<byte[]> FillTemplate<T>(T data)
	{
		var tempName = Guid.NewGuid().ToString();
		var assembly = Assembly.GetExecutingAssembly();
		byte[] result = null;


		await using (var stream = assembly.GetManifestResourceStream($"Application.Features.Documents.Templates.{typeof(T).Name.Replace("Model","")}Template.docx"))
		{
			using (var memoryStream = new MemoryStream())
			{
				stream.Seek(0, SeekOrigin.Begin);
				stream.CopyTo(memoryStream);

				using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
				{
					var document = FillDocument(doc, data);
					document.Save();
				}
				result = memoryStream.ToArray();
			}
		}

		return result;
	}


	private WordprocessingDocument FillDocument<T>(WordprocessingDocument document, T data)
	{
		document.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
		var properties = data.GetType().GetProperties();
		var body = document.MainDocumentPart.Document.Body;

		foreach (var text in body.Descendants<Text>())
		{
			var replacement = properties.FirstOrDefault(q => text.Text.Contains(q.Name));

			if (replacement == null)
			{
				continue;
			}

			var isCollection = typeof(IEnumerable).IsAssignableFrom(replacement.PropertyType) && replacement.PropertyType != typeof(String);

			if (isCollection)
			{
				var table = FillTable((IEnumerable<object>)replacement.GetValue(data));
				text.Parent.InsertAfter(table, text);
				text.Remove();
				continue;
			}
			
			text.Text = text.Text.Replace(replacement.Name, replacement.GetValue(data)?.ToString());

		}

		return document;
	}

	private Table FillTable<T>(IEnumerable<T> data)
	{
		var table = new Table();

		TableProperties tblProp = new TableProperties(
			new TableBorders
			(new TopBorder()
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Color = "000000",
				Size = 10,
				Space = 0
				
			},
			new BottomBorder()
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Color = "000000",
				Size = 10,
				Space = 0

			}, 
			new LeftBorder()
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Color = "000000",
				Size = 10,
				Space = 0

			}, 
			new RightBorder()
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Color = "000000",
				Size = 10,
				Space = 0
			}, 
			new InsideHorizontalBorder()
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Color = "000000",
				Size = 10,
				Space = 0
			},
			new InsideVerticalBorder()
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Color = "000000",
				Size = 10,
				Space = 0
			}
			));

		table.AppendChild(tblProp);

		var firstItem = data.FirstOrDefault();

		_ = firstItem ?? throw new Exception("Пустое значение таблицы");

		var properties = firstItem.GetType().GetProperties();

		var headRow = new TableRow();

		// Заполненение хедера таблицы
		foreach (var item in properties)
		{
			var displayName = (item.GetCustomAttributes(typeof(DisplayNameAttribute), true).FirstOrDefault() as DisplayNameAttribute)?.DisplayName ?? item.Name;
			var headCell1 = new TableCell(new Paragraph(new Run(new Text(displayName))));
			headRow.Append(headCell1);
		}

		table.Append(headRow);

		foreach (var item in data)
		{
			var row = new TableRow();
			foreach (var prop in properties)
			{
		
				var cell = new TableCell(new Paragraph(new Run(new Text(prop.GetValue(item).ToString()))));
				row.Append(cell);
			}
			table.Append(row);
		}
		
		return table;
	}
}