using InterviewProblems;

internal class Program
{
    private static void Main(string[] args)
    {
        var Test = args.FirstOrDefault() ?? "TrappingRainWater";

        switch (Test)
        {
            case "MedianOfSortedArrays":
                MedianOfSortedArrays.RunProblem();
                break;

            case "TrappingRainWater":
                TrappingRainWater.RunProblem();
                break;

            case "SumOfTwoValues":
                SumOfTwoValues.RunProblem();
                break;

            case "ValidParenthesis":
                ValidParenthesis.RunProblem();
                break;

            case "LengthOfLongestSubstring":
                LengthOfLongestSubstring.RunProblem();
                break;
        }
    }
}