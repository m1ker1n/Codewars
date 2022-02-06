using System;
using System.Collections.Generic;

namespace Square_into_Squares._Protect_trees_
{

    static public class Decompose
    {
        static public List<long> list = new List<long>();
        static public long decomposeRecursive(long left, long prevIndex)
        {
            if (left < 0) return -1; // too much for previous index
            if (prevIndex <= 0) return -1; // no more indexes to iterate
            if (left == 0)
            {
                list.Add(prevIndex);
                return prevIndex; //found solution
            }

            for (long i = prevIndex - 1; i > 0; i--) 
            {
                if (decomposeRecursive(left - i * i, i) != -1)
                {
                    list.Add(prevIndex);  //found solution
                    return prevIndex;
                }
            }

            return -1;
        }

        static public string decompose(long n)
        {
            decomposeRecursive(n * n, n);

            if (list.Count == 0) return "Nothing";

            string result = "";
            list.Remove(n);
            foreach (var item in list)
            {
                result += item;
                result += ' ';
            }
            result = result.Trim();
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Decompose.decompose(11));
        }
    }
}
