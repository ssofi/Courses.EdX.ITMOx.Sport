using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week1
{
    public class PrepareYourselfToCompetitions
    {
        public static void Solve(string[] args)
        {
            var lines = File.ReadLines("input.txt").ToArray();
            var n = int.Parse(lines[0]);
            var p = lines[1].Split(new[] { ' ' }).Select(x => int.Parse(x)).ToArray();
            var t = lines[2].Split(new[] { ' ' }).Select(x => int.Parse(x)).ToArray();
            var result = Skills(n, p, t);
            File.WriteAllText("output.txt", result.ToString());
        }

        private static int Skills(int n, int[] p, int[] t)
        {
            var result = 0;

            bool allP = true;
            bool allT = true;
            for (int i = 0; i < n; i++)
            {
                if (p[i] > t[i])
                {
                    result += p[i];
                    allT = false;
                }
                else if (t[i] > p[i])
                {
                    result += t[i];
                    allP = false;
                }
                else
                {
                    result += t[i];
                    allP = false;
                    allT = false;
                }
            }

            if(allP || allT)
            {
                var pDict = new Dictionary<int, int>();
                var tDict = new Dictionary<int, int>();
                for (int i = 0; i < n; i++)
                {
                    pDict.Add(i, p[i]);
                    tDict.Add(i, t[i]);
                }

                var from = allP ? tDict : pDict;
                var baseArray = allP ? pDict : tDict;
                result += GetOtherElement(from, baseArray);
            }

            return result;
        }

        private static int GetOtherElement(Dictionary<int, int> from, Dictionary<int, int> baseArray)
        {
            var fromWithoutEquals = from.Where(x => x.Value != baseArray[x.Key]);
            var max = fromWithoutEquals.OrderByDescending(x => x.Value);
            var indexes = fromWithoutEquals.Where(x => x.Value == max.First().Value).Select(x => x.Key);

            var pMinIndex = baseArray.Where(x => indexes.Contains(x.Key)).OrderBy(x => x.Value).First().Key;

            return from[pMinIndex] - baseArray[pMinIndex];
        }        
    }
}
