using System;
using System.Collections.Generic;

namespace MOCSPTW
{
    public class Individual
    {
        public Individual(Random rand)
        {
            DNA = rand.Next();

            
        }


        public void SetObjectiveValues(double[] values)
        {
            Objectives = values;
        }


        public int DNA;
        //public double point_x;
        //public double point_y;
        public double[] Objectives;

        public List<Individual> pDom = new List<Individual>(); // contain all the individuals that is being dominated by p.
        public int nDom = 0; //number of individuals that dominated p.
        public double distance = 0;
        public List<int> m = new List<int>(); // mth objective function

        public Individual CompareTo(Individual p, Individual q, int i)
        {
            if (p.m[i] > q.m[i])
                return p;
            else
                return q;
        }
    }
}
