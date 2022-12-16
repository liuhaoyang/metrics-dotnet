using Metrics.Abstractions;

namespace Metrics.Core.Instrument;

public abstract class MetricBase<TMetric, TValue> : IMetric, IMetric<TMetric>
    where TMetric : IMetric
    where TValue : struct
{
    public string Name => Desc.Name;

    public MetricType Type => Desc.Type;

    public MetricInvoker<TValue> Invoker { get; }

    public MetricDesc Desc { get; }

    protected MetricBase(MetricDesc desc, MetricInvoker<TValue> invoker)
    {
        Desc = desc ?? throw new ArgumentNullException(nameof(desc));
        Invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
    }

    public abstract TMetric WithTags(Tags tags);
}