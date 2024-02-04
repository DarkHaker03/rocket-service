
using System.Collections;

namespace Application.Features.Documents.Services;

public class ExcelColumnEnumerator : IEnumerator<string>
{
	public int Position = 0;

	public string Current
	{
		get { return GetColumnName(Position); }
	}

	object IEnumerator.Current
	{
		get { return Current; }
	}

	public bool MoveNext()
	{
		Position++;
		return Position <= 16384;
	}

	public void Reset()
	{
		Position = 0;
	}

	public void Dispose()
	{
	}

	private string GetColumnName(int index)
	{
		int dividend = index + 1;
		string columnName = string.Empty;

		while (dividend > 0)
		{
			int modulo = (dividend - 1) % 26;
			columnName = Convert.ToChar(65 + modulo) + columnName;
			dividend = (int)((dividend - modulo) / 26);
		}

		return columnName;
	}
}