using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BestCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор");

            Console.Write("Выберите операцию (Sum, Min, Mul, Div): ");
            string oper = Console.ReadLine();
            bool Operaciya = Program.Proverka(oper);
            if (Operaciya == true)
            {
                double x = 0;
                double y = 0;
                double res = 0;

                Console.Write("Введите числа (через пробел): ");

                string operXY = Console.ReadLine();
                string[] array = operXY.Split(' ');//разделяет на массив чисел разделенных знаками
                x = Convert.ToDouble(array[0]);
                y = Convert.ToDouble(array[1]);
                Console.WriteLine($"Введеные числа: x = {x}, y = {y}");

                Calc calc = new Calc();

                if (oper == "Sum")
                {
                    res = calc.Sum(x, y);
                    Console.WriteLine($"Sum({x} + {y}) = {Math.Round(res, 4)}");

                }
                else if (oper == "Min")
                {
                    res = calc.Min(x, y);
                    Console.WriteLine($"Min({x} - {y}) = {Math.Round(res, 4)}");

                }
                else if (oper == "Mul")
                {
                    res = calc.Mul(x, y);
                    Console.WriteLine($"Mul({x} * {y}) = {Math.Round(res, 4)}");

                }
                else if (oper == "Div")
                {
                    res = calc.Div(x, y);
                    Console.WriteLine($"Div({x} / {y}) = {Math.Round(res, 4)}");

                }

            }
            else { Console.WriteLine("Такой операции не обнаружено"); }
            Console.ReadKey();
        }
        public static bool Proverka(string oper)
        {
            bool otvet = false;
            if (oper == "Sum" || oper == "Min" || oper == "Mul" || oper == "Div" || oper == "Rand")
            {
                otvet = true;
            }
            else
            {
                otvet = false;
            }
            return otvet;
        }
    }
}
