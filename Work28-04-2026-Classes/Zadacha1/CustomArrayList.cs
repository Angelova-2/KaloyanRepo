using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    public class CustomArrayList
    {
        private object[] arr;
        private int count;
        private static readonly int INITIAL_CAPACITY = 4;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public CustomArrayList()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }
        public void Add(object item) 
        {
            EnsureCapacity();
            arr[count++] = item;

        }
        public void Insert(int index, object item)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            EnsureCapacity();
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
                if (arr[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Clear()
        {
            arr = new object[INITIAL_CAPACITY];
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
                if ((index < 0) || (index >= count)) 
                {
                    throw new IndexOutOfRangeException(); 
                }
                return arr[index]; 
            }
            set 
            {
                if (index < 0 ||  (index >= count))
                {
                    throw new IndexOutOfRangeException();
                }
            }

        }
        public object RemoveAt(int index)
        {
            if ((index < 0) || (index >= count))
            {
                throw new IndexOutOfRangeException();
            }
            object removedItem = arr[index];
            for (int i = index; i < count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[--count] = null;
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
        public void EnsureCapacity()
        {
            if (count == arr.Length)
            {
                object[] newArr = new object[arr.Length * 2];
                Array.Copy(arr, newArr, arr.Length);
                arr = newArr;
            }
        }
    }
    
}
