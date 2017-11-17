using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week2
{
    class SnowmenTask
    {
        static void Solve(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);

            long output = 0;

            var snowmens = new Snowmen[n + 1];
            snowmens[0] = new Snowmen();
            for (int i = 1; i <= n; i++)
            {
                var actionParts = input[i].Split(new[] { ' ' }).ToArray();
                var ancestor = int.Parse(actionParts[0]);
                var action = short.Parse(actionParts[1]);
                Snowmen newSnowman;
                if (action == 0)
                    newSnowman = snowmens[ancestor].Ancestor != null ? snowmens[ancestor].Ancestor.Clone() : snowmens[ancestor].Clone();
                else
                    newSnowman = new Snowmen(snowmens[ancestor], action);

                snowmens[i] = newSnowman;
            }

            output = snowmens.Sum(x => x.Mass);

            File.WriteAllText("output.txt", output.ToString("0"));

            //Console.WriteLine(output.ToString("0"));
            //Console.ReadLine();
        }

        class Snowmen
        {
            private Snowmen _ancestor = null;
            private long _mass = 0;

            public long Mass { get { return _mass; } }

            public Snowmen Ancestor { get { return _ancestor; } }

            public Snowmen() { }

            public Snowmen(Snowmen baseSnowman, short topBall)
            {
                _ancestor = baseSnowman;
                _mass = _ancestor == null ? 0 : _ancestor.Mass + topBall;
            }

            public Snowmen Clone()
            {
                return new Snowmen()
                {
                    _ancestor = this._ancestor,
                    _mass = this._mass
                };
            }

        }
    }
}


