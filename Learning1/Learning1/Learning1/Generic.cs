//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Learning1
//{
//    public class Generic<T> : IEnumerable<T>
//    {
//        protected Node head;
//        protected Node current;


//        protected class Node
//        {
//            public Node next;
//            private T data;

//            public Node(T t)
//            {
//                next = null;
//                data = t;
//            }

//            public Node Next
//            {
//                get { return next; }
//                set { next = value; }
//            }

//            public T Data
//            {
//                get { return data; }
//                set { data = value; }
//            }
//        }
//        public Generic()
//        {
//            head = null;

//        }
//        public void AddHead(T t)
//        {
//            Node n = new Node(t);
//            n.next = head;
//            head = n;
//        }
//        public IEnumerator<T> GetEnumerator()
//        {
//            Node current = head;
//            while (current != null)
//            {
//                yield return current.Data;
//                current = current.next;
//            }

//        }


//        IEnumerator IEnumerable.GetEnumerator()
//        {

//            return GetEnumerator();
//        }
//    }

//    public class SortedList<T> : Generic<T> where T : IComparable<T>
//    {
//        public void BubbleSort()
//        {
//            if (null == head || null == head.Next) return;
//            bool swapped;

//            do
//            {
//                Node previous = null;
//                Node current = head;
//                swapped = false;

//                while (current.next != null)
//                {
//                    //  Because we need to call this method, the SortedList
//                    //  class is constrained on IEnumerable<T>
//                    if (current.Data.CompareTo(current.next.Data) > 0)
//                    {
//                        Node tmp = current.next;
//                        current.next = current.next.next;
//                        tmp.next = current;

//                        if (previous == null)
//                        {
//                            head = tmp;
//                        }
//                        else
//                        {
//                            previous.next = tmp;
//                        }
//                        previous = tmp;
//                        swapped = true;
//                    }
//                    else
//                    {
//                        previous = current;
//                        current = current.next;
//                    }
//                }
//            } while (swapped);


//        }
//    }
//}

