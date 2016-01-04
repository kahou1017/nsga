using System;

namespace MOCSPTW
{
    public class Fitness
    {
        /// <summary>
        /// true  if all the objs of _individual1 are the best against _individual2) 
        /// false if all the objs of _individual2 are the best against _individual1)  
        ///          or _individual1 and _individual2 are rival eath other ()
        /// </summary>
        /// <param name="objective_types"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool Dominates(ObjectiveType[] objective_types, Individual p, Individual q)
        {
            if (p.Objectives.Length != q.Objectives.Length)
                throw new ArgumentException("both two object length not equal");

            int number_of_objs = p.Objectives.Length;

            int flag = 0;

            for (int i = 0; i < number_of_objs; i++)
            {
                // once p meet the condition that q is better than p
                // Fitness.ObjectiveType.Min,
                switch (objective_types[i])
                {
                    case ObjectiveType.Max:
                        if (p.Objectives[i] < q.Objectives[i])
                            return false;
                        break;
                    case ObjectiveType.Min:
                        if (p.Objectives[i] > q.Objectives[i])
                            return false;
                        break;
                }
            }

            return true;
        }
    }
}
