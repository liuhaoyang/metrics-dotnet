namespace Metrics.Abstractions;

public interface IMetric
{
    string Name { get; }

    MetricType Type { get; }
}

public interface IMetric<T> : IMetric where T : struct, IMetric
{
    ref T WithTags(Tags tags);
}