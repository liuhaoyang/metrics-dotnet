using Metrics.Abstractions;

namespace Metrics.Core.Instrument;

public sealed class MetricInvoker<T> where T : struct
{
    private readonly Tags _tags;

    public MetricInvoker()
        : this(Tags.Empty)
    {
    }

    public MetricInvoker(Tags tags)
    {
        _tags = tags;
    }

    public T Invoke(T value)
    {
        return default(T);
    }

    MetricInvoker<T> WithTags(Tags tags)
    {
        return new(tags);
    }
}