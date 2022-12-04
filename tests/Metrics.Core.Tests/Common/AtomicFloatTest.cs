using System;
using System.Threading;
using System.Threading.Tasks;
using Metrics.Core.Common;
using Xunit;

namespace Metrics.Core.Tests.Common;

public class AtomicFloatTest
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(1.1, 2.1)]
    [InlineData(1.111, 2.111)]
    public void Test_Add(float value, float expect)
    {
        var atomicFloat = new AtomicFloat
        {
            Value = 1
        };
        Assert.Equal(expect, atomicFloat.Add(value));
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(1.10f, 10)]
    [InlineData(1.1111f, 100)]
    [InlineData(1.1111f, 1000)]
    [InlineData(1.1111f, 10000)]
    public void Test_Add_Parallel(float value, int count)
    {
        var atomicFloat = new AtomicFloat();
        Parallel.For(0, count, _ => { atomicFloat.Add(value); });
        var sum = 0f;
        for (var i = 0; i < count; i++)
            sum += value;
        Assert.True(Math.Abs(sum - atomicFloat.Value) < AtomicFloat.Tolerance);
    }
}