using System;
using System.Collections.Generic;

namespace Best_travel
{

    #region [Recursive algorithm. Too slow, but suppose works]
    /*
    public static class SumOfK
    {
        private static List<int> attended = new List<int>();

        //return null if no ways to get pathway < t and k
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            if (k > ls.Count) return null; //if i need visit more towns than possible, must be checked only once
            if (t < 0) return null;
            if (k == 0) return 0; //already visited max amount of towns

            int? max = -1; //max can't be negative, because every distance >= 0;

            foreach(var item in ls)
            {
                if (attended.Contains(item)) continue; //if town is attended, no need to come back

                attended.Add(item);
                int? temp = chooseBestSum(t - item, k - 1, ls);
                if (temp != null) max = (max > item + temp) ? max : item + temp;
                attended.Remove(item);
            }

            return (max == -1) ? null : max; //if max == -1 then there weren't any possible ways
        }
    }
    */
    #endregion

    #region [Trying do it another way another day]
    public static class SumOfK
    {
        private static List<int> attended = new List<int>();
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            return null;
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            List<int> ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            int? n = SumOfK.chooseBestSum(230, 3, ts);
            int? answer = 228;
            Console.WriteLine($"Expect: {answer}; What you get: {n}");
        }
    }
}
