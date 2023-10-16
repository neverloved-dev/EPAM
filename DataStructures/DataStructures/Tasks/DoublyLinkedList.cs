using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Length { get;  set; }

        public void Add(T e)
        {
            var newNode = new Node<T>(e);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            var newNode = new Node<T>(e);
            if (index == 0)
            {
               
                newNode.Next = head;
                if (head != null)
                {
                    head.Previous = newNode;
                }
                head = newNode;
            }
            else if (index == Length)
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            else
            {
                var current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next = newNode;
                newNode.Next.Previous = newNode;
            }
    
            Length++; 
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
                var current = head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
        }

        public void Remove(T item)
        {
            var current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                {
                    if (current == head)
                    {
                        head = current.Next;
                        if (head != null)
                        {
                            head.Previous = null;
                        }
                    }
                    else if (current == tail)
                    {
                        tail = current.Previous;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    Length--;
                    return;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                var removedValue = head.Value;
                head = head.Next;
                if (head != null)
                {
                    head.Previous = null;
                }
                Length--;
                return removedValue;
            }
            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current == tail)
            {
                tail = current.Previous;
                tail.Next = null;
            }
            else
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }

            Length--;
            return current.Value;
        }

        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
