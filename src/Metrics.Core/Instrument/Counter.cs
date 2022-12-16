using Metrics.Abstractions;

namespace Metrics.Core.Instrument;

public class Counter<TValue> : MetricBase<ReadonlyCounter<TValue>, TValue> where TValue : struct
{
    public Counter(MetricDesc desc, MetricInvoker<TValue> invoker) : base(desc, invoker)
    {
    }

    public override ReadonlyCounter<TValue> WithTags(Tags tags)
    {
        return new ReadonlyCounter<TValue>();
        // return new 
    }
}

public readonly struct ReadonlyCounter<TValue> : IMetric, IMetric<ReadonlyCounter<TValue>>
{
    public string Name => throw new NotImplementedException();

    public MetricType Type => throw new NotImplementedException();

    public ReadonlyCounter<TValue> WithTags(Tags tags)
    {
        throw new NotImplementedException();
    }
}