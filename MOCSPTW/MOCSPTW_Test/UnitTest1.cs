using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MOCSPTW_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
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
        }
    }
}
