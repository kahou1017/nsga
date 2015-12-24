using System;

namespace MOCSPTW
{
    class Fitness
    {
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
