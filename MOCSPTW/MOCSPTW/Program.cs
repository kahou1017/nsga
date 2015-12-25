using System;
using System.Collections.Generic;
using System.Threading;

namespace MOCSPTW
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Individual> _individualArray = new List<Individual>(Constants.POP_SIZE);

            Console.SetBufferSize(120, 5000);

            int number_of_objectives = 10;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Individual _individual1 = new Individual(rand);

            _individual1.SetObjectiveValues(new double[] { 10.2, 1.12, 95.87 });

            Individual _individual2 = new Individual(rand);

            _individual2.SetObjectiveValues(new double[] { 210.99, 12.57, 58.12 });


            // true  if _individual1 Dominates _individual2
            // false if _individual2 Dominates _individual1
            bool results = Fitness.Dominates(
                new ObjectiveType[]
                {
                    ObjectiveType.Min,
                    ObjectiveType.Min,
                    ObjectiveType.Max
                },
                _individual1,
                _individual2
            );

            Console.WriteLine("======================================================================");


            /*
            for (int i = 0; i < Constants.POP_SIZE; i++)
            {
                Individual _individual = new Individual(rand, number_of_objectives);

                _individual.SetObjectiveValues(new double[] { 10.2, 223.12, 95.87});

                _individual.point_x = rand.Next(0, 100);
                _individual.point_y = rand.Next(0, 100) ;
                _individualArray.Add(_individual);
                Console.WriteLine("Number of individual " + i);
                Console.WriteLine("DNA = " + _individual.DNA);
                Console.WriteLine("point_X = " + _individual.point_x);
                Console.WriteLine("point_Y = " + _individual.point_y);
                Console.WriteLine("======================================================================");
            }

            new Thread(()=> Simulation(_individualArray)).Start();

            //Thread sim = new Thread(new ParameterizedThreadStart(Simulation));
            //sim.Start(oArray);
            */

        }

        private static void Simulation(object P)
        {

            List<Individual> parent = (List<Individual>)P;

            for (int i = 0; i < Constants.MAX_GENERATIONS; i++)
            {
                List<Individual> roster = new List<Individual>();
                List<Individual> nexGen = new List<Individual>();
                //make pop
                //roster.AddRange(Q);
                roster.AddRange(parent);

                List<List<Individual>> fronts = new NonDominatedSorting().FastNSA(roster);

                while (nexGen.Count + fronts.Count >= Constants.POP_SIZE)
                {

                }

            }

        }
    }
}
