using System.Xml.Linq;

/// <summary>
/// Represents a reader for XML.
/// </summary>
public interface IXReader : IDisposable
{
    /// <summary>
    /// Get XElements by XPath.
    /// </summary>
    /// <param name="xpath"></param>
    /// <returns></returns>
    IEnumerable<XElement> GetXElementsByXPath(string xpath);
}