using System.Runtime.CompilerServices;

namespace Metrics.Core.Common;

public class AtomicDouble
{
    public const double Tolerance = 1e-6f;
    private double _value;

    public double Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Volatile.Read(ref _value);
            return _value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Interlocked.Exchange(ref _value, value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double GetAndSet(double value)
    {
        var ret = Value;
        Value = value;
        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double Add(double value)
    {
        double sum, curr;
        do
        {
            curr = _value;
            sum =  curr + value;
        } while (Math.Abs(curr - Interlocked.CompareExchange(ref _value, sum, curr)) >= Tolerance);
        return sum;
    }
}