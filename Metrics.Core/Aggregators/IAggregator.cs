namespace Metrics.Core.Aggregators;

public interface IAggregator<in T>
{
    void Add(T value);
    
    
}