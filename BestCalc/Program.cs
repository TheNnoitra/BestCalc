using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

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

            //поиск доступных DDL в папке 'path' 
            //у которых встречается в названии 'Calc' и 'Core'
            string path = @"C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\BestCalc\bin\Debug";

            List<string> filespath = Directory.GetFiles(path, "*Calc*Core*.dll").ToList<string>();
            Console.WriteLine("Доступные библиотеки: ");
            foreach (var item in filespath)
            {
                //вывод в консоль список доступных библиотек
                string files = Path.GetFileNameWithoutExtension(item);
                Console.WriteLine(files + " ");
            }

            Console.WriteLine();
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
