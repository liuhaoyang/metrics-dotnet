namespace Metrics.Abstractions;

public interface IMetricRegistry
{
    ICounter<T> CreateCounter<T>(string name);

    IGauge<T> CreateGauge<T>(string name);

    IHistogram<T> CreateHistogram<T>(string name, params T[] buckets);

    ISummary<T> CreateSummary<T>(string name, params double[] quantiles);
}