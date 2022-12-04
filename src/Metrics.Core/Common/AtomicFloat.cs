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
        float sum;
        while (true)
        {
            var initValue = _value;
            unchecked
            {
                sum = initValue + value;
            }
            if (Math.Abs(initValue - Interlocked.CompareExchange(ref _value, sum, initValue)) < Tolerance)
            {
                break;
            }
        }
        return sum;
    }
}