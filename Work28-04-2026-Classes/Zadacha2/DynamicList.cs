using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha2
{
    public class DynamicList
    {
        private class Node
        {
            private object element;
            private Node next;
            public object Element
            {
                get { return element; }
                set { element = value; }
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public Node(object element, Node prevNode)
            {
                this.element = element;
                if (prevNode != null)
                {
                    prevNode.Next = this;
                }
            }
            public Node(object element)
            {
                this.element = element;
            }
        }
        private Node head;
        private Node tail;
        private int count;
        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(object item) 
        {
            Node newNode = new Node(item, tail);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }
        public object RemoveAt(int index) 
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Node current = head;
            Node previous = null;
            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.Next;
            }
            if (previous == null)
            {
                head = current.Next;
            }
            else
            {
                previous.Next = current.Next;
            }
            if (current.Next == null)
            {
                tail = previous;
            }
            count--;
            return current.Element;
            
        }

        public int Remove(object item) 
        {
            Node current = head;
            Node previous = null;
            int index = 0;
            while (current != null)
            {
                if (Equals(current.Element, item))
                { 
                    head = head.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                if (current.Next == null)
                {
                    tail = previous;
                }
                count--;
                return index;
            }
            previous = current;
            current = current.Next;
            index++;
            return -1;
        }

        public int IndexOf(object item)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (!Equals(current.Element, item))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
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
                    throw new ArgumentOutOfRangeException();
                }
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                } 
                return current.Element;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Element = value;    
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
    }

}
