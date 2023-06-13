namespace InterviewProblems
{
    /// <summary>
    /// 3. Longest Substring Without Repeating Characters
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/?envType=featured-list&envId=top-google-questions
    /// </summary>
    internal class LengthOfLongestSubstring
    {
        public static void RunProblem()
        {
            var testCases = new List<string>
            {
                "abcabcbb",
                "pwwkew",
                "bbbbb"
            };

            foreach (var testCase in testCases)
            {
                Calculate(testCase);
            }
        }

        private static int Calculate(string input)
        {
            var longestSubstring = string.Empty;

            for (var start = 0; start < input.Length; start++)
            {
                var seen = new Dictionary<char, bool>();
                var currentCh = input[start];
                seen[currentCh] = true;

                var pos = start + 1;
                for (; pos < input.Length; pos++)
                {
                    currentCh = input[pos];
                    if (seen.TryGetValue(currentCh, out var exists) && exists)
                    {
                        break;
                    }
                    seen[currentCh] = true;
                }

                var length = pos - start;
                if (length > longestSubstring.Length)
                {
                    longestSubstring = input.Substring(start, length);
                }
            }

            Console.WriteLine($"Input: {input} Longest: {longestSubstring.Length:N0} {longestSubstring}");
            return longestSubstring.Length;
        }
    }
}
