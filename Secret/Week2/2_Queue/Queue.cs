using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week2
{
    class Queue
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            var output = new System.Text.StringBuilder();
            var stack = new MyQueue();
            for (int i = 1; i <= n; i++)
            {
                var line = input[i];
                var command = line.Split(new[] { ' ' }).ToArray();
                if(command[0] == "+")
                {
                    var pushedNumber = int.Parse(command[1]);
                    stack.Push(pushedNumber);
                }
                else
                {
                    output.AppendLine(stack.Pop().ToString());
                }
            }

            File.WriteAllText("output.txt", output.ToString());

            //Console.WriteLine(output);
            //Console.ReadLine();
        }

        class MyQueue
        {
            private LinkedList<int> _numbers = new LinkedList<int>();

            public void Push(int n)
            {
                _numbers.AddLast(n);
            }

            public int Pop()
            {
                var res = _numbers.First();
                _numbers.RemoveFirst();
                return res;
            }
        }

    }
}

