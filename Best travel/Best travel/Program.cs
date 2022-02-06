using System;
using System.Collections.Generic;
using System.Linq;

namespace Best_travel
{
    public static class SumOfK
    {
        class Town
        {
            Town previousTown;
            List<Town> availableTownsToVisit;
            int townsLeftToVisit;

            public int? maxAvailableDistance { get; private set; } = null;
            int distanceCovered;
            static int maxPossibleDistance;

            private Town(Town previousTown, int townsLeftToVisit, int distanceCovered)
            {
                this.previousTown = previousTown;
                this.townsLeftToVisit = townsLeftToVisit;
                this.distanceCovered = distanceCovered;
                availableTownsToVisit = new List<Town>();
            }

            public Town(Town previousTown, List<int> distancesToAvailableTowns, int townsLeftToVisit, int distanceCovered, int maxDistanceToCover)
                : this(previousTown, townsLeftToVisit, distanceCovered)
            {
                Town.maxPossibleDistance = maxDistanceToCover;
                AddAvailableTowns(distancesToAvailableTowns);
            }

            void AddAvailableTowns(List<int> distancesToAvailableTowns)
            {
                if (townsLeftToVisit == 0)
                {
                    EvaluateMaxDistanceCovered();
                    return;
                }

                int index = 1;
                foreach(var item in distancesToAvailableTowns)
                {
                    Town available = new Town(this, townsLeftToVisit - 1, distanceCovered + item);
                    availableTownsToVisit.Add(available);
                    available.AddAvailableTowns(distancesToAvailableTowns.GetRange(index, distancesToAvailableTowns.Count - index));
                    index++;
                }

                EvaluateMaxDistanceCovered();
            }

            void EvaluateMaxDistanceCovered()
            { 
                if (distanceCovered > Town.maxPossibleDistance) return;

                if (availableTownsToVisit.Count == 0)
                {
                    if (townsLeftToVisit == 0) maxAvailableDistance = distanceCovered;
                    return;
                }

                foreach(var item in availableTownsToVisit)
                {
                    if (item.maxAvailableDistance == null) continue;

                    maxAvailableDistance = (maxAvailableDistance > item.maxAvailableDistance) ? maxAvailableDistance : item.maxAvailableDistance;
                }
            }
        }

        //return null if no ways to get pathway < t and k
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            Town town = new Town(null, ls, k, 0, t);
            return town.maxAvailableDistance;
        }
    }

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
