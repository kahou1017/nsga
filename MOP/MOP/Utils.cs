﻿using System;
using System.Collections.Generic;

namespace MOP
{
    class Utils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_individualArray"></param>
        /// <param name="indexA"></param>
        /// <param name="indexB"></param>
        public static void Swap(Front _individualArray, int indexA, int indexB)
        {
            Individual temp = _individualArray[indexA];
            _individualArray[indexA] = _individualArray[indexB];
            _individualArray[indexB] = temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_individualArray"></param>
        /// <param name="num_obj"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Front QuickSort(Front _individualArray, ObjectiveType[] objective_types, int num_obj, int left, int right)
        {
            if (right <= left)
                return _individualArray;

            int pivotIndex = (left + right)/2;
            Individual pivot = _individualArray[pivotIndex];
            Swap(_individualArray, pivotIndex, right);
            int swapIndex = left;
            for (int i = left; i < right; ++i)
            {
                if (objective_types[num_obj] == ObjectiveType.Min)
                {
                    if (_individualArray[i].Objectives[num_obj] <= pivot.Objectives[num_obj])
                    {
                        Swap(_individualArray, i, swapIndex);
                        ++swapIndex;
                    }
                }
                else
                {
                    if (_individualArray[i].Objectives[num_obj] >= pivot.Objectives[num_obj])
                    {
                        Swap(_individualArray, i, swapIndex);
                        ++swapIndex;
                    }
                }
            }
            Swap(_individualArray, swapIndex, right);

            QuickSort(_individualArray, objective_types, num_obj,  left, swapIndex - 1);
            QuickSort(_individualArray, objective_types, num_obj, swapIndex + 1, right);

            return _individualArray;
        }

        /// <summary>
        /// Fast Non-Dominated Sorting;
        /// Use this function can sort solutions rank and level;
        /// </summary>
        /// <param name="objective_types"></param>
        /// <param name="solutions"></param>
        /// <returns></returns>
        public List<Front> FastNonDominatedSorting(ObjectiveType[] objective_types, Front solutions)
        {
            List<Front> fronts = new List<Front>();

            fronts.Add(new Front());

            foreach (Individual p in solutions)
            {
                foreach (Individual q in solutions)
                {
                    if (p.Objectives != q.Objectives)
                    {
                        if (Fitness.Dominates(objective_types, p, q)) //check if p dominates q
                        {
                            p.pDom.Add(q); //true; add q to solutions p dominates
                        }
                        else if (Fitness.Dominates(objective_types, q, p))
                        {
                            p.nDom++;  //false; add 1 to count organisms that dominate p
                        }
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
                Front Q = new Front();
                foreach (Individual p in fronts[i])
                {
                    p.rank = i + 1;
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
                fronts.Add(new Front());
                fronts[i] = Q;
            }

            for (int idx = 0; idx < fronts.Count; idx++)
            {
                if (fronts[idx].Count == 0)
                {
                    fronts.RemoveAt(idx);
                }
            }

            return fronts;
        }

        /// <summary>
        /// Crowding Distance Assignment;
        /// Use this function can calculate all the individual of each front distance;
        /// </summary>
        /// <param name="objective_types"></param>
        /// <param name="I"></param>
        public void CrowdingDistanceAssignment(ObjectiveType[] objective_types, Front I)
        {
            foreach (Individual p in I)
            {
                p.distance = 0;
            }

            for (int g = 0; g < objective_types.Length; g++)
            {
                I = QuickSort(I, objective_types, g, 0, I.Count - 1);
                Console.WriteLine("Object " + (g + 1) + "'s sorting");
                for (int i = 0; i < I.Count; i++)
                {
                    Console.WriteLine("Solution {0,2}: {1,3},{2,3}", (i + 1), I[i].Objectives[0], I[i].Objectives[1]);
                }
                
                // -1 noted that are equal infinite
                I[0].distance = Int32.MaxValue;
                I[I.Count - 1].distance = Int32.MaxValue;

                for (int i = 1; i < I.Count - 1; i++)
                {
                    I[i].distance = Math.Round(I[i].distance + (I[i + 1].Objectives[g] - I[i - 1].Objectives[g]) / (I[I.Count - 1].Objectives[g] - I[0].Objectives[g]), 2);
                    Console.WriteLine("I{0}.distance = {1,5}, solution: {2,3},{3,3}", i + 1, I[i].distance, I[i].Objectives[0], I[i].Objectives[1]);
                }
                Console.WriteLine("--------------------");
            }
        }

        /// <summary>
        /// DescendSort;
        /// Use this function can according to front distance; 
        /// </summary>
        /// <param name="_individualArray"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public List<Individual> DescendSort(Front _individualArray, int left, int right)
        {
            if (right <= left)
                return _individualArray;

            int pivotIndex = (left + right) / 2;
            Individual pivot = _individualArray[pivotIndex];
            Swap(_individualArray, pivotIndex, right);
            int swapIndex = left;
            for (int i = left; i < right; ++i)
            {
                if (_individualArray[i].rank < pivot.rank || ((_individualArray[i].rank == pivot.rank) && (_individualArray[i].distance >= pivot.distance)))
                {
                    Swap(_individualArray, i, swapIndex);
                    ++swapIndex;
                }
            }
            Swap(_individualArray, swapIndex, right);

            DescendSort(_individualArray, left, swapIndex - 1);
            DescendSort(_individualArray, swapIndex + 1, right);

            return _individualArray;
        }

        /// <summary>
        /// Crowding Distance Sorting;
        /// Use this function can calculate the individual distance of front and sort them;
        /// </summary>
        /// <param name="objective_types"></param>
        /// <param name="front"></param>
        /// <returns></returns>
        public List<Individual> CrowdingDistanceSorting(ObjectiveType[] objective_types, Front I)
        {
            List<Individual> results = new List<Individual>();
            foreach (Individual p in I)
            {
                p.distance = 0;
            }

            for (int g = 0; g < objective_types.Length; g++)
            {
                I = QuickSort(I, objective_types, g, 0, I.Count - 1);
                I[0].distance = Double.MaxValue;
                I[I.Count - 1].distance = Double.MaxValue;

                for (int i = 1; i < I.Count - 1; i++)
                {
                    I[i].distance = Math.Round(I[i].distance + (I[i + 1].Objectives[g] - I[i - 1].Objectives[g]) / (I[I.Count - 1].Objectives[g] - I[0].Objectives[g]), 2);
                }
            }
            results = DescendSort(I, 0, I.Count - 1);
            return results;
        }
    }
}
