using System.Collections.Generic;
using System.Linq;

namespace MOCSPTW
{
    public class NonDominatedSorting
    {
        public List<List<Individual>> FastNSA(List<Individual> populations)
        {
            List<List<Individual>> fronts = new List<List<Individual>>();
            

            foreach (Individual p in populations)
            {
                foreach (Individual q in populations)
                {
                    if (p.Objectives != q.Objectives)
                    {
                        if (Fitness.Dominates(Constants._ObjectiveTypes, p, q)) //check if p dominates q
                        {
                            p.pDom.Add(q); //true; add q to solutions p dominates
                        }
                        else if (Fitness.Dominates(Constants._ObjectiveTypes, q, p))
                        {
                            p.nDom++;  //false; add 1 to count organisms that dominate p
                        }
                    }
                }

                if (p.nDom == 0) //true; p belongs to the "First Front"
                {
                    p.rank = 1;
                    fronts.Add(new List<Individual>());
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
                fronts[i].AddRange(Q);
            }

            return fronts;
        }
    }
}