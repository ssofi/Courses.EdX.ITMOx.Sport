using System;
using System.IO;
using System.Linq;

namespace EDX.Sport.SecretOfChampions.Week1
{
    public class Three_bonacci
    {
        public static void Solve(string[] args)
        {
            var numbers = File.ReadAllText("input.txt").Split(new[] { ' ' }).Select(x => int.Parse(x)).ToArray();
            var result = T(new int[] { numbers[0], numbers[1], numbers[2] }, numbers[3]);
            File.WriteAllText("output.txt", result.ToString());
        }

        static private int T(int[] numbers, int n)
        {
            int result = 0;
            switch (n)
            {
                case 0:
                    result = numbers[0];
                    break;
                case 1:
                    result = numbers[1];
                    break;
                case 2:
                    result = numbers[2];
                    break;
                default:
                    var t1 = numbers[2];
                    var t2 = numbers[1];
                    var t3 = numbers[0];
                    for (int i = 3; i <= n; i++)
                    {
                        result = t1 + t2 - t3;
                        t3 = t2;
                        t2 = t1;
                        t1 = result;
                    }
                    break;
            }
            return result;
        }
    }
}
