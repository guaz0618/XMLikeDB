using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

public class XmlPathDocumentReader : IXReader
{
    private XmlReader _xmlReader;

    public XmlPathDocumentReader(XmlReader xmlReader)
    {
        _xmlReader = xmlReader;
    }

    public void Dispose()
    {
        _xmlReader.Dispose();
    }

    /// <summary>
    /// 透過 XPath 從 XmlReader 中取得下一個 XElement。
    /// </summary>
    /// <param name="xpath"></param>
    /// <returns></returns>
    public IEnumerable<XElement> GetXElementsByXPath(string xpath)
    {
        var document = new XPathDocument(_xmlReader);   //減低大型檔案的記憶體耗用，採用 XPathDocument
        var navigator = document.CreateNavigator();
        var iterator = navigator.Select(xpath);

        while (iterator.MoveNext())
        {
            var node = iterator.Current;
            if (node != null)
            {
                var element = XElement.Parse(node.OuterXml);
                yield return element;
            }
        }
    }
}
