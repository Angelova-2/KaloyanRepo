using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackArray
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;
        public ArrayStack(int capacity = InitialCapacity) 
        {
            this.elements = new T[capacity];
            this.Count = capacity;


        }
        public void Push(T element) 
        {
            element = elements[this.Count];
            this.Count++;

   

            if (this.Count == this.elements.Length)
            {
                Grow();
            }
        }
        public T Pop() 
        {
            this.Count--;
            return this.elements[this.Count];
        }
        public T[] ToArray() 
        {
            object[] array = new object[Count];
            for (int i = 0; i < Count; i++)
            {
                array[i] = this.elements[i];

            }
            return this.elements;

        }
        private void Grow() 
        {
            object[] newElements = new object[2 * this.elements.Length];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements;
            }
            
        }

    }
}
