using System;
using System.Collections.Generic;

namespace MOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Front front_solutions = new Front();

            //Console.SetBufferSize(100, 5000);

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
            Individual _individual16 = new Individual(rand);
            Individual _individual17 = new Individual(rand);
            Individual _individual18 = new Individual(rand);
            Individual _individual19 = new Individual(rand);
            Individual _individual20 = new Individual(rand);
            Individual _individual21 = new Individual(rand);
            Individual _individual22 = new Individual(rand);

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
            _individual16.SetObjectiveValues(new double[] { 0.5, 6 });
            _individual17.SetObjectiveValues(new double[] { 2, 6 });
            _individual18.SetObjectiveValues(new double[] { 3, 5 });
            _individual19.SetObjectiveValues(new double[] { 4.5, 2.5 });
            _individual20.SetObjectiveValues(new double[] { 5, 2 });
            _individual21.SetObjectiveValues(new double[] { 4, 5 });
            _individual22.SetObjectiveValues(new double[] {6, 4});

            front_solutions.Add(_individual1);
            front_solutions.Add(_individual2);
            front_solutions.Add(_individual3);
            front_solutions.Add(_individual4);
            front_solutions.Add(_individual5);
            front_solutions.Add(_individual6);
            front_solutions.Add(_individual7);
            front_solutions.Add(_individual8);
            front_solutions.Add(_individual9);
            front_solutions.Add(_individual10);
            front_solutions.Add(_individual11);
            front_solutions.Add(_individual12);
            front_solutions.Add(_individual13);
            front_solutions.Add(_individual14);
            front_solutions.Add(_individual15);
            front_solutions.Add(_individual16);
            front_solutions.Add(_individual17);
            front_solutions.Add(_individual18);
            front_solutions.Add(_individual19);
            front_solutions.Add(_individual20);
            front_solutions.Add(_individual21);
            front_solutions.Add(_individual22);

            // 設定期望目標的最大或最小
            ObjectiveType[] _ObjectiveTypes = {
                ObjectiveType.Min,
                ObjectiveType.Min
            };
            
            List<Front> fronts = new Utils().FastNonDominatedSorting(_ObjectiveTypes, front_solutions);

            Console.WriteLine("========================================");
            Console.WriteLine("====== Fast Non-Dominated Sorting ======");
            Console.WriteLine("========================================");

            for (int i = 0; i < fronts.Count; i++)
            {
                Console.WriteLine("====== Front Level: " + (i + 1) + " ======");
                for (int j = 0; j < fronts[i].Count; j++)
                {
                    Console.WriteLine("Solution: {0,3},{1,3}", fronts[i][j].Objectives[0], fronts[i][j].Objectives[1]);
                }
                Console.WriteLine("This Front " + (i + 1) + " Have " + fronts[i].Count + " Solutions");
            }

            Console.WriteLine("=======================================");
            Console.WriteLine("====== Crowding Distance Sorting ======");
            Console.WriteLine("=======================================");

            for (int i = 0; i < fronts.Count; i++)
            {
                List<Individual> I = new Utils().CrowdingDistanceSorting(_ObjectiveTypes, fronts[i]);
                Console.WriteLine("Front {0} Crowding Distance Sorting Results:", (i+1));
                for (int j = 0; j < I.Count; j++)
                {
                    Console.WriteLine("{0,3},{1,3}; distance: {2,10}", I[j].Objectives[0], I[j].Objectives[1], I[j].distance);
                }
                Console.WriteLine("====================");
            }

            Console.WriteLine("======================================================================");
        }
    }
}
