using System;
using System.Collections.Generic;
using System.Linq;

public class RecentlyUsedList
{
    private readonly List<string> items;
    private readonly int capacity;

    public RecentlyUsedList(int capacity = 5)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.");
        }

        this.capacity = capacity;
        this.items = new List<string>(capacity);
    }

    public void Add(string item)
    {
        if (string.IsNullOrEmpty(item))
        {
            throw new ArgumentException("Null or empty strings are not allowed.");
        }

        if (items.Contains(item))
        {
            items.Remove(item);
        }

        if (items.Count == capacity)
        {
            items.RemoveAt(capacity - 1);
        }

        items.Insert(0, item);
    }

    public string GetItem(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new IndexOutOfRangeException("Index is out of bounds.");
        }

        return items[index];
    }

    public int Count => items.Count;

    // Additional property to get the capacity
    public int Capacity => capacity;
}
