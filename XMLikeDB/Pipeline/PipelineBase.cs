using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

/// <summary>
/// Base class for all pipelines.
/// </summary>
/// <typeparam name="TInput"></typeparam>
public abstract class PipelineBase<TInput> : IPipeline
    where TInput : IPipelineInput
{
    /// <summary>
    /// 設定檔需透過本欄位，來查找對應的 Pipeline。
    /// </summary>
    [JsonPropertyName("name")]
    public abstract string Name { get; }

    /// <summary>
    /// Deserialize input and call DoSomething.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="input"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void DoSomething(XRow row, JsonNode input)
    {
        if (!Equals(input?["name"]?.GetValue<string>(), Name))
        {
            throw new InvalidOperationException($"Input must have a name property {Name}.");
        }
        var _input = input.Deserialize<TInput>();
        DoSomething(row, _input);
    }

    public abstract void DoSomething(XRow row, TInput input);
}