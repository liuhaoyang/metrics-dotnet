using Metrics.Abstractions;

namespace Metrics.Core.Aggregator;

public struct AggregateContext
{
    public Tags Tags { get; set; }

    public DateTime Time { get; set; }

    public long Interval { get; set; }
}