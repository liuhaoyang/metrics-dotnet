namespace Metrics.Abstractions;

public interface IHistogram<in T> : IMetric, IMetric<IHistogram<T>>
{
    void Record(T value);
}