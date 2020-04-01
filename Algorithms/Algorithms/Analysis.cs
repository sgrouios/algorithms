using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Algorithms;

namespace Algorithms
{
    class Analysis
    {
        public static void AnalyseLinearSearch(List<int> numbers, int[] numSearch, ref int count)
        {
            SearchForLinearAnalysis(numbers, numSearch, ref count);
        }

        public static void AnalyseBinarySearch(List<int> numbers, int[] numSearch, ref int count)
        {
            SearchForBinaryAnalysis(numbers, numSearch, ref count);
        }

        public static void SearchForBinaryAnalysis(List<int> numbers, int[] numSearch, ref int count)
        {
            foreach (int num in numSearch)
            {
                BinarySearchAnalysis(numbers, 0, numbers.Count - 1, num, ref count);
            }
        }

        public static void SearchForLinearAnalysis(List<int> numbers, int[] numSearch, ref int count)
        {
            foreach (int num in numSearch)
            {
                LinearSearchAnalysis(numbers, num, ref count);
            }
        }

        public static int BinarySearchAnalysis(List<int> numbers, int lower, int upper, int search, ref int count)
        {
            count++;
            int mid;
            if (upper >= lower)
            {
                mid = (lower + upper) / 2;
                if (numbers[mid] == search)
                {
                    return mid;
                }
                else if (numbers[mid] < search)
                {
                    return BinarySearchAnalysis(numbers, mid + 1, upper, search, ref count);
                }
                else
                {
                    return BinarySearchAnalysis(numbers, lower, mid - 1, search, ref count);
                }
            }
            return -1;

        }
        public static int LinearSearchAnalysis(List<int> numbers, int search, ref int count)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                count++;
                if (numbers[i] == search)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
