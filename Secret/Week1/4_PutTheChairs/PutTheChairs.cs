using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week1
{
    class PutTheChairs
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllText("input.txt").Split(new[] { ' ' }).Select(x => int.Parse(x)).ToArray();

            var result = Calc(input);
            File.WriteAllText("output.txt", result.ToString());

            //Console.WriteLine(result);
            //Console.ReadLine();
        }

        static private double Calc(int[] input)
        {
            double a = input[0];
            double b = input[1];
            double c = input[2];

            var cosA = Cos(a, b, c);
            var cosB = Cos(b, a, c);
            var cosC = Cos(c, a, b);

            var ai = Side(b / 2, c / 2, cosA);
            var bi = Side(a / 2, c / 2, cosB);
            var ci = Side(a / 2, b / 2, cosC);

            return (ai + bi + ci) / 3;
        }

        static double Cos(double a, double b, double c)
        {
            return (b * b + c * c - a * a) / (2 * b * c);
        }

        static double Side(double a, double b, double cos)
        {
            return Math.Sqrt(a * a + b * b - (2 * a * b * cos));
        }
    }
}
