using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace EDX.Sport.SecretOfChampions.Week1
{
    class GenerateTests
    {
        static List<int> _primeNumbers = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
        static long _answer;
        static long _countForAnswer;
        static long _n;

        static void Solve(string[] args)
        {
            _n = int.Parse(File.ReadAllText("input.txt"));
            var t = new System.Diagnostics.Stopwatch();

            t.Start();
            Calc4();
            var result = _n - _answer + 1;
            t.Stop();

            File.WriteAllText("output.txt", result.ToString());

            //Console.WriteLine(result);
            //Console.WriteLine(t.ElapsedMilliseconds);
            //Console.ReadLine();
        }

        static void Calc4()
        {
            FindMax(0, 64, 1, 1);
        }

        static void FindMax(int index, int lastA, long value, long countForValue)
        {
            if (countForValue > _countForAnswer || (countForValue == _countForAnswer && value < _answer))
            {
                _answer = value;
                _countForAnswer = countForValue;
            }

            if (index == 15)
                return;

            for (int a = 1; a <= lastA; a++)
            {
                long t = value * _primeNumbers[index];

                if (t / _primeNumbers[index] != value)
                    return;

                if (t > _n)
                    break;

                value = t;
                FindMax(index + 1, a, value, countForValue * (a + 1));
            }
        }
    }
}
