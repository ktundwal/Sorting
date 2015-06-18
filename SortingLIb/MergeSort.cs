using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingLIb
{
    public class MergeSort<T> where T : IComparable<T>
    {
        static public List<T> Sort(List<T> items)
        {
            // if list contains only 1 item, there is nothing to sort
            if (items.Count <= 1) return items;

            // break the list in half and Sort them
            var left = Sort(items.GetRange(0, items.Count/2));
            var right = Sort(items.GetRange(items.Count / 2, items.Count - items.Count / 2));

            return Merge(left, right);
        }

        private static List<T> Merge(List<T> left, List<T> right)
        {
            var mergedList = new List<T>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First().CompareTo(right.First()) <= 0)
                {
                    mergedList.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    mergedList.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            var remainingList = left.Count > 0 ? left : right;

            while (remainingList.Count > 0)
            {
                mergedList.Add(remainingList.First());
                remainingList.RemoveAt(0);
            }

            return mergedList;
        }
    }
}
