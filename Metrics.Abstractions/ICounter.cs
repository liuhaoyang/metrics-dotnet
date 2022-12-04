namespace Metrics.Abstractions;

public interface ICounter<in T> : IMetric, IMetric<ICounter<T>>
{
    void Increment(T value);
}