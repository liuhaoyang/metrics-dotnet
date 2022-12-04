namespace Metrics.Abstractions;

public interface ISummary<in T> : IMetric, IMetric<ISummary<T>>
{
    void Record(T value);
}