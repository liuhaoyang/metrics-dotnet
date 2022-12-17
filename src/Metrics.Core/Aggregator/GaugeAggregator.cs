using Metrics.Core.Common.Threading;

namespace Metrics.Core.Aggregator;

public class GaugeAggregator<T, TAtomic> : IAggregator<T>
    where T : struct
    where TAtomic : Atomic<T>, new()
{
    private readonly TAtomic _value = new();
    
    public void Add(T value)
    {
        _value.Value = value;
    }

    public DataPoint<T>[] GetResults(in AggregateContext context)
    {
        return new[] { DataPoint<T>.Of("value",  _value.GetAndSet(default)) };
    }
}