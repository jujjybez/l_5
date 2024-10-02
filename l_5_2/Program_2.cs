using System;
using System.Collections;

public class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;
    public MyList()
    {
        items = new T[0];
        count = 0;
    }
    public MyList(params T[] val)
    {
        items = new T[val.Length];
        Array.Copy(val, items, val.Length);
        count = val.Length;
    }
    public MyList(IEnumerable<T> collection)
    {
        items = new T[0];
        foreach (var item in collection) { Add(item); }
    }
    public void Add(T item)
    {
        if (count == items.Length)
        {
            int newCapacity = count == 0 ? 4 : count * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems, count);
            items = newItems;
        }
        items[count] = item;
        count++;
    }
    public T this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }
    public int Count
    {
        get { return count; }
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++) { yield return items[i]; }
    }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
}

class Program
{
    static void Main()
    {
        MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };
        myList.Add(678);
        Console.WriteLine($"Elements i - 1: \n");
        foreach (var item in myList) { Console.WriteLine($"Element: {item}"); }
        Console.WriteLine($"\nTotal number of elements: {myList.Count}");
    }
}
