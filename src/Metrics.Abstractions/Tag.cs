namespace Metrics.Abstractions;

public sealed class Tag
{
    public string? Key { get; }

    public string? Value { get; }

    public Tag(string key, string value)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }
        Key = key;
        Value = value;
    }
}