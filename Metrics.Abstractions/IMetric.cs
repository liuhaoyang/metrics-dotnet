namespace Metrics.Abstractions;

public interface IMetric
{
    string Name { get; }

    MetricType Type { get; }

    Tags Tags { get; }
}

public interface IMetric<out T> where T : IMetric
{
    T Tags(Tags tags);
}