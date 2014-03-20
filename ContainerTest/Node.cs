using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerTest
{
    class Node<T>
    {
        private T data;//数据域
        private Node<T> next;//引用域
        //构造器
        public Node(T val, Node<T> p)
        {
            data = val;
            next = p;
        }
        //头引用
        public Node(Node<T> p)
        {
            next = p;
        }
        //结尾
        public Node(T val)
        {
            data = val;
            next = null;
        }

        public Node()
        {
            data = default(T);
            next=null;
        }

        public T Data { 
           get{
               return data;
           }
            set {
                data = value;
            }
        }

        public Node<T> Next {
            get {
                return next;
            }
            set {
                next = value;
            }
        }

    }
}
