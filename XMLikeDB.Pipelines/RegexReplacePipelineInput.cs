using System.Text.Json.Serialization;

/// <summary>
/// Pipeline to replace a regex pattern in a string.
/// </summary>
public class RegexReplacePipelineInput : IPipelineInput
{
    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonPropertyName("to")]
    public string To { get; set; }

    [JsonPropertyName("pattern")]
    public string Pattern { get; set; }

    [JsonPropertyName("replacement")]
    public string Replacement { get; set; }
}