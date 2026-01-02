using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class FEFOCollection<T> where T : IExpired
    {
        private class Node
        {
            private Node next;
            private Node prev;
            private T data { get; set; }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public Node Prev
            {
                get { return prev; }
                set { prev = value; }
            }
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
            public Node(T t)
            {
                next = null;
                prev = null;
                data = t;
            }
        }
        private Node head;
        private Node tail;
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public FEFOCollection()
        {
            head = null;
            tail = null;
        }
        public bool Add(T t)
        {
            if (t.GetExpireDays() <= 0)
                return false;
            Node new_node = new Node(t);
            if (head == null)
            {
                head = new_node;
                tail = new_node;
            }
            else
            {
                Node current = head;
                while (current != null && current.Data.GetExpireDays() <= t.GetExpireDays())
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    tail.Next = new_node;
                    new_node.Prev = tail;
                    tail = new_node;
                }
                else if (current == head)
                {
                    new_node.Next = head;
                    head.Prev = new_node;
                    head = new_node;
                }
                else
                {
                    new_node.Next = current;
                    new_node.Prev = current.Prev;
                    current.Prev.Next = new_node;
                    current.Prev = new_node;
                }
            }
            count++;
            return true;
        }
        public T PopBad()
        {
            if (head == null) return default(T);
            Node node = head;
            Node next_node = node.Next;
            head = next_node;
            if (head != null)
            {
                next_node.Prev = null;
            }
            else
            {
                tail = null;
            }
            count--;
            return node.Data;
        }
        public T PopFresh()
        {
            if (tail == null) return default(T);
            Node node = tail;
            Node prev_node = node.Prev;
            tail = prev_node;
            if (tail != null)
            {
                prev_node.Next = null;
            }
            else
            {
                head = null;
            }
            count--;
            return node.Data;
        }
    }
}
