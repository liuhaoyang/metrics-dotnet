namespace Metrics.Core.Common.Threading;

public sealed class AtomicFactory
{
    public static Atomic<T> Create<T>() where T : struct
    {
        return typeof(T) switch
        {
            Type type when type == typeof(int) => (Atomic<T>)new AtomicInt(),
            Type type when type == typeof(long) => (Atomic<T>)new AtomicLong(),
            Type type when type == typeof(float) => (Atomic<T>)new AtomicFloat(),
            Type type when type == typeof(double) => (Atomic<T>)new AtomicDouble(),
            _ => throw new ArgumentException("Unsupported numeric type.")
        };
    }
}