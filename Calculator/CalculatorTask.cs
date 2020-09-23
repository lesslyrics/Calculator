using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class CalculatorTask
    {
        private readonly List<string> _possibleOperators =
            new List<string>(new string[] {"+", "-", "*", "/", "(", ")"});

        private readonly List<string> _receivedOperators;

        /** constructor **/
        public CalculatorTask(params string[] operatorList)
        {
            _receivedOperators = operatorList.Length == 0
                ? new List<string>(_possibleOperators)
                : new List<string>(operatorList);
        }

        private IEnumerable<string> SeparateInput(string input)
        {
            var inputSeparated = new List<string>();
            var currentPosition = 0;
            while (currentPosition < input.Length)
            {
                var currentString = string.Empty + input[currentPosition];
                if (!_possibleOperators.Contains(input[currentPosition].ToString()))
                {
                    if (char.IsDigit(input[currentPosition]))
                    {
                        for (var i = currentPosition + 1;
                            i < input.Length && (input[i] == ',' || input[i] == '.' || char.IsDigit(input[i]));
                            i++)
                            currentString += input[i];
                    }
                    else if (char.IsLetter(input[currentPosition]))
                    {
                        for (var i = currentPosition + 1;
                            i < input.Length && (char.IsDigit(input[i]) || char.IsLetter(input[i]));
                            i++)
                            currentString += input[i];
                    }
                }

                yield return currentString;
                currentPosition += currentString.Length;
            }
        }

        /** method to replace minuses in input expression **/
        private string ReplaceMinus(string input)
        {
            var result = new StringBuilder(input.Length);
            var start = 0;

            if (input[0] == '-')
            {
                for (var j = 1; j < input.Length; j++)
                {
                    if (_receivedOperators.Contains(input[j].ToString()))
                    {
                        start = j;
                        result.Append("0" + input.Substring(0, j));
                        break;
                    }

                    if (j != input.Length - 1) continue;
                    {
                        result.Append("(0" + input.Substring(0) + ")");
                    }
                }
            }

            for (var i = start; i < input.Length; i++)
            {
                if (input[i] == '-' && _receivedOperators.Contains(input[i - 1].ToString()) && input[i - 1] != ')')
                {
                    for (var j = i + 1; j < input.Length; j++)
                    {
                        if (_receivedOperators.Contains(input[j].ToString()))
                        {
                            i = j;
                            result.Append("0" + input.Substring(i, j - i) + ")");
                            break;
                        }

                        if (j != input.Length - 1) continue;
                        {
                            result.Append("0" + input.Substring(i) + ")");
                            i = j;
                        }
                    }
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            return result.ToString();
        }

        /** method to get operator priority for further evaluation**/
        private static int GetOperatorPriority(string symbol)
        {
            switch (symbol)
            {
                case "(":
                    return 1;
                case ")":
                    return 2;
                case "+":
                    return 3;
                case "-":
                    return 4;
                case "*":
                    return 5;
                case "/":
                    return 5;
                default:
                    return 0;
            }
        }

        /** method to format to postfix notation **/
        public string[] FormatToPostfix(string input)
        {
            var stack = new Stack<string>();
            var result = new List<string>();

            input = ReplaceMinus(input.Trim());

            foreach (var c in SeparateInput(input))
            {
                if (_receivedOperators.Contains(c))
                {
                    if (!c.Equals("(") && stack.Count > 0)
                    {
                        if (c.Equals(")"))
                        {
                            var stackTop = stack.Pop();
                            while (stackTop != "(")
                            {
                                result.Add(stackTop);
                                stackTop = stack.Pop();
                            }
                        }
                        else if (GetOperatorPriority(c) >= GetOperatorPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetOperatorPriority(c) < GetOperatorPriority(stack.Peek()))
                            {
                                result.Add(stack.Pop());
                            }

                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    result.Add(c);
            }

            if (stack.Count <= 0) return result.ToArray();
            {
                result.AddRange(stack);
            }
            return result.ToArray();
        }


        /** calculation driver function **/
        public static string Calculate(params string[] values)
        {
            var stack = new Stack<string>();

            var operation = new[] {"/", "*", "+", "-"};

            foreach (var value in values)
            {
                if (operation.Contains(value))
                {
                    var stackTop1 = stack.Pop();
                    var stackTop2 = stack.Pop();

                    // errors handling
                    if (!double.TryParse(stackTop2, out var left) | !double.TryParse(stackTop1, out var right))
                    {
                        // write error message if the TraceSwitch level is set to error or higher
                        Trace.Write("Input parsing error");
                    }

                    switch (value)
                    {
                        case "/":
                            stack.Push((left / right).ToString());
                            break;
                        case "*":
                            stack.Push((left * right).ToString());
                            break;
                        case "+":
                            stack.Push((left + right).ToString());
                            break;
                        case "-":
                            stack.Push((left - right).ToString());
                            break;
                    }
                }
                else
                {
                    stack.Push(value);
                }
            }

            return stack.Pop();
        }
    }
}