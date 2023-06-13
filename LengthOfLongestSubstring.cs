namespace InterviewProblems;

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
            "pwwkew",
            "abcabcbb",
            "bbbbb"
        };

        foreach (var testCase in testCases)
        {
            Calculate(testCase);
        }

        foreach (var testCase in testCases)
        {
            var result = lengthOfLongestSubstring(testCase);
            Console.WriteLine($"Input: {testCase} Longest: {result:N0}");
        }
    }

    private static int Calculate(string input)
    {
        var longestSubstring = string.Empty;

        for (var start = 0; start < input.Length; start++)
        {
            var seen = new HashSet<char>();
            var currentCh = input[start];
            seen.Add(currentCh);

            var pos = start + 1;
            for (; pos < input.Length; pos++)
            {
                currentCh = input[pos];
                if (seen.Contains(currentCh))
                {
                    break;
                }
                seen.Add(currentCh);
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

    private static int lengthOfLongestSubstring(string input)
    {
        if (input.Length == 0)
        {
            return 0;
        }

        int ans = 1;
        var set = new HashSet<char>();
        int left = 0, right = 0;
        var chLeft = input[left];
        var chRight = input[right];
        while (right < input.Length)
        {
            if (set.Contains(input[right]))
            {
                set.Remove(input[left]);
                left++;
                if (left < input.Length)
                {
                    chLeft = input[left];
                }
            }
            else
            {
                set.Add(input[right]);
                right++;
                if (right < input.Length)
                {
                    chRight = input[right];
                }
                int sz = set.Count;
                ans = Math.Max(ans, sz);
            }
        }

        return ans;
    }
}
