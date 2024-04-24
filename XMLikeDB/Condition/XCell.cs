using System.Text.Json.Serialization;

/// <summary>
/// Represents a cell in a row.
/// </summary>
public class XCell
{
    /// <summary>
    /// XPath of the cell.
    /// </summary>
    [JsonPropertyName("xpath")]
    public string XPath { get; set; }

    /// <summary>
    /// Key of the cell in XRow.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }
}