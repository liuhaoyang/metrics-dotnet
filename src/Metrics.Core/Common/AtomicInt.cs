using System.Runtime.CompilerServices;

namespace Metrics.Core.Common;

public class AtomicInt
{
    private int _value;

    public int Value
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
    public int GetAndSet(int value)
    {
        var ret = Value;
        Value = value;
        return ret;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Add(int value)
    {
        return Interlocked.Add(ref _value, value);
    }
}