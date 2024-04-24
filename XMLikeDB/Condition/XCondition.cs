using System.Text.Json.Serialization;

/// <summary>
/// Represents a condition for selecting rows.
/// </summary>
public class XCondition
{
    /// <summary>
    /// XPath of the rows.
    /// </summary>
    [JsonPropertyName("xrow")]
    public string XRow { get; set; }

    /// <summary>
    /// XPath of the cells.
    /// </summary>
    [JsonPropertyName("xcells")]
    public XCell[] XCells { get; set; }
}