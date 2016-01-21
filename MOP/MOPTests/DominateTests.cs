using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MOP;

namespace MOP.Tests
{
    [TestClass()]
    public class DominateTests
    {
        [TestMethod()]
        public void Dominate_Example_One()
        {
            bool expected;
            bool actual;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Individual _individual1 = new Individual(rand);
            Individual _individual2 = new Individual(rand);

            _individual1.SetObjectiveValues(new double[] { 10.2, 1.12, 95.87 });
            _individual2.SetObjectiveValues(new double[] { 210.99, 12.57, 58.12 });
            expected = false;

            actual = Fitness.Dominates(
                new ObjectiveType[]
                {
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                },
                _individual1,
                _individual2
            );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Dominate_Example_Two()
        {
            bool expected;
            bool actual;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Individual _individual1 = new Individual(rand);
            Individual _individual2 = new Individual(rand);

            // individual1 dominates individual2
            _individual1.SetObjectiveValues(new double[] { 90, 85, 88, 92, 100 });
            _individual2.SetObjectiveValues(new double[] { 90, 85, 88, 92, 96 });
            expected = true;

            // true  if _individual1 Dominates _individual2
            // false if _individual2 Dominates _individual1
            actual = Fitness.Dominates(
                new ObjectiveType[]
                {
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                },
                _individual1,
                _individual2
            );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Dominate_Example_Three()
        {
            bool expected;
            bool actual;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Individual _individual1 = new Individual(rand);
            Individual _individual2 = new Individual(rand);

            // individual1 not dominates individual2, and individual2 also not dominates individual1
            _individual1.SetObjectiveValues(new double[] { 86, 100 });
            _individual2.SetObjectiveValues(new double[] { 90, 96 });
            expected = false;

            // true  if _individual1 Dominates _individual2
            // false if _individual2 Dominates _individual1
            actual = Fitness.Dominates(
                new ObjectiveType[]
                {
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                },
                _individual1,
                _individual2
            );

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Dominate_Example_Four()
        {
            bool expected;
            bool actual;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Individual _individual1 = new Individual(rand);
            Individual _individual2 = new Individual(rand);

            // individual1 not dominates individual2, and individual2 also not dominates individual1
            _individual1.SetObjectiveValues(new double[] { 86, 100, 98, 92, 73 });
            _individual2.SetObjectiveValues(new double[] { 80, 96, 88, 90, 100 });
            expected = false;

            // true  if _individual1 Dominates _individual2
            // false if _individual2 Dominates _individual1
            actual = Fitness.Dominates(
                new ObjectiveType[]
                {
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                    ObjectiveType.Max,
                },
                _individual1,
                _individual2
            );

            Assert.AreEqual(expected, actual);
        }

    }
}