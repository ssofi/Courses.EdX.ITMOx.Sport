using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EDX.Sport.SecretOfChampions
{
    class CupStacks
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            var cups = input[1].Split(new[] { ' ' }).Select(x => short.Parse(x)).ToArray();
            var list = new CupStackList();
            for (int i = 0; i < n; i++)
            {
                var cup = cups[i];
                if (cup == 0)
                {
                    list.AddCup();
                }
                else
                {
                    list.AddStack(1);
                }
            }

            var sb = new StringBuilder();

            var noEmptyStacks = list.OneSizeStacks.Where(x => x.Value != 0);
            sb.AppendLine(noEmptyStacks.Count().ToString("0"));
            foreach (var g in noEmptyStacks)
            {
                sb.AppendLine(string.Format("{0} {1}", g.Key, g.Value.ToString("0")));
            }

            File.WriteAllText("output.txt", sb.ToString());

            //Console.WriteLine(sb);
            //Console.ReadLine();
        }

        class CupStack
        {
            public int Count { get; set; }

            public CupStack()
            {
                Count = 1;
            }
        }

        class CupStackList
        {
            // кол-во стаканов - кол-во стеков 
            public SortedDictionary<int, int> OneSizeStacks { get; set; } = new SortedDictionary<int, int>();

            public void AddStack(int count)
            {
                if (OneSizeStacks.ContainsKey(count))
                {
                    OneSizeStacks[count] = OneSizeStacks[count] + 1;
                }
                else
                    OneSizeStacks.Add(count, 1);
            }

            public void AddCup()
            {
                if (OneSizeStacks.Any())
                {
                    var stack = OneSizeStacks.First();
                    var cupCount = stack.Key;
                    if (stack.Value == 1)
                    {
                        OneSizeStacks.Remove(stack.Key);
                    }
                    else
                    {
                        OneSizeStacks[stack.Key] = stack.Value - 1;
                    }

                    AddStack(cupCount + 1);
                }
                else
                {
                    AddStack(1);
                }
            }
        }
    }
}

