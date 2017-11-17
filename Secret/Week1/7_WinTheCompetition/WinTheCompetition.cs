using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDX.Sport.SecretOfChampions.Week1
{
    class WinTheCompetition
    {
        const int _competitionTime = 18000;
        static void Solve(string[] args)
        {
            var input = File.ReadLines("input.txt").ToArray();
            var taskCount = int.Parse(input[0]);
            var tasks = input[1].Split(new[] { ' ' }).Select(x => int.Parse(x)).ToList();

            var result = Calc(taskCount, tasks);

            File.WriteAllText("output.txt", result.ToString());

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int Calc(int count, List<int> tasks)
        {
            var time = _competitionTime;
            int solvedTasks = 0;
            foreach (var t in tasks.OrderBy(x => x))
            {
                time -= t;
                if (time < 0)
                    break;

                solvedTasks++;
            }

            return solvedTasks;
        }
    }
}
