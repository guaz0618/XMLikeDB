using System.Text.Json.Nodes;

public interface IPipeline
{
    string Name { get; }

    void DoSomething(XRow row, JsonNode input);
}