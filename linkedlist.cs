using System;
using System.Collections;

public class Stack<T> : IEnumerable
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }
        public Node(T data, Node next)
        {
            Data = data;
            Next = next;
        }
    }

    private Node _top;
    private int _count;

    public Stack()
    {
        _top = null;
        _count = 0;
    }

    public void Push(T item)
    {
        Node node = new Node(item, _top);
        _top = node;
        _count++;
    }

    public T Pop()
    {
        if (_top == null)
        {
            throw new InvalidOperationException("The stack is empty");
        }
        T item = _top.Data;
        _top = _top.Next;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (_top == null)
        {
            throw new InvalidOperationException("The stack is empty");
        }
        return _top.Data;
    }

    public bool Contains(T item)
    {
        Node current = _top;
        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public int Size()
    {
        return _count;
    }

    public T Center()
    {
        if (_count % 2 == 0)
        {
            throw new InvalidOperationException("The stack has an even number of elements");
        }
        int middle = _count / 2;
        Node current = _top;
        for (int i = 0; i < middle; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    public void Sort()
    {
        T[] array = ToArray();
        Array.Sort(array);
        Clear();
        foreach (T item in array)
        {
            Push(item);
        }
    }

    public void Reverse()
    {
        T[] array = ToArray();
        Clear();
        foreach (T item in array)
        {
            Push(item);
        }
    }

    public IEnumerator GetEnumerator()
    {
        Node current = _top;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    public void Traverse()
    {
        Node current = _top;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[_count];
        Node current = _top;
        for (int i = 0; i < _count; i++)
        {
            array[i] = current.Data;
            current = current.Next;
        }
        return array;
    }

    public void Clear()
    {
        _top = null;
        _count = 0;
    }
}

Stack<int> myStack = new Stack<int>();
myStack.Push(1);
myStack.Push(2);
myStack.Push(3);
Console.WriteLine(myStack.Peek()); // Outputs 3
Console.WriteLine(myStack.Pop()); // Outputs 3
Console.WriteLine(myStack.Contains(2)); // Outputs true
Console.WriteLine(myStack.Size()); // Outputs 2
Console.WriteLine(myStack.Center()); // Outputs 1 (assuming there are 
