using System;
using System.Collections.Generic;
using System.Threading;

namespace MOCSPTW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Individual> _individualArray = new List<Individual>(Constants.POP_SIZE);

            Console.SetBufferSize(100, 5000);

            int number_of_objectives = 10;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Individual _individual1 = new Individual(rand);
            Individual _individual2 = new Individual(rand);
            Individual _individual3 = new Individual(rand);
            Individual _individual4 = new Individual(rand);
            Individual _individual5 = new Individual(rand);
            Individual _individual6 = new Individual(rand);
            Individual _individual7 = new Individual(rand);
            Individual _individual8 = new Individual(rand);
            Individual _individual9 = new Individual(rand);
            Individual _individual10 = new Individual(rand);
            Individual _individual11 = new Individual(rand);
            Individual _individual12 = new Individual(rand);
            Individual _individual13 = new Individual(rand);
            Individual _individual14 = new Individual(rand);
            Individual _individual15 = new Individual(rand);

            _individual1.SetObjectiveValues(new double[] { 1, 5 });
            _individual2.SetObjectiveValues(new double[] { 1.5, 4 });
            _individual3.SetObjectiveValues(new double[] { 2, 3 });
            _individual4.SetObjectiveValues(new double[] { 2.5, 1 });
            _individual5.SetObjectiveValues(new double[] { 4, 0.5 });
            _individual6.SetObjectiveValues(new double[] { 6, 0.5 });
            _individual7.SetObjectiveValues(new double[] { 2.5, 4 });
            _individual8.SetObjectiveValues(new double[] { 3, 3 });
            _individual9.SetObjectiveValues(new double[] { 4, 2 });
            _individual10.SetObjectiveValues(new double[] { 4.5, 1.5 });
            _individual11.SetObjectiveValues(new double[] { 3, 3.5 });
            _individual12.SetObjectiveValues(new double[] { 3.5, 3 });
            _individual13.SetObjectiveValues(new double[] { 2, 5 });
            _individual14.SetObjectiveValues(new double[] { 5, 4 });
            _individual15.SetObjectiveValues(new double[] { 6, 3 });

            _individualArray.Add(_individual1);
            _individualArray.Add(_individual2);
            _individualArray.Add(_individual3);
            _individualArray.Add(_individual4);
            _individualArray.Add(_individual5);
            _individualArray.Add(_individual6);
            _individualArray.Add(_individual7);
            _individualArray.Add(_individual8);
            _individualArray.Add(_individual9);
            _individualArray.Add(_individual10);
            _individualArray.Add(_individual11);
            _individualArray.Add(_individual12);
            _individualArray.Add(_individual13);
            _individualArray.Add(_individual14);
            _individualArray.Add(_individual15);

            ObjectiveType[] _ObjectiveTypes = {
                ObjectiveType.Min,
                ObjectiveType.Min
            };

            List<List<Individual>> fronts = new Util().FastNSA(_ObjectiveTypes, _individualArray);

            Console.WriteLine("========================================");
            Console.WriteLine("====== Fast Non-Dominated Sorting ======");
            Console.WriteLine("========================================");

            for (int i = 0; i < fronts.Count; i++)
            {
                if (fronts[i].Count != 0)
                {
                    Console.WriteLine("====== Front Level: " + (i + 1) + " ======");
                    for (int j = 0; j < fronts[i].Count; j++)
                    {
                        Console.WriteLine("Solution: {0,3},{1,3}", fronts[i][j].Objectives[0], fronts[i][j].Objectives[1]);
                    }
                    Console.WriteLine("This Front " + (i + 1) + " Have " + fronts[i].Count + " Solutions");
                }
            }

            Console.WriteLine("=======================================");
            Console.WriteLine("====== Crowding Distance Sorting ======");
            Console.WriteLine("=======================================");

            for (int i = 0; i < fronts.Count; i++)
            {
                if (fronts[i].Count != 0)
                {
                    Console.WriteLine("front " + (i+1) + " sorting");
                    //new CrowdingDistanceSorting().CrowdingDistanceAssignment(_ObjectiveTypes, fronts[i]);
                    //List<Individual> I = new CrowdingDistanceSorting().DescendSort(fronts[i], 0, fronts[i].Count - 1);
                    List<Individual> I = new Util().CDS(_ObjectiveTypes, fronts[i]);
                    Console.WriteLine("====================");
                }
            }

            Console.WriteLine("======================================================================");
        }
    }
}
