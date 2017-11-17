using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week1
{
    class WriteACodeTemplate
    {
        static Func<char, bool> skip = (c) => { var code = (int)c; return code <= 32 || code > 126; };

        static void Solve(string[] args)
        {
            using (var rdr = new StreamReader("input.txt"))
            {
                var keyboardSize = rdr.ReadLine().Split(new[] { ' ' }).Select(x => int.Parse(x)).ToArray();

                var width = keyboardSize[0];
                var height = keyboardSize[1];

                var keyboard = new Keyboard();

                for (int row = 0; row < height; row++)
                {
                    var l = rdr.ReadLine();
                    for (int col = 0; col < width; col++)
                    {
                        keyboard.Add(l[col], new Position(row, col));
                    }
                }

                var templates = new List<Template>();
                var template = ReadTemplate(rdr, keyboard);
                while (template != null)
                {
                    templates.Add(template);
                    template = ReadTemplate(rdr, keyboard);
                }

                var min = templates.Min(x => x.Distance);
                var bestTemplate = templates.First(x => x.Distance == min);

                var result = string.Format("{0}{1}{2}", bestTemplate.Name, Environment.NewLine, bestTemplate.Distance);
                File.WriteAllText("output.txt", result);

                //Console.WriteLine(result);
                //Console.ReadLine();
            }
        }

        private static Template ReadTemplate(StreamReader rdr, Keyboard keyboard)
        {
            var name = rdr.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                return null;

            var template = new Template(name);

            var line = rdr.ReadLine(); //%TEMPLATE-START%
            line = rdr.ReadLine(); 

            char? prevSymbol = null;

            while (!string.Equals(line, "%TEMPLATE-END%"))
            {                
                var symbols = line.Where(x => !skip(x)).ToArray();

                if (symbols.Length != 0)
                {
                    prevSymbol = prevSymbol ?? symbols[0];
                    foreach (var c in symbols)
                    {
                        var prevPosition = keyboard[prevSymbol.Value];
                        var curPosition = keyboard[c];
                        template.Distance += Math.Max(Math.Abs(prevPosition.X - curPosition.X), Math.Abs(prevPosition.Y - curPosition.Y));

                        prevSymbol = c;
                    }
                }
                line = rdr.ReadLine();
            }

            return template;
        }

        private class Keyboard : Dictionary<char, Position>
        {
            public Keyboard() : base() { }
        }

        private class Position
        {
            public int X { get; }
            public int Y { get; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private class Template
        {
            public string Name { get; }

            public int Distance { get; set; }

            public Template(string name)
            {
                Name = name;
            }
        }
    }
}
