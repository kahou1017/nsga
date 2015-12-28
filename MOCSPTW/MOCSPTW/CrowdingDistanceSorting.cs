using System;
using System.Collections.Generic;

namespace MOCSPTW
{
    class CrowdingDistanceSorting 
    {
        public void CDSA(List<Individual> I)
        {
            foreach (Individual p in I)
            {
                p.distance = 0;
            }

            for (int g = 0; g < Constants._ObjectiveTypes.Length; g++)
            {
                I = Util.QuickSort(I, g, 0, I.Count - 1);
                Console.WriteLine("Object " + (g + 1) + "'s sorting");
                for (int i = 0; i < I.Count; i++)
                {

                    Console.WriteLine("Solution {0,2}: {1,3},{2,3}", (i+1), I[i].Objectives[0], I[i].Objectives[1]);

                }
                I[0].distance = Constants.FMAX;
                I[I.Count - 1].distance = Constants.FMAX;
                for (int i = 1; i < I.Count - 1; i++)
                {
                    I[i].distance = Math.Round(I[i].distance + (I[i + 1].Objectives[g] - I[i - 1].Objectives[g]) / (6 - 0),2);
                    Console.WriteLine("I{0}.distance = {1,5}, solution: {2,3},{3,3}", i+1, I[i].distance, I[i].Objectives[0], I[i].Objectives[1]);
                }
                Console.WriteLine("--------------------");
            }
        }
    }
}
