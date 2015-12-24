using System;

namespace MOCSPTW
{
    class Fitness
    {
        public enum ObjectiveType
        {
            Max, Min
        }

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
            if (p.Objectives.Length != q.Objectives.Length) throw new ArgumentException();

            int number_of_objs = p.Objectives.Length;

            for (int i = 0; i < number_of_objs; i++)
            {
                // once p meet the condition that q is better than p
                // Fitness.ObjectiveType.Min,
                if (objective_types[i] == ObjectiveType.Max)
                {
                    // Objectives[i] 大才是好
                }
                else if(objective_types[i] == ObjectiveType.Min)
                {
                    // Objectives[i] 小才是好
                }

            }



            return false;
        }

        //public static Individual CompareTwo


        public static bool Dominates(Individual p, Individual q)
        {
            double p_distance = Math.Sqrt(Math.Pow(p.point_x - 0, 2) + Math.Pow(p.point_y - 0, 2));
            double q_distance = Math.Sqrt(Math.Pow(q.point_x - 0, 2) + Math.Pow(q.point_y - 0, 2));

            if (p_distance < q_distance)
                return true;
            else
                return false;
        }
    }
}
