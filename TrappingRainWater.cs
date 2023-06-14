namespace InterviewProblems;

internal class TrappingRainWater
{
    public static void RunProblem()
    {
        var testCases = new List<Tuple<int, int[]>>
        {
            new Tuple<int, int[]>(6, new [] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1, }),
            new Tuple<int, int[]>(9, new [] { 4,2,0,3,2,5 }),
        };

        foreach (var testCase in testCases)
        {
            var trapped = testCase.Item1;
            var input = testCase.Item2;
            var results = FindTrappedRainWater(input);
            var passed = results == trapped ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Simple: {trapped,3:N0} == {testCase.Item1,3:N0} for {string.Join(",", input)}");
        }
    }

    private static int FindTrappedRainWater(int[] input)
    {
        if (input.Length == 0)
        {
            return 0;
        }

        var trapped = 0;
        var history = new Dictionary<int, int>();

        for (var idx = 0; idx < input.Length; idx++)
        {
            var height = input[idx];
            if (height == 0)
            {
                continue;
            }

            for (var currentHeight = height; currentHeight > 0; currentHeight--)
            {
                if (history.TryGetValue(currentHeight, out var position))
                {
                    var space = (idx - position) - 1;
                    trapped += space;

                    history.Remove(currentHeight);
                }

                history.TryAdd(currentHeight, idx);
            }
        }

        return trapped;
    }
}
