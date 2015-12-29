using System;
using System.Collections.Generic;

namespace MOCSPTW
{
    class CrowdingDistanceSorting 
    {
        /// <summary>
        /// Crowding Distance Assignment
        /// </summary>
        /// <param name="objective_types"></param>
        /// <param name="I"></param>
        public void CrowdingDistanceAssignment(ObjectiveType[] objective_types, List<Individual> I)
        {
            foreach (Individual p in I)
            {
                p.distance = 0;
            }

            for (int g = 0; g < objective_types.Length; g++)
            {
                I = Util.QuickSort(I, g, 0, I.Count - 1);
                Console.WriteLine("Object " + (g + 1) + "'s sorting");
                for (int i = 0; i < I.Count; i++)
                {

                    Console.WriteLine("Solution {0,2}: {1,3},{2,3}", (i+1), I[i].Objectives[0], I[i].Objectives[1]);

                }
                I[0].distance = -1;
                I[I.Count - 1].distance = -1;

                for (int i = 1; i < I.Count - 1; i++)
                {
                    I[i].distance = Math.Round(I[i].distance + (I[i + 1].Objectives[g] - I[i - 1].Objectives[g]) / (I[I.Count - 1].Objectives[g] - I[0].Objectives[g]),2);
                    Console.WriteLine("I{0}.distance = {1,5}, solution: {2,3},{3,3}", i+1, I[i].distance, I[i].Objectives[0], I[i].Objectives[1]);
                }
                Console.WriteLine("--------------------");
            }
        }

        public List<Individual> DescendSort(List<Individual> _individualArray, int left, int right)
        {
            if (right <= left)
                return _individualArray;

            int pivotIndex = (left + right) / 2;
            Individual pivot = _individualArray[pivotIndex];
            Util.Swap(_individualArray, pivotIndex, right);
            int swapIndex = left;
            for (int i = left; i < right; ++i)
            {
                if (_individualArray[i].rank < pivot.rank || ((_individualArray[i].rank == pivot.rank) && (_individualArray[i].distance >= pivot.distance)))
                {
                    Util.Swap(_individualArray, i, swapIndex);
                    ++swapIndex;
                }
            }
            Util.Swap(_individualArray, swapIndex, right);

            DescendSort(_individualArray, left, swapIndex - 1);
            DescendSort(_individualArray, swapIndex + 1, right);

            return _individualArray;
        }

        public List<Individual> CDS(ObjectiveType[] objective_types, List<Individual> I)
        {
            List<Individual> results = new List<Individual>();
            CrowdingDistanceAssignment(objective_types, I);
            results = DescendSort(I, 0, I.Count - 1);
            return results;
        }
    }
}
