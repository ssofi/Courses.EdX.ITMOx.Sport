using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week2
{
    class BracketSequence
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            var output = new System.Text.StringBuilder();

            for (int i = 1; i <= n; i++)
            {
                var line = input[i];
                var brackets = line.ToArray();
                var stack = new Stack<char>();
                var answer = "YES";
                foreach (var b in brackets)
                {
                    if (b == '(' || b == '[')
                        stack.Push(b);
                    else
                    {
                        if (stack.Count == 0)
                        {
                            answer = "NO";
                            break;
                        }

                        var open = stack.Pop();
                        if ((open == '(' && b != ')') || (open == '[' && b != ']'))
                        {
                            answer = "NO";
                            break;
                        }
                    }
                }

                if (stack.Count != 0)
                    answer = "NO";

                output.AppendLine(answer);
            }


            File.WriteAllText("output.txt", output.ToString());

            //Console.WriteLine(output);
            //Console.ReadLine();
        }


    }
}

