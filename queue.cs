using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace C_SHARP
{
    class Program
    {


        class Queue<T>
        {
            private T[] items;
            private int front;
            private int rear;
            private int capacity;
        
            /// Constructor
           
            public Queue()
            {
                this.capacity = 1000;
                this.items = new T[this.capacity];
                this.front = 0;
                this.rear = 0;
            }
          
            /// Constructor
           
            public Queue(int capacity)
            {
                this.capacity = capacity;
                this.items = new T[capacity];
                this.front = 0;
                this.rear = 0;
            }
           
            /// Add item to the Queue
           
            public void Push(T item)
            {


                if (IsFull())
                {
                    throw new Exception("Queue is full");
                }


                // insert element at the rear end
                items[rear] = item;
                rear++;


            }
           
            /// Returns the first item with deleting
           
            public T Pop()
            {

                // check if queue is empty 
                if (IsEmpty())
                {
                    throw new Exception("Queue is empty");
                }
                T frontItem = items[this.front];
                // shift elements to the right
                for (int i = 0; i < rear - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                rear--;
                return frontItem;
            }
            
            ///  Views the first element in the Queue but does not remove it.
           
            public T Peek()
            {
                return items[this.front];
            }
            
            /// Contains value in Queue
           
            public bool Contains(T item)
            {
                for (int i = front; i < rear; i++)
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
                return rear;
            }


           
            /// Checks if Queue is empty
            
            public bool IsEmpty()
            {
                return front == rear;
            }


           
            /// Checks if Queue is full
            
            public bool IsFull()
            {
                return capacity == rear;
            }


            
            /// Reverse Queue
            
            public void Reverse()
            {
                T[] itemsTemp = new T[rear];
                int counter = rear - 1;
                for (int i = front; i < rear; i++)
                {
                    itemsTemp[counter] = items[i];
                    counter--;
                }


                items = itemsTemp;
            }
           
            /// Print Queue
        
            public void Print()
            {
                if (IsEmpty())
                {
                    throw new Exception("Queue is empty");
                }


                Console.WriteLine("Items in the Queue are:");
                // traverse front to rear and print elements 
                for (int i = front; i < rear; i++)
                {
                    Console.WriteLine(items[i]);
                }
            }
        }


        class QueueIterator<T>
        {
            private Queue<T> currentQueue;


            
            /// Constructor
           
            public QueueIterator(Queue<T> currentQueue)
            {
                this.currentQueue = currentQueue;
            }


            public bool IsEmpty()
            {
                return this.currentQueue.IsEmpty();
            }




            public T Pop()
            {
                return this.currentQueue.Pop();
            }
        }
        static void Main(string[] args)
        {


            try
            {
                Queue<int> myQueue = new Queue<int>(7);
                myQueue.Push(8);
                myQueue.Push(58);
                myQueue.Push(29);
                myQueue.Push(40);
                myQueue.Push(60);
                myQueue.Push(2);
                myQueue.Push(64);
                myQueue.Print();
                Console.WriteLine("Queue size is: {0}", myQueue.Size());
                myQueue.Reverse();
                Console.WriteLine("Reversing the queue elements");
                myQueue.Print();


                if (myQueue.Contains(89))
                {
                    Console.WriteLine("Queue contains item 89");
                }
                else
                {
                    Console.WriteLine("Queue does not contain item 89");
                }


                if (myQueue.Contains(40))
                {
                    Console.WriteLine("Queue contains item 40");
                }
                else
                {
                    Console.WriteLine("Queue does not contain item 40");
                }
                Console.WriteLine("The frontend item is {0}", myQueue.Peek());
                Console.WriteLine("Delete the frontend item: {0}", myQueue.Pop());
                Console.WriteLine("Queue size is: {0}", myQueue.Size());
                QueueIterator<int> QueueIterator = new QueueIterator<int>(myQueue);
                Console.WriteLine("\nDisplaying items using QueueIterator");
                while (!QueueIterator.IsEmpty())
                {
                    Console.WriteLine(QueueIterator.Pop());
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
