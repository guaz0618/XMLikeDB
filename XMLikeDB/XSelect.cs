using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

public class XSelect
{
    /// <summary>
    /// Represents a condition for selecting rows.
    /// </summary>
    [JsonPropertyName("xcondition")]
    public XCondition XCondition { get; set; }

    /// <summary>
    /// Represents pipelines to apply to the selected rows.
    /// </summary>
    [JsonPropertyName("pipeline")]
    public JsonNode[] Pipeline { get; set; }
}