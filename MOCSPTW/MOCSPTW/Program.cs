﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace MOCSPTW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Individual> _individualArray = new List<Individual>(Constants.POP_SIZE);

            Console.SetBufferSize(120, 5000);

            for (int i = 0; i < Constants.POP_SIZE; i++)
            {
                Individual _individual = new Individual();
                Random rand = new Random(Guid.NewGuid().GetHashCode());
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
