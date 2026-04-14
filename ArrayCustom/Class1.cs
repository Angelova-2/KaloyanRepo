using System;

public class Class1
{
    using System;

public class CustomArrayList
{
    private object[] arr;
    private int count;

    public int Count
    {
        get { return count; }
    }

    private static readonly int INITIAL_CAPACITY = 4;

    public CustomArrayList()
    {
        arr = new object[INITIAL_CAPACITY];
        count = 0;
    }

    public void Add(object item)
    {
        if (count == arr.Length)
        {
            int newCapacity = arr.Length * 2;
            object[] newArr = new object[newCapacity];

            for (int i = 0; i < count; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        arr[count] = item;
        count++;
    }

    public void Insert(int index, object item)
    {
        if (index < 0 || index > count)
        {
            throw new IndexOutOfRangeException("Invalid index: " + index);
        }

        if (count == arr.Length)
        {
            int newCapacity = arr.Length * 2;
            object[] newArr = new object[newCapacity];

            for (int i = 0; i < count; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        for (int i = count; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }

        arr[index] = item;
        count++;
    }

    public int IndexOf(object item)
    {
        for (int i = 0; i < count; i++)
        {
            if (arr[i] == null && item == null)
            {
                return i;
            }
            if (arr[i] != null && arr[i].Equals(item))
            {
                return i;
            }
        }
        return -1;
    }

    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            arr[i] = null;
        }
        count = 0;
    }

    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }

    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }
            arr[index] = value;
        }
    }

    public object Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Invalid index: " + index);
        }

        object removedItem = arr[index];

        for (int i = index; i < count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        arr[count - 1] = null;
        count--;

        return removedItem;
    }

    public int Remove(object item)
    {
        int index = IndexOf(item);
        if (index != -1)
        {
            Remove(index);
        }
        return index;
    }
}