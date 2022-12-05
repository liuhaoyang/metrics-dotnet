using Metrics.Abstractions;

namespace Metrics.Core.Aggregator;

public interface IAggregator
{
    DataPoint[] GetResults(in AggregateContext context);
}

public interface IAggregator<T> : IAggregator where T : struct
{
    void Add(T value);
    
    DataPoint<T>[] GetResults(in AggregateContext context);
}

public ref struct AggregateContext
{
    public Tags Tags { get; set; }

    public DateTime Time { get; set; }

    public long Interval { get; set; }
}