using System.Xml;

public class XmlPathDocumentReaderTests
{
    [Fact]
    public void TestGetXElementsByXPath()
    {
        // Arrange
        var xml = @"<root><child>value</child></root>";
        using var reader = XmlReader.Create(new StringReader(xml));
        using var xReader = new XmlPathDocumentReader(reader);

        // Act
        var elements = xReader.GetXElementsByXPath("/root/child").ToList();

        // Assert
        Assert.Single(elements);
        Assert.Equal("child", elements[0].Name.LocalName);
        Assert.Equal("value", elements[0].Value);
    }
}