namespace Metrics.Abstractions;

public interface IGauge<in T> : IMetric, IMetric<IGauge<T>>
{
    void Record(T value);
}