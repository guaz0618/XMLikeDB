using System.Xml;

public class XDatabaseTests
{
    [Fact]
    public void TestGetRows()
    {
        // Arrange
        var xml = @"<row><key>value</key></row>";
        using var reader = XmlReader.Create(new StringReader(xml));
        using var xReader = new XmlPathDocumentReader(reader);
        using var database = new XDatabase(xReader);
        var condition = new XCondition
        {
            XRow = "row",
            XCells = new XCell[] {
                new XCell{
                    Key = "name",
                    XPath = "key"
                }
            }
        };

        // Act
        var rows = database.GetRows(condition);
        var row = rows.First();

        // Assert
        Assert.Equal("value", row["name"]);
    }
}