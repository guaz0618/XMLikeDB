using System.Xml.Linq;
using System.Xml.XPath;

/// <summary>
/// Represents a database.
/// </summary>
public class XDatabase : IDisposable
{
    private IXReader _reader;

    public XDatabase(IXReader reader)
    {   
        _reader = reader;
    }

    public void Dispose()
    {
        _reader.Dispose();
    }

    #region private methods

    private IEnumerable<XElement> GetXRowElements(XCondition condition)
    {
        return _reader.GetXElementsByXPath(condition.XRow);
    }

    private XRow XElementToXRow(XElement element, XCondition condition)
    {
        var row = new XRow();

        foreach (var cell in condition.XCells)
        {
            var cellElement = element.XPathSelectElement(cell.XPath);
            if (cellElement != null)
            {
                row[cell.Key] = cellElement.Value;
            }
        }

        return row;
    }

    #endregion private methods

    /// <summary>
    /// Get rows from the database
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public IEnumerable<XRow> GetRows(XCondition condition)
    {
        return GetXRowElements(condition).Select(e => XElementToXRow(e, condition));
    }
}