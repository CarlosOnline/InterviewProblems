// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Joy Of Playing hf.">
// Copyright (c) Joy Of Playing hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using InterviewProblems;
using System.Reflection;

var problemMethods = new[]
{
        nameof(LengthOfLongestSubstring),
        nameof(MedianOfSortedArrays),
        nameof(SumOfTwoValues),
        nameof(TrappingRainWater),
        nameof(ValidParenthesis),
    };

var problemClass = args.FirstOrDefault() ?? nameof(TrappingRainWater);

var validMethod = problemMethods.FirstOrDefault(item => string.Equals(item, problemClass, StringComparison.OrdinalIgnoreCase));
if (string.IsNullOrWhiteSpace(validMethod))
{
    Console.WriteLine($"Error: unknown problem: {problemClass}");
    return;
}

RunInterviewProblem(problemClass);

void RunInterviewProblem(string problem)
{
    var methods = Assembly.GetExecutingAssembly().GetTypes()
                  .SelectMany(t => t.GetMethods())
                  .Where(m => m.GetCustomAttributes(typeof(InterviewProblemAttribute), false).Length > 0)
                  .Where(item => string.Equals(item.DeclaringType?.Name, problem, StringComparison.OrdinalIgnoreCase))
                  .ToArray();

    foreach (var method in methods)
    {
        method.Invoke(null, null);
    }
}
