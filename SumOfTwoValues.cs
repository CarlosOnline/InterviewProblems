namespace InterviewProblems;

internal class SumOfTwoValues
{
    public static void RunProblem()
    {
        var testCases = new List<Tuple<int, int[]>>
        {
            new Tuple<int, int[]>(10, new [] { 1, 2, 3, 4, 5, 6, }),
            new Tuple<int, int[]>(3, new [] { 1, 2, 3, 4, 5, 6, }),
            new Tuple<int, int[]>(-11, new [] { 1, -8, 2, 3, 4, 5, -3, 6, }),
            new Tuple<int, int[]>(-11, new [] { 1, -14, 2, 3, 4, 5, -3, 6, }),
        };

        foreach (var testCase in testCases)
        {
            var sum = testCase.Item1;
            var input = testCase.Item2;
            var results = FindSum(input, sum);
            var passed = results != null ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Simple: {sum,3:N0} == {results?.Item1,3:N0} {results?.Item2,3:N0} for {string.Join(",", input)}");
        }
    }

    private static Tuple<int, int>? FindSum(int[] input, int sum)
    {
        if (input.Length == 0)
        {
            return null;
        }

        var digits = new Dictionary<int, int>();

        for (var idx = 0; idx < input.Length; idx++)
        {
            var current = input[idx];
            var needed = sum - current;

            if (digits.ContainsKey(needed))
            {
                // return new Tuple<int, int>(digits[needed], idx);
                return new Tuple<int, int>(needed, current);
            }

            digits.Add(current, idx);
        }

        return null;
    }
}
