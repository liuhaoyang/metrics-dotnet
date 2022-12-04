using System.Diagnostics.Tracing;
using Metrics.Abstractions;

namespace Metrics.Core.Aggregators;

public interface AggregateContext
{
    Tags Tags { get; }

    DateTime Time { get; }
    
    long Interval { get; }
}