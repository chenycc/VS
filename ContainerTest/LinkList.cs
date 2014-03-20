using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerTest
{
    class LinkList<T>:IListDS<T>
    {
        private Node<T> head;//单链表的头引用
        //头引用属性
        public Node<T> Head
        {
            get {
                return head;
            }
            set {
                head = value;
            }
        }
        //构造器
        public LinkList()
        {
            head = null;
        }
        //求单链表长度
        public int GetLength()
        {
            Node<T> p = head;
            int len = 0;
            while (p != null)
            {
                ++len;
                p = p.Next;
            }
            return len;
        }
        //情况单链表
        public void Clear()
        {
            head = null;
        }
        //判断单链表是否为空
        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //在单链表的末尾添加新元素
        public void Append(T item)
        {
            Node<T> q = new Node<T>(item);
            Node<T> p = new Node<T>();
            if (head == null)
            {
                head = q;
                return;
            }
            p = head;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = q;
        }
        //在单链表的第i个结点的位置前插入一个值为item的结点
        public void Insert(T item, int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("List is empty or Position is error!");
                return;
            }
            if (i == 1)
            {
                Node<T> q = new Node<T>(item);
                q.Next = head;
                head = q;
                return;
            }
            Node<T> p = head;
            Node<T> r = new Node<T>();
            int j = 1;
            while (p.Next != null && j < i)
            {
                r = p;
                p = p.Next;
                ++j;
            }
            if (j == i)
            {
                 Node<T> q = new Node<T>(item);
                 q.Next = p;
                 r.Next = q;
            }
        }
        //在单链表的第i个结点的位置后插入一个值为item的结点
        public void InsertPost(T item, int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("List is empty or Position is error!");
                return;
            }

            if (i == 1)
            {
                Node<T> newNode = new Node<T>(item);
                newNode.Next = head.Next;
                head.Next = newNode;
                return;
            }
            Node<T> h = head;
            int j = 1;
            while (h.Next != null && j < i)
            {
                h = h.Next;
                ++j;
            }
            if (j == i)
            {
                Node<T> newNode = new Node<T>(item);
                newNode.Next = h.Next;
                h.Next = newNode;
            }
        }

        //删除单链表的第i个结点
        public T Delete(int i)
        {
            if (IsEmpty() && i < 0)
            {
                Console.WriteLine("Link is empty or Position is error！");
                return default(T);
            }
            Node<T> node = new Node<T>();
            if (i == 1)
            {
                node = head;
                head = head.Next;
                return node.Data;
            }

            Node<T> h = head;
            int j = 1;
            while (h.Next != null && j < i)
            {
                node = h;
                h = h.Next;
                ++j;
            }
            if (j == i)
            {
                node.Next = h.Next;
                return h.Data;
            }
            else
            {
                Console.WriteLine("The ith node is not exist!");
                return default(T);
            }
        }
        //获得单链表的第i个数据元素
        public T GetElem(int i)
        {
            if(IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return default(T);
            }
            Node<T> h=head;
            int j=1;
            while (h.Next != null && j < i)
            {
                h = h.Next;
                ++j;
            }
            if (j == i)
            {
                return h.Data;
            }
            else
            {
                Console.WriteLine("The ith node is not exist!");
                return default(T);
            }
        }
        //在单链表中查找值为value的结点
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty!");
                return -1;
            }
            Node<T> p = head;
            int i = 1;
            while (!p.Data.Equals(value) && p.Next != null)
            {
                p = p.Next;
                i++;
            }
            return i;
        }
    }
}
