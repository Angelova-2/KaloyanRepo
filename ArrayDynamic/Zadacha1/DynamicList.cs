using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1
{
    internal class DynamicList
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
                    prevNode.next = this;
                }
            }

            public Node(object element)
            {
                this.element = element;
                this.next = null;
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

        public int Count
        {
            get { return count; }
        }

        public void Add(object item)
        {
            Node newNode;

            if (head == null)
            {
                newNode = new Node(item);
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode = new Node(item, tail);
                tail = newNode;
            }

            count++;
        }

        public object Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}");
            }

            Node currentNode = head;
            Node previousNode = null;

            for (int i = 0; i < index; i++)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            object removedItem = currentNode.Element;

            if (previousNode == null)
            {
                head = currentNode.Next;
            }
            else
            {
                previousNode.Next = currentNode.Next;
            }

            if (currentNode.Next == null)
            {
                tail = previousNode;
            }

            count--;
            return removedItem;
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }

                Node currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Element;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }

                Node currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Element = value;
            }
        }

        public int IndexOf(object item)
        {
            Node currentNode = head;
            for (int i = 0; i < count; i++)
            {
                if (currentNode.Element == null && item == null)
                {
                    return i;
                }
                if (currentNode.Element != null && currentNode.Element.Equals(item))
                {
                    return i;
                }
                currentNode = currentNode.Next;
            }
            return -1;
        }

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
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
}
