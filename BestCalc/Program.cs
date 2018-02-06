using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace BestCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //получить сборку классов
            //является ли он реализацией нашего интерфейса
            var calc1 = new Calc();
            var operations = calc1.GetOperNames();




            Console.WriteLine("Калькулятор");

            Console.Write("Доступные операции:  ");
            foreach (var item in operations)
            {
                //вывод в консоль список доступных операций
                Console.Write(item+" ");    
            }
            Console.WriteLine();
            Console.Write("Выберите операцию:  ");

            string oper = Console.ReadLine();

            //проверка введеной операции (есть ли такая в наличии)
            bool opers = operations.Any(el => el.Contains(oper)); 
            if (opers == true)
            {
                double x = 0;
                double y = 0;
                double res = 0;

                Console.Write("Введите числа (через пробел): ");
                string operXY = Console.ReadLine();
                //разделяет на массив чисел разделенных знаками
                string[] array = operXY.Split(' ');
                x = Convert.ToDouble(array[0]);
                y = Convert.ToDouble(array[1]);
                Console.WriteLine($"Введеные числа: x = {x}, y = {y}");

                Calc calc = new Calc();
                res = calc.Exec(oper, new[] { x, y });
                Console.WriteLine($"Результат операции = {Math.Round(res, 4)}");
            }
            else { Console.WriteLine("Такой операции не обнаружено"); }

            Console.ReadKey();
        }
        public static bool Proverka(string oper)
        {
            bool otvet = false;
            if (oper == "Sum" || oper == "Min" || oper == "Mul" || oper == "Div")
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
