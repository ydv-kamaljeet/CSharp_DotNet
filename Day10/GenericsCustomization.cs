using System;
using System.Collections;
namespace Day10;
public class MyList : IList
{
    private object[] _items = new object[5];
    private int _count = 0;

    // Required property
    public int Count => _count;

    public bool IsReadOnly => false;
    public bool IsFixedSize => false;
    public bool IsSynchronized => false;
    public object SyncRoot => this;

    // Indexer (basic)
    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();

            _items[index] = value;
        }
    }

    // 
    // Add implementation
    public int Add(object value)
    {
        if (_count == _items.Length)
            Resize();

        _items[_count] = value;
        return _count++;
    }

    // IndexOf implementation
    public int IndexOf(object value)
    {
        for (int i = 0; i < _count; i++)
        {
            if (Equals(_items[i], value))
                return i;
        }
        return -1;
    }

    // CopyTo implementation
    public void CopyTo(Array array, int index)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (array.Length - index < _count)
            throw new ArgumentException("Target array is too small");

        for (int i = 0; i < _count; i++)
        {
            array.SetValue(_items[i], index + i);
        }
    }

    // --- Helpers ---
    

    // --- Remaining IList members ( not implemented) ---
    private void Resize() => throw new NotImplementedException();
    public void Clear() => throw new NotImplementedException();
    public bool Contains(object value) => throw new NotImplementedException();
    public void Insert(int index, object value) => throw new NotImplementedException();
    public void Remove(object value) => throw new NotImplementedException();
    public void RemoveAt(int index) => throw new NotImplementedException();
    public IEnumerator GetEnumerator() => throw new NotImplementedException();
}
