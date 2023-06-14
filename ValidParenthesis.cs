// -----------------------------------------------------------------------
// <copyright file="ValidParenthesis.cs" company="Joy Of Playing hf.">
// Copyright (c) Joy Of Playing hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewProblems;

internal class ValidParenthesis
{
    [InterviewProblem]
    public static void RunProblem()
    {
        var testCases = new Dictionary<string, bool>
        {
            { "()", true },
            { "([])", true },
            { "[()[]{}[()[]{}[[()[]{}()[]{}]()[]{}]()[]{}]()[]{}]", true },
            { "[[[[]]]]", true},
            { "[[[[]]]])", false },
            { "[ [[ [] ]] ])", false },
            { "))", false },
        };

        foreach (var testCase in testCases)
        {
            var result = IsValidParenthesis(testCase.Key);
            var passed = result == testCase.Value ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Simple: {result} for {testCase.Key}");
        }

        foreach (var testCase in testCases)
        {
            var result = IsValidParenthesisOptimized(testCase.Key);
            var passed = result == testCase.Value ? "PASS" : "FAIL";
            Console.WriteLine($"{passed} Optimized: {result} for {testCase.Key}");
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
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

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

                default:
                    return false;
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

    private static bool IsValidParenthesisOptimized(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        var stack = new Stack<char>();

        foreach (var ch in input)
        {
            switch (ch)
            {
                case '(':
                    stack.Push(')');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                case '{':
                    stack.Push('}');
                    break;

                default:
                    {
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        var popped = stack.Pop();
                        if (popped != ch)
                        {
                            Console.WriteLine($"Invalid open brace: {popped} != {ch} for {input}");
                            return false;
                        }
                    }
                    break;
            }
        }

        return true;
    }

    private static bool IsValidParenthesisUsingReplace(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        while (input.Contains("()") || input.Contains("[]") || input.Contains("{}"))
        {
            input = input.Replace("()", string.Empty)
                .Replace("[]", string.Empty)
                .Replace("{}", string.Empty);
        }

        return input.Length == 0;
    }
}
