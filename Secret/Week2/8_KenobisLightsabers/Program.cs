using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EDX.Sport.SecretOfChampions
{
    class KenobisLightsabers
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            var leftPart = new LinkedList<int>();
            var rightPart = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                var action = input[i].Split(new[] { ' ' }).ToArray();
                switch (action[0])
                {
                    case "add":
                        rightPart.AddLast(int.Parse(action[1]));

                        if (rightPart.Count - leftPart.Count == 2)
                        {
                            leftPart.AddLast(rightPart.First.Value);
                            rightPart.RemoveFirst();
                        }
                        break;

                    case "take":
                        rightPart.RemoveLast();

                        if (leftPart.Count > rightPart.Count)
                        {
                            rightPart.AddFirst(leftPart.Last.Value);
                            leftPart.RemoveLast();
                        }

                        break;

                    case "mum!":
                        var tmp = rightPart;
                        rightPart = leftPart;
                        leftPart = tmp;

                        if (leftPart.Count > rightPart.Count)
                        {
                            rightPart.AddFirst(leftPart.Last.Value);
                            leftPart.RemoveLast();
                        }
                        break;
                }
            }

            var sb = new StringBuilder();

            sb.AppendLine((leftPart.Count + rightPart.Count).ToString("0"));
            sb.AppendLine(string.Join(" ", leftPart.Select(x => x.ToString("0"))) + " " + string.Join(" ", rightPart.Select(x => x.ToString("0"))));


            File.WriteAllText("output.txt", sb.ToString());

            //Console.WriteLine(sb);
            //Console.ReadLine();
        }

    }
}

