using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace dsstack
{
    class Program
    {


        class Stack<T>
        {
            private T[] items;
            private int top;
            private int capacity;

            /// Constructor

            public Stack()
            {
                this.capacity = 10000;
                this.items = new T[this.capacity];
                this.top = -1;
            }

            /// Constructor

            public Stack(int capacity)
            {
                this.capacity = capacity;
                this.items = new T[capacity];
                this.top = -1;
            }

            /// Add item to the stack

            public void Push(T item)
            {
                if (!IsFull())
                {
                    items[++top] = item;
                }
                else
                {
                    throw new Exception("Stack is full");
                }
            }

            /// Returns the top item with deleting

            public T Pop()
            {
                if (!IsEmpty())
                {
                    return items[top--];
                }
                else
                {
                    throw new Exception("Stack is empty");
                }
            }

            ///  Views the first element in the Stack but does not remove it.

            public T Peek()
            {
                return items[top];
            }

            /// Contains value in stack

            public bool Contains(T item)
            {
                for (int i = 0; i < top; i++)
                {
                    if (item.Equals(items[i]))
                    {
                        return true;
                    }
                }
                return false;
            }


            /// Returns size

            public int Size()
            {
                return top + 1;
            }



            /// Checks if stack is empty

            public bool IsEmpty()
            {
                return top == -1;
            }



            /// Checks if stack is full

            public bool IsFull()
            {
                return top == capacity - 1;
            }



            /// Reversng stack

            public void Reverse()
            {
                T[] itemsTemp = new T[top + 1];
                int counter = top;
                for (int i = 0; i <= top; i++)
                {
                    itemsTemp[counter] = items[i];
                    counter--;
                }
                items = itemsTemp;
            }

            /// Printing stack

            public void Print()
            {
                if (IsEmpty())
                {
                    throw new Exception("Stack is empty");
                }
                else
                {
                    Console.WriteLine("Items in the stack are:");
                    for (int i = top; i >= 0; i--)
                    {
                        Console.WriteLine(items[i]);
                    }
                }
            }
        }


        class StackIterator<T>
        {
            private Stack<T> currentStack;



            /// Constructor

            public StackIterator(Stack<T> currentStack)
            {
                this.currentStack = currentStack;
            }


            public bool IsEmpty()
            {
                return this.currentStack.IsEmpty();
            }



            public T Pop()
            {
                return this.currentStack.Pop();
            }
        }
        static void Main(string[] args)
        {


            try
            {
                Stack<int> stack = new Stack<int>(5);
                stack.Push(23);
                stack.Push(90);
                stack.Push(10);
                stack.Push(66);
                stack.Push(887);
                stack.Print();
                Console.WriteLine("Stack size is: {0}", stack.Size());
                stack.Reverse();
                Console.WriteLine("Reverse of the stack");
                stack.Print();


                if (stack.Contains(33))
                {
                    Console.WriteLine("Stack contains item 33");
                }
                else
                {
                    Console.WriteLine("Stack does not contain item 33");
                }


                if (stack.Contains(46))
                {
                    Console.WriteLine("Stack contains item 46");
                }
                else
                {
                    Console.WriteLine("Stack does not contain item 546");
                }
                Console.WriteLine("The top item is {0}", stack.Peek());
                Console.WriteLine("Delete the top item: {0}", stack.Pop());
                Console.WriteLine("Stack size is: {0}", stack.Size());
                StackIterator<int> stackIterator = new StackIterator<int>(stack);
                Console.WriteLine("\nDisplay items using StackIterator");
                while (!stackIterator.IsEmpty())
                {
                    Console.WriteLine(stackIterator.Pop());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}