namespace Metrics.Core.Aggregator;

public interface IAggregator<in T>
{
    void Add(T value);

    DataPoint[] GetResults(in AggregateContext context);
}