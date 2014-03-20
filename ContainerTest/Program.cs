using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContainerT;

namespace ContainerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SeqList<int> example = new SeqList<int>(8);
            example.Append(11);
            example.Append(23);
            example.Append(36);
            example.Append(45);
            example.Append(80);
            example.Append(60);
            example.Append(40);
            ReversSeqList(example);
            for (int i = 0; i < example.GetLength(); i++)
            {
                Console.WriteLine(example[i]);
            }
            Console.ReadLine();
        }

        public static void ReversSeqList(SeqList<int> L)
        {
            int tmp = 0;
            int len = L.GetLength();
            for (int i = 0; i < len / 2; ++i)
            {
                tmp = L[i];
                L[i] = L[len - i-1];
                L[len - i-1] = tmp;
            }
        } 
      
        public static SeqList<int> Merge(SeqList<int> La,SeqList<int> Lb)
       {
           SeqList<int> Lc = new SeqList<int>(La.Maxsize + Lb.Maxsize);
           int i = 0;
           int j = 0;
           int k = 0;
           while ((i <= (La.GetLength() - 1)) && (j <= (Lb.GetLength() - 1)))
           {
               if (La[i] < Lb[j])
               {
                   Lc.Append(La[i++]);
               }
               else
               {
                   Lc.Append(Lb[j++]);
               }
           }

           while (i <= (La.GetLength() - 1))
           {
               Lc.Append(La[i++]);
           }

           while (j <= (Lb.GetLength() - 1))
           {
               Lc.Append(Lb[j++]);
           }
           return Lc;
       }

        public static SeqList<int> Purge(SeqList<int> La)
        {
            SeqList<int> Lb = new SeqList<int>(La.Maxsize);
            Lb.Append(La[0]);
            for (int i = 1; i <= (La.GetLength() - 1); i++)
            {
                int j = 0;
                for (j = 0; j <= (Lb.GetLength() - 1); j++)
                {
                    if (La[i].CompareTo(Lb[j]) == 0)
                    {
                        break;
                    }
                }
                if (j > (Lb.GetLength() - 1))
                {
                    Lb.Append(La[i]);
                }
            }
            return Lb;
        }
    }
}
