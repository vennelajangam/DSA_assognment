using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace dspqueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating priority queue of students");
            var pq = new PriorityQueue<Student>();


            var s1 = new Student("venn", 1.0);
            var s2 = new Student("rech", 2.0);
            var s3 = new Student("nivv", 3.0);
            var s4 = new Student("rann", 4.0);
            var s5 = new Student("prams", 5.0);
            var s6 = new Student("komal", 6.0);


            Console.WriteLine($"Adding {s5} to priority queue");
            pq.Enqueue(s5);
            Console.WriteLine($"Adding {s3} to priority queue");
            pq.Enqueue(s3);
            Console.WriteLine($"Adding {s6} to priority queue");
            pq.Enqueue(s6);
            Console.WriteLine($"Adding {s4} to priority queue");
            pq.Enqueue(s4);
            Console.WriteLine($"Adding {s1} to priority queue");
            pq.Enqueue(s1);
            Console.WriteLine($"Adding {s2} to priority queue");
            pq.Enqueue(s2);


            Console.WriteLine("\n elements in priority queue are:");
            Console.WriteLine(pq.ToString());
            Console.WriteLine($"Priority queue size is: {pq.Size()}");
            Console.WriteLine();


            Console.WriteLine($"Peeking a student from queue: {pq.Peek()}");
            Console.WriteLine($"Checking if queue contains peeked element: {pq.Contains(s1)}");


            Console.WriteLine("Removing a student from priority queue");
            var s = pq.Dequeue();
            Console.WriteLine($"Removed student is {s}");
            Console.WriteLine($"Checking if queue contains peeked element: {pq.Contains(s1)}");
            Console.WriteLine("\nPriority queue is now:");
            Console.WriteLine(pq.ToString());
            Console.WriteLine();


            Console.WriteLine("Removing a second student from queue");
            s = pq.Dequeue();
            Console.WriteLine($"Removed student is {s}");
            Console.WriteLine("\nPriority queue is now:");
            Console.WriteLine(pq.ToString());
            Console.WriteLine();


            Console.WriteLine("printing the reversed queue:");
            var reversed = pq.Reverse();
            reversed.Print();
            Console.WriteLine();


            Console.WriteLine("Iterating through the reversed queue:");
            foreach (var elem in reversed)
                Console.WriteLine(elem);
            Console.WriteLine();


            Console.WriteLine("Dequeueing elements from the reversed queue:");
            Console.WriteLine(reversed.Dequeue());
            Console.WriteLine(reversed.Dequeue());
            Console.WriteLine(reversed.Dequeue());
            Console.WriteLine(reversed.Dequeue());


            Console.ReadLine();
        }
    }


    public class Student : IComparable<Student>
    {
        public string LastName { get; }
        public double Priority { get; set; } // smaller values are higher priority


        public Student(string lastName, double priority)
        {
            LastName = lastName;
            Priority = priority;
        }


        public override string ToString() => "(" + LastName + ", " + Priority.ToString("F1") + ")";


        public int CompareTo(Student other)
        {
            if (Priority < other.Priority) return -1;
            if (Priority > other.Priority) return 1;
            return 0;
        }
    }


    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> data;
        private readonly bool reversed;


        public PriorityQueue(bool reversed = false)
        {
            data = new List<T>();
            this.reversed = reversed;
        }


        public void Enqueue(T item)
        {
            data.Add(item);


            var ci = data.Count - 1; // child index
            while (ci > 0)
            {
                var pi = (ci - 1) / 2; // parent index


                var compared = data[ci].CompareTo(data[pi]);
                if (!reversed && compared >= 0 || reversed && compared < 0)
                    break; // child item is larger than (or equal) parent so we're done


                Swap(ci, pi);


                ci = pi;
            }
        }


        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            var li = data.Count - 1; // last index (before removal)
            var frontItem = data[0]; // fetch the front
            data[0] = data[li];
            data.RemoveAt(li);


            li--; // last index (after removal)
            var pi = 0; // parent index. start at front of pq
            while (true)
            {
                var ci = pi * 2 + 1; // left child index of parent
                if (ci > li) break; // no children so done


                var rc = ci + 1; // right child                
                if (rc <= li &&
                    (!reversed && data[rc].CompareTo(data[ci]) < 0 || reversed && data[rc].CompareTo(data[ci]) >= 0)) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                    ci = rc;


                var comparedPi = data[pi].CompareTo(data[ci]);
                if (!reversed && comparedPi <= 0 || reversed && comparedPi > 0)
                    break; // parent is smaller than (or equal to) smallest child so done


                Swap(pi, ci); // swap parent and child


                pi = ci;
            }


            return frontItem;
        }


        public T Peek() => data[0];


        public bool Contains(T elem) => data.Contains(elem);


        public PriorityQueue<T> Reverse()
        {
            var reversedQueue = new PriorityQueue<T>(true);
            foreach (var elem in data)
                reversedQueue.Enqueue(elem);


            return reversedQueue;
        }


        public int Size() => data.Count;


        public IEnumerator<T> GetEnumerator() => data.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();


        public void Print() => Console.WriteLine(ToString());


        public override string ToString()
        {
            var s = default(string);


            foreach (var elem in data)
                s += elem + " ";


            return s;
        }


        private void Swap(int firstIndex, int secondIndex)
        {
            var tmp = data[firstIndex];
            data[firstIndex] = data[secondIndex];
            data[secondIndex] = tmp;
        }
    }
}