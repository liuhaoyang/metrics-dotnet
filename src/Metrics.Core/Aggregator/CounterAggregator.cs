using Metrics.Core.Common.Threading;

namespace Metrics.Core.Aggregator;

public class CounterAggregator<T> : IAggregator<T>
    where T : struct
{
    private readonly Atomic<T> _value = AtomicFactory.Create<T>();

    public void Add(T value)
    {
        _value.Add(value);
    }

    public DataPoint<T>[] GetResults(in AggregateContext context)
    {
        return new[] { DataPoint<T>.Of("value", _value.GetAndSet(default)) };
    }
}