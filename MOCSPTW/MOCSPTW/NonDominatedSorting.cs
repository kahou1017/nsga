using System.Collections.Generic;

namespace MOCSPTW
{
    public class NonDominatedSorting
    {
        public List<List<Individual>> FastNSA(List<Individual> populations)
        {
            List<List<Individual>> fronts = new List<List<Individual>>();

            foreach (Individual p in populations)
            {
                fronts.Add(new List<Individual>());

                foreach (Individual q in populations)
                {
                    if (Fitness.Dominates(p, q))  //check if p dominates q
                    {
                        p.pDom.Add(q); //true; add q to solutions p dominates
                    }
                    else if(Fitness.Dominates(q, p))
                    {
                        p.nDom++;  //false; add 1 to count organisms that dominate p
                    }
                }

                if (p.nDom == 0) //true; p belongs to the "First Front"
                {
                    fronts[0].Add(p);
                }
            }

            int i = 0;

            while (fronts[i].Count != 0) //while the front still has members
            {
                List<Individual> Q = new List<Individual>();
                foreach (Individual p in fronts[i])
                {
                    foreach (Individual q in p.pDom)
                    {
                        q.nDom--;

                        if (q.nDom == 0) //p belongs to next front
                        {
                            Q.Add(q);
                        }
                    }
                }

                i++;
                fronts.Add(new List<Individual>());
                fronts[i] = Q;
            }

            return fronts;
        }
    }
}