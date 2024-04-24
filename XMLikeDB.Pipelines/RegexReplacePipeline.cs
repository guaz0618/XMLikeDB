using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

/// <summary>
/// Pipeline to replace a regex pattern in a string.
/// </summary>
public class RegexReplacePipeline : PipelineBase<RegexReplacePipelineInput>
{
    public override string Name => "regex-replace";

    public override void DoSomething(XRow row, RegexReplacePipelineInput input)
    {
        var from = input.From;
        var to = input.To;
        var pattern = input.Pattern;
        var replacement = input.Replacement;

        var value = row[from].ToString();
        row[to] = Regex.Replace(value, pattern, replacement);
    }
}