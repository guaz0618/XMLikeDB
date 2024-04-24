/// <summary>
/// Pipeline provider.
/// </summary>
public class PipelineProvider : IPipelineProvider
{
    private readonly Dictionary<string, IPipeline> _pipelines;

    public PipelineProvider(IEnumerable<IPipeline> pipelines)
    {
        _pipelines = pipelines.ToDictionary(p => p.Name);
    }

    /// <summary>
    /// Get a pipeline by name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IPipeline GetPipeline(string name)
    {
        return _pipelines.TryGetValue(name, out var pipeline) ? pipeline : null;
    }
}