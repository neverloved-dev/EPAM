using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> items = new DoublyLinkedList<T>();
        public T Dequeue()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var item = items.ElementAt(0);
            items.Remove(item);
            return item;
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException();
            }

            var item = items.ElementAt(0);
            items.Remove(item);
            return items.ElementAt(0);
        }

        public void Push(T item)
        {
            items.Add(item);
        }
    }
}
