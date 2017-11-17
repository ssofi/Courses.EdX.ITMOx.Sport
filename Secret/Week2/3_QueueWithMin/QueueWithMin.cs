using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week2
{
    class QueueWithMin
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            var output = new System.Text.StringBuilder();
            var queue = new MyQueue();
            for (int i = 1; i <= n; i++)
            {
                var line = input[i];
                var command = line.Split(new[] { ' ' }).ToArray();
                if (command[0] == "+")
                {
                    var pushedNumber = int.Parse(command[1]);
                    queue.Enqueue(pushedNumber);
                }
                else if (command[0] == "-")
                {
                    queue.Dequeue();
                }
                else if (command[0] == "?")
                {
                    output.AppendLine(queue.Min().ToString());
                }
            }


            File.WriteAllText("output.txt", output.ToString());

            //Console.WriteLine(output);
            //Console.ReadLine();
        }

        class MyQueue
        {
            private StackWithMin _in = new StackWithMin();
            private StackWithMin _out = new StackWithMin();

            public void Enqueue(int n)
            {
                _in.Push(n);
            }

            public int Dequeue()
            {
                if (_out.IsEmpty())
                {
                    while (!_in.IsEmpty())
                    {
                        var el = _in.Pop();
                        _out.Push(el);
                    }
                }

                return _out.Pop();
            }

            public int Min()
            {
                return Math.Min(_in.Min(), _out.Min());
            }
        }

        private class StackWithMin
        {
            // Last is the TOP
            private LinkedList<Element> _list = new LinkedList<Element>();

            public void Push(int n)
            {
                var min = IsEmpty() ? n : Math.Min(_list.Last.Value.CurrentMin, n);
                _list.AddLast(new Element(n, min));
            }

            public int Pop()
            {
                var res = _list.Last.Value.Value;
                _list.RemoveLast();
                return res;
            }

            public int Min()
            {
                return IsEmpty() ? int.MaxValue : _list.Last.Value.CurrentMin;
            }

            public bool IsEmpty()
            {
                return !_list.Any();
            }
        }

        private class Element
        {
            public int Value { get; set; }
            public int CurrentMin { get; set; }

            public Element(int value, int min)
            {
                Value = value;
                CurrentMin = min;
            }
        }

    }
}

