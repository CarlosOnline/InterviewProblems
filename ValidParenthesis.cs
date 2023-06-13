namespace InterviewProblems;

internal class ValidParenthesis
{
    public static void RunProblem()
    {
        var testCases = new Dictionary<string, bool>
        {
            { "()", true },
            { "([])", true },
            { "[[[[]]]])", false },
            { "))", false },
            { "[ [[ [] ]] ])", false },
        };

        foreach (var testCase in testCases)
        {
            var result = IsValidParenthesis(testCase.Key);
            var passed = result == testCase.Value ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Simple: {result} for {testCase.Key}");
        }

        foreach (var testCase in testCases)
        {
            var result = IsValidParenthesisUsingReplace(testCase.Key);
            var passed = result == testCase.Value ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Replace: {result} for {testCase.Key}");
        }
    }

    private static bool IsValidParenthesis(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        var stack = new Stack<char>();

        foreach (var ch in input)
        {
            switch (ch)
            {
                case '(':
                case '[':
                case '{':
                    stack.Push(ch);
                    break;

                case ')':
                    if (!IsValidStartBrace('('))
                    {
                        return false;
                    }
                    break;

                case ']':
                    if (!IsValidStartBrace('['))
                    {
                        return false;
                    }
                    break;

                case '}':
                    if (!IsValidStartBrace('{'))
                    {
                        return false;
                    }
                    break;
            }
        }

        return true;

        bool IsValidStartBrace(char expected)
        {
            if (stack.Count == 0)
            {
                return false;
            }

            var popped = stack.Pop();
            if (popped != expected)
            {
                Console.WriteLine($"Invalid open brace: {popped} != {expected} for {input}");
                return false;
            }

            return true;
        }
    }

    private static bool IsValidParenthesisUsingReplace(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;

        while (input.Contains("()") || input.Contains("[]") || input.Contains("{}"))
        {
            input = input.Replace("()", string.Empty)
                .Replace("[]", string.Empty)
                .Replace("{}", string.Empty);
        }

        return input.Length == 0;
    }
}
