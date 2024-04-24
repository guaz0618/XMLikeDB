using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// Factory to create a pipeline provider.
/// </summary>
public class PipelineProviderFactory : IPipelineProviderFactory
{
    public IPipelineProvider Create(Assembly[] assemblies)
    {
        // Find the implementation class that implements IPipeline
        var pipelines = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IPipeline).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(t => Activator.CreateInstance(t) as IPipeline);
        
        return new PipelineProvider(pipelines);
    }
}
