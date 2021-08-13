using System;
using System.Collections.Generic;

namespace Interval_List_Intersections
{
    class Program
    {
        static void Main(string[] args)
        {
            //var firstList = new int[4][] { new int[] { 0, 2 }, new int[] { 5, 10 }, new int[] { 13, 23 }, new int[] { 24, 25 } };
            //var secondList = new int[4][] { new int[] { 1, 5 }, new int[] { 8, 12 }, new int[] { 15, 24 }, new int[] { 25, 26 } };
            var firstList = new int[3][] { new int[] { 1, 3 }, new int[] { 5, 6 }, new int[] { 7, 9 } };
            var secondList = new int[2][] { new int[] { 2, 3 }, new int[] { 5, 7 }};
            Program p = new Program();
            var result = p.IntervalIntersection_Improved(firstList, secondList);
            foreach (var res in result)
                Console.WriteLine(string.Join(",", res));
        }


        // complexity O(n2)
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> result = new List<int[]>();
            if (firstList.Length == 0 || secondList.Length == 0) return result.ToArray();
            if (secondList.Length > firstList.Length)
                IntervalIntersection(secondList, firstList);
            foreach(var fInterval in firstList)
            {
                int fStart = fInterval[0];
                int fEnd = fInterval[1];
                foreach (var sInterval in secondList)
                {
                    int sStart = sInterval[0];
                    int sEnd = sInterval[1];
                    if ((sStart >= fStart && sStart <= fEnd) || (fStart >= sStart && fStart <= sEnd))
                        result.Add(new int[] { Math.Max(fStart, sStart), Math.Min(fEnd, sEnd) });
                    else 
                    {
                        if (fStart == sEnd) result.Add(new int[] { fStart, fStart });
                        if(fEnd == sStart) result.Add(new int[] { fEnd, fEnd });
                    };
                }
            }

            return result.ToArray();
        }

        // complexity - O(n+m)
        public int[][] IntervalIntersection_Improved(int[][] firstList, int[][] secondList)
        {
            List<int[]> result = new List<int[]>();
            int n = firstList.Length, m = secondList.Length;
            if (n == 0 || m == 0)
                return result.ToArray();
            int i = 0, j = 0;
            while (i < n && j < m)
            {
                int startMax = Math.Max(firstList[i][0], secondList[j][0]);
                int endMin = Math.Min(firstList[i][1], secondList[j][1]);

                if (endMin >= startMax) result.Add(new int[] { startMax, endMin });
                if (endMin == firstList[i][1]) i++;
                if (endMin == secondList[j][1]) j++;
            }

            return result.ToArray();
        }
    }
}
