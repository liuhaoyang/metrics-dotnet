using System.Runtime.CompilerServices;

namespace Metrics.Core.Common;

public class AtomicFloat
{
    public const float Tolerance = 1e-6f;
    private float _value;

    public float Value
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
    public float GetAndSet(float value)
    {
        var ret = Value;
        Value = value;
        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Add(float value)
    {
        float sum, curr;
        do
        {
            curr = _value;
            sum =  curr + value;
        } while (Math.Abs(curr - Interlocked.CompareExchange(ref _value, sum, curr)) >= Tolerance);
        return sum;
    }
}