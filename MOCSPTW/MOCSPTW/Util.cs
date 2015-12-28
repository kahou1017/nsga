using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCSPTW
{
    class Util
    {
        private static void Swap(List<Individual> _individualArray, int indexA, int indexB)
        {
            Individual temp = _individualArray[indexA];
            _individualArray[indexA] = _individualArray[indexB];
            _individualArray[indexB] = temp;
        }

        public static List<Individual> QuickSort(List<Individual> _individualArray, int num_obj, int left, int right)
        {
            if (right <= left)
                return _individualArray;

            int pivotIndex = (left + right)/2;
            Individual pivot = _individualArray[pivotIndex];
            Swap(_individualArray, pivotIndex, right);
            int swapIndex = left;
            for (int i = left; i < right; ++i)
            {
                if (_individualArray[i].Objectives[num_obj] <= pivot.Objectives[num_obj])
                {
                    Swap(_individualArray, i, swapIndex);
                    ++swapIndex;
                }
            }
            Swap(_individualArray, swapIndex, right);

            QuickSort(_individualArray, num_obj,  left, swapIndex - 1);
            QuickSort(_individualArray, num_obj, swapIndex + 1, right);

            return _individualArray;
        }

        public static void DescendSort(List<Individual> _individualArray, int left, int right)
        {
            if (right <= left)
                return;

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
        }
    }
}
