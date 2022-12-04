using System;
using System.Threading.Tasks;
using Metrics.Core.Common;
using Xunit;

namespace Metrics.Core.Tests.Common;

public class AtomicIntTest
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(11, 12)]
    public void Test_Add(int value, int expect)
    {
        var atomicInt = new AtomicInt()
        {
            Value = 1
        };
        Assert.Equal(expect, atomicInt.Add(value));
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 10)]
    [InlineData(11, 100)]
    [InlineData(11, 1000)]
    [InlineData(11, 10000)]
    public void Test_Add_Parallel(int value, int count)
    {
        var atomicInt = new AtomicInt();
        Parallel.For(0, count, _ => { atomicInt.Add(value); });
        var sum = 0f;
        for (var i = 0; i < count; i++)
            sum += value;
        Assert.True(Math.Abs(sum - atomicInt.Value) < AtomicFloat.Tolerance);
    }
}