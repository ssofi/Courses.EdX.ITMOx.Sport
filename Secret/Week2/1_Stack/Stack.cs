using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week2
{
    class Stack
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            var output = new System.Text.StringBuilder();
            var stack = new MyStack();
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
                    var poppedNumber = stack.Pop();
                    output.AppendLine(poppedNumber.ToString());
                }
            }

            File.WriteAllText("output.txt", output.ToString());

            //Console.WriteLine(output);
            //Console.ReadLine();
        }

        class MyStack
        {
            private List<int> _numbers = new List<int>();
            private int _lenght = 0;

            public void Push(int n)
            {
                _numbers.Add(n);
                _lenght++;
            }

            public int Pop()
            {
                var res = _numbers[_lenght - 1];
                _numbers.RemoveAt(_lenght - 1);
                _lenght--;
                return res;
            }
        }

    }
}

