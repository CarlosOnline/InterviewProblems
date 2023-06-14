// -----------------------------------------------------------------------
// <copyright file="MedianOfSortedArrays.cs" company="Joy Of Playing hf.">
// Copyright (c) Joy Of Playing hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewProblems;

internal class MedianOfSortedArrays
{
    [InterviewProblem]
    public static void RunProblem()
    {
        var testCases = new List<Tuple<double, int[], int[]>>
        {
            new Tuple<double, int[], int[]>(2, new [] { 1, 3 }, new [] { 2 }),
            new Tuple<double, int[], int[]>(2.5, new [] { 1, 3 }, new [] { 2, 4 }),
            new Tuple<double, int[], int[]>(2, new [] { 1, 300 }, new [] { 2 }),
        };

        foreach (var testCase in testCases)
        {
            var median = testCase.Item1;
            var (results, merged) = FindMedian(testCase.Item2, testCase.Item3);
            var passed = results == median ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Simple: {median,3:N3} == {results,3:N3} {string.Join(",", merged)}");
        }
    }

    private static (double median, int[] merged) FindMedian(int[] leftInput, int[] rightInput)
    {
        var merged = new int[leftInput.Length + rightInput.Length];

        var left = 0;
        var right = 0;

        for (var idx = 0; idx < merged.Length; idx++)
        {
            if (right >= rightInput.Length)
            {
                merged[idx] = leftInput[left];
                left++;
            }
            else if (left >= leftInput.Length)
            {
                merged[idx] = rightInput[right];
                right++;
            }
            else if (leftInput[left] < rightInput[right])
            {
                merged[idx] = leftInput[left];
                left++;
            }
            else
            {
                merged[idx] = rightInput[right];
                right++;
            }
        }

        var middle = (int)Math.Round(merged.Length / 2.0);
        var median1 = merged[middle - 1];

        var isOdd = (merged.Length & 0x0001) == 1;
        if (isOdd)
        {
            return (median1, merged);
        }
        else
        {
            var median2 = merged[middle];
            return ((median1 + median2) / 2.0, merged);
        }
    }
}
