using System.Reflection;

public interface IPipelineProviderFactory
{
    IPipelineProvider Create(Assembly[] assemblies);
}