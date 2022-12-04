using Metrics.Core.Common;

namespace Metrics.Core.Aggregator;

public class LongCounterAggregator : IAggregator<long>
{
    private readonly AtomicLong _value = new();

    public void Add(long value)
    {
        _value.Add(value);
    }

    public DataPoint[] GetResults(in AggregateContext context)
    {
        return new DataPoint[] { DataPoint<long>.Of("value", _value.GetAndSet(0)) };
    }
}

public class IntCounterAggregator : IAggregator<int>
{
    private readonly AtomicInt _value = new();
    
    public void Add(int value)
    {
        _value.Add(value);
    }

    public DataPoint[] GetResults(in AggregateContext context)
    {
        return new DataPoint[] { DataPoint<long>.Of("value", _value.GetAndSet(0)) };
    }
}