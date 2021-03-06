﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerTest
{
    class SeqList<T>:IListDS<T>
    {
        private int maxsize;//顺序表的容量
        private T[] data;//数组，用于存储顺序表中的数据元素
        private int last;//只是顺序表最后一个元素的位置，即元素在数组中的索引
        //索引器
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        //最后一个数据元素位置属性
        public int Last
        {
            get { return last; }
        }
        //容量属性
        public int Maxsize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }
        //构造器
        public SeqList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }
        //求顺序表的长度
        public int GetLength()
        {
            return last + 1;
        }
        //清空顺序表
        public void Clear()
        {
            last = -1;
        }
        //判断顺序表是否为空
        public bool IsEmpty()
        {
            if (last == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //判断顺序表是否为满
        public bool IsFull()
        {
            if (last == maxsize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //在顺序表的末尾添加新元素
        public void Append(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
            }
            data[++last] = item;
        }
        //在顺序表的第i个数据元素的位置插入一个数据元素
        public void Insert(T item, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
                return;
            }
            if (i < 1 || i > last + 2)
            {
                Console.WriteLine("Position is error!");
                return;
            }
            if (i == last + 2)
            {
                data[last + 1] = item;
            }
            else
            {
                for (int j = last; j >= i - 1; --j)
                {
                    data[j + 1] = data[j];
                }
                data[i - 1] = item;
            }
            ++last;
        }
        //删除顺序表的第i个数据元素
        public T Delete(int i)
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return tmp;
            }
            if (i < 1 || i > last + 1)
            {
                Console.WriteLine("Position is error!");
                return tmp;
            }
            if (i == last + 1)
            {
                tmp = data[last--];
                return tmp;
            }
            else 
            {
                tmp = data[i - 1];
                //陈有才修改
                for (int j = i-1; j < last; ++j)
                {
                    data[j] = data[j + 1];
                }
            }
            --last;
            return tmp;
        }
        //获得顺序表的第i个数据元素
        public T GetElem(int i)
        {
            if(IsEmpty()||(i<1)||(i>last+1))
            {
                Console.WriteLine("List is empty oe Position is error!");
                return default(T);
            }
            return data[i-1];
        }
        //在顺序表中查找值为value的数据元素
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty!");
                return -1;
            }
            int i = 0;
            for (i = 0; i <= last; ++i)
            {
                if (value.Equals(data[i]))
                {
                    break;
                }
            }
            if (i > last)
            {
                return -1;
            }
            return i;
        }

        public void Reverse()
        {
            T tmp = default(T);
            int len = GetLength();
            for (int i = 0; i < len / 2; ++i)
            {
                tmp = data[i];
                data[i] = data[len - i - 1];
                data[len - i - 1] = tmp;
            }
        }
    }
}
