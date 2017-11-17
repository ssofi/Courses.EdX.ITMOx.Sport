using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week1
{
    class CreateTeam
    {
        static void Solve(string[] args)
        {
            var lines = File.ReadLines("input.txt").ToArray();
            var part1 = lines[0].Split(new[] { ' ' }).Select(x => (int)Math.Pow(int.Parse(x), 2)).ToArray();
            var part2 = lines[1].Split(new[] { ' ' }).Select(x => (int)Math.Pow(int.Parse(x), 2)).ToArray();
            var part3 = lines[2].Split(new[] { ' ' }).Select(x => (int)Math.Pow(int.Parse(x), 2)).ToArray();
            
            var result = Search(part1, part2, part3);
            File.WriteAllText("output.txt", result.ToString());
        }

        static double Search(int[] part1, int[] part2, int[] part3)
        {
            var max = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3 ; j++)
                {
                    if (j == i)
                        continue;

                    for (int k = 0; k < 3; k++)
                    {
                        if (k == j || k == i)
                            continue;

                        var sum = part1[i] + part2[j] + part3[k];
                        if (sum > max)
                            max = sum;
                    }
                }
            }

            return Math.Sqrt(max);
        }
    }
}
