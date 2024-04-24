using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Xml;
using AutoMapper;

string jsonPath = args[0];
string xmlPath = args[1];

var jsonStr = File.ReadAllText(jsonPath);
var select = JsonSerializer.Deserialize<XSelect>(jsonStr);

using var xmlReader = XmlReader.Create(xmlPath);
using var reader = new XmlPathDocumentReader(xmlReader);
using var database = new XDatabase(reader);

string dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var assemblies = Directory.GetFiles(dllPath, "*.dll").Select(Assembly.LoadFile).ToArray();
var pipelineProvider = new PipelineProviderFactory().Create(assemblies);

foreach (var row in database.GetRows(select.XCondition))
{
    foreach (var input in select.Pipeline)
    {
        string name = input["name"].GetValue<string>();
        var pipeline = pipelineProvider.GetPipeline(name);
        if (pipeline == null) continue;

        pipeline.DoSomething(row, input);
    }

    Console.WriteLine(JsonSerializer.Serialize(row));
}