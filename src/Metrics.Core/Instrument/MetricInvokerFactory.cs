namespace Metrics.Core.Instrument;

public class MetricInvokerFactory
{
    public MetricInvoker<T> Create<T>() where T : struct
    {
        return default;
    }
}