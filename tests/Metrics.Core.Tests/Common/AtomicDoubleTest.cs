using System;
using System.Threading.Tasks;
using Metrics.Core.Common;
using Xunit;

namespace Metrics.Core.Tests.Common;

public class AtomicDoubleTest
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(1.1, 2.1)]
    [InlineData(1.111, 2.111)]
    public void Test_Add(double value, double expect)
    {
        var atomic = new AtomicDouble()
        {
            Value = 1
        };
        Assert.Equal(expect, atomic.Add(value));
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(1.10d, 10)]
    [InlineData(1.1112d, 100)]
    [InlineData(1.1112d, 1000)]
    [InlineData(1.1112d, 10000)]
    public void Test_Add_Parallel(double value, int count)
    {
        var atomic = new AtomicDouble();
        Parallel.For(0, count, _ => { atomic.Add(value); });
        var sum = 0d;
        for (var i = 0; i < count; i++)
            sum += value;
        Assert.True(Math.Abs(sum - atomic.Value) < AtomicDouble.Tolerance);
    }
}