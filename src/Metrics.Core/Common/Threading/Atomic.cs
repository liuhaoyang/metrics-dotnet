namespace Metrics.Core.Common.Threading;

public interface Atomic<T> where T : struct
{
    T Value { get; set; }

    T GetAndSet(T value);

    T Add(T value);
}