namespace Metrics.Core.Aggregator;

public interface DataPoint
{
    string Name { get; }
}

public class DataPoint<T> : DataPoint where T : struct
{
    public string Name { get; }

    public T Value { get; }

    private DataPoint(string name, T value)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Value = value;
    }

    public static DataPoint<T> Of(string name, T value) => new(name, value);
}