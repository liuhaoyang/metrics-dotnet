using Metrics.Abstractions;

namespace Metrics.Core.Instrument;

public sealed class MetricDesc
{
    public string Name { get; }

    public MetricType Type { get; }

    public MetricDesc(string name, MetricType? metricType)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = metricType ?? throw new ArgumentNullException(nameof(metricType));
    }
}