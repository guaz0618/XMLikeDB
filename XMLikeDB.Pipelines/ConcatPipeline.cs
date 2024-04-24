using System.Text.Json.Serialization;

/// <summary>
/// Pipeline to concatenate multiple fields into one.
/// </summary>
public class ConcatPipeline : PipelineBase<ConcatPipelineInput>
{
    public override string Name => "concat";

    public override void DoSomething(XRow row, ConcatPipelineInput input)
    {
        var from = input.From;
        var to = input.To;
        var separator = input.Separator;

        var values = from.Select(f => row[f].ToString());
        row[to] = string.Join(separator, values);
    }
}