using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EDX.Sport.SecretOfChampions.Week2
{
    class PostfixNotation
    {
        static void Solve(string[] args)
        {

            var input = File.ReadAllLines("input.txt");
            var n = int.Parse(input[0]);
            var expression = input[1].Trim().Split(new[] { ' ' }).Select(x => x[0]).ToArray();
            var operators = new[] { '+', '-', '*' };

            double output = 0;

            var q = new Stack<IOperand>();
            for (int i = 0; i < n; i++)
            {
                var current = expression[i];
                if (operators.Contains(current))
                {
                    var right = q.Pop();
                    var left = q.Pop();
                    q.Push(new ExpressionOperand(new BinaryExpression(left.GetValue(), right.GetValue(), current)));
                }
                else
                {
                    q.Push(new ConstOperand(double.Parse(current.ToString())));
                }
            }

            output = q.Pop().GetValue();

            File.WriteAllText("output.txt", output.ToString("0"));

            //Console.WriteLine(output.ToString("0"));
            //Console.ReadLine();
        }

        interface IOperand
        {
            double GetValue();
        }

        interface IExpression
        {
            double Evaluate();
        }

        class BinaryExpression : IExpression
        {
            private readonly double _left;
            private readonly double _right;
            private readonly char _operator;

            public BinaryExpression(double left, double right, char op)
            {
                _left = left;
                _right = right;
                _operator = op;
            }
            public double Evaluate()
            {
                double result = 0F;
                switch (_operator)
                {
                    case '+':
                        result = _left + _right;
                        break;
                    case '-':
                        result = _left - _right;
                        break;
                    case '*':
                        result = _left * _right;
                        break;
                }

                return result;
            }
        }
        class ConstOperand : IOperand
        {
            private readonly double _value;

            public ConstOperand(double value)
            {
                _value = value;
            }
            public double GetValue()
            {
                return _value;
            }
        }
        class ExpressionOperand : IOperand
        {
            private readonly IExpression _expression;

            public ExpressionOperand(IExpression expression)
            {
                _expression = expression;
            }
            public double GetValue()
            {
                return _expression.Evaluate();
            }
        }


    }
}

