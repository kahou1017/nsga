using System.Collections.Generic;

namespace MOCSPTW
{
    class CrowdingDistanceSorting 
    {
        public void CRSA(List<Individual> I)
        {
            foreach (Individual p in I)
            {
                p.distance = 0;
            }

            for (int g = 0; g < I[0].m.Count; g++)
            {
                I.Sort();
                for (int i = 1; i < I.Count - 1; i++)
                {
                    I[i].distance = I[i].distance + (I[i - 1].distance - I[i + 1].distance) / (Constants.FMAX - Constants.FMIN);
                }
            }
        }
    }
}
