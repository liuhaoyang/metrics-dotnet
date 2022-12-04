using System.Runtime.CompilerServices;

namespace Metrics.Core.Common;

public class AtomicLong
{
    private long _value;

    public long Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            Volatile.Read(ref _value);
            return _value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Volatile.Write(ref _value, value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long GetAndSet(long value)
    {
        var ret = Value;
        Value = value;
        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long Add(long value)
    {
        return Interlocked.Add(ref _value, value);
    }
}