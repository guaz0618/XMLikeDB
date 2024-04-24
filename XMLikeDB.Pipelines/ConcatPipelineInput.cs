using System.Text.Json.Serialization;

/// <summary>
/// Pipeline to concatenate multiple fields into one.
/// </summary>
public class ConcatPipelineInput : IPipelineInput
{
    [JsonPropertyName("from")]
    public string[] From { get; set; }

    [JsonPropertyName("to")]
    public string To { get; set; }

    [JsonPropertyName("separator")]
    public string Separator { get; set; }
}