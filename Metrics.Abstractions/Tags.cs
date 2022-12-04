namespace Metrics.Abstractions;

using System.Collections;
public sealed class Tags : IEnumerable<Tag>
{
    public static Tags Empty { get; } = new Tags(Array.Empty<Tag>());
    
    private readonly Tag[] _data;

    private Tags(params Tag[] tags)
    {
        _data = tags ?? throw new ArgumentNullException(nameof(tags));
    }

    public IEnumerator<Tag> GetEnumerator()
    {
        return new TagEnumerator(_data);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Tags Add(string name, string value)
    {
        var dest = new Tag[_data.Length + 1];
        Array.Copy(_data, dest, _data.Length);
        dest[_data.Length] = new Tag(name, value);
        return Of(dest);
    }

    public Tags Merge(Tags other)
    {
        var dest = new Tag[_data.Length + other._data.Length];
        Array.Copy(_data, 0, dest, 0, _data.Length);
        Array.Copy(other._data, 0, dest, _data.Length, other._data.Length);
        return Tags.Of(dest);
    }

    public static Tags Of(params Tag[] tags)
    {
        return new Tags(tags);
    }

    public static Tags Of(params string[] keyValues)
    {
        if (keyValues is null || keyValues.Length == 0)
        {
            throw new ArgumentNullException(nameof(keyValues));
        }
        if (keyValues.Length % 2 == 1)
        {
            throw new ArgumentException("Invalid keyValues", nameof(keyValues));
        }
        var tags = new Tag[keyValues.Length / 2];
        for (int i = 0; i < keyValues.Length; i += 2)
        {
            tags[i / 2] = new Tag(keyValues[i], keyValues[i + 1]);
        }
        return Of(tags);
    }

    private sealed class TagEnumerator : IEnumerator<Tag>
    {
        private readonly Tag[] _tags;
        private int _index = 0;
        public TagEnumerator(Tag[] tags)
        {
            this._tags = tags;
        }

        public Tag Current
        {
            get
            {
                if (_index >= _tags.Length)
                {
                    throw new IndexOutOfRangeException(nameof(_index));
                }
                return _tags[_index];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return _index < _tags.Length;
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}