using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MergeSortScript
{
    public static List<(RectTransform, int)> MergeSort(List<(RectTransform, int)> unsortedList)
    {
        if (unsortedList.Count <= 1)
        {
            return unsortedList;
        }

        int middle = unsortedList.Count / 2;

        List<(RectTransform, int)> left = new List<(RectTransform, int)>();
        List<(RectTransform, int)> right = new List<(RectTransform, int)>();

        for (int i = 0; i < middle; i++)
        {
            left.Add(unsortedList[i]);
        }

        for (int i = middle; i < unsortedList.Count; i++)
        {
            right.Add(unsortedList[i]);
        }

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private static List<(RectTransform, int)> Merge(List<(RectTransform, int)> left, List<(RectTransform, int)> right)
    {
        List<(RectTransform, int)> result = new List<(RectTransform, int)>();

        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                int leftValue = left[0].Item2;
                int rightValue = right[0].Item2;

                if (leftValue >= rightValue)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }

        return result;
    }
}
