using ItUniverCalcCore.Interfaces;
using ItUniverCalcCore.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BestCalc
{
    public class Calc
    {
        /*
        private static  IList<IOperation> operations { get; set; }

        private static IList<ISuperOperation> superoperations { get; set; }

        public Calc()
        {
            operations = new List<IOperation>();
            var assembly = Assembly.GetExecutingAssembly();

            //поиск доступных DDL в папке 'path' 
            //у которых встречается в названии 'Calc' и 'Core'
            //string path = @"C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\BestCalc\bin\Debug";
            string path = @"C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\libs";

            List<string> filespath = Directory.GetFiles(path, "*Calc*.dll").ToList<string>();

            foreach (var itemF in filespath)
            {
                //вывод в консоль список доступных библиотек
                string files = Path.GetFileNameWithoutExtension(itemF);
                //подгружаем библиотеку
                var a = Assembly.Load(files);
                //выкачиваем типы
                var types = a.GetTypes();
                var typeoper = typeof(IOperation);
                foreach (var item in types.Where(t => !t.IsAbstract && !t.IsInterface))
                {
                    var interfaces = item.GetInterfaces();
                    var isOperation = interfaces.Any(it => it == typeoper);

                    if (isOperation)
                    {
                        var obj = Activator.CreateInstance(item);
                        var operation = obj as IOperation;
                        if (operation != null)
                        {
                            operations.Add(operation);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получить список имен операций
        /// </summary>
        /// <returns></returns>
        [Obsolete("Будет удалено")]
        public string[] GetOperNames()
        {
            return operations.Select(o => o.Name).ToArray();
        }

        public IList<ISuperOperation> GetSettings()
        {
            superoperations = new List<ISuperOperation>();

            string path = @"C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\libs";
            List<string> filespath = Directory.GetFiles(path, "*Calc*.dll").ToList<string>();

            foreach (var itemF in filespath)
            {
                //вывод в консоль список доступных библиотек
                string files = Path.GetFileNameWithoutExtension(itemF);
                //подгружаем библиотеку
                var a = Assembly.Load(files);
                //выкачиваем типы
                var types = a.GetTypes();
                var typeoper = typeof(ISuperOperation);
                foreach (var item in types.Where(t => !t.IsAbstract && !t.IsInterface))
                {
                    var interfaces = item.GetInterfaces();
                    var isOperation = interfaces.Any(it => it == typeoper);

                    if (isOperation)
                    {
                        var obj = Activator.CreateInstance(item);
                        var superoperation = obj as ISuperOperation;
                        if (superoperation != null)
                        {
                            superoperations.Add(superoperation);
                        }
                    }
                }
            }

            return superoperations.ToArray();
        }

        public double Exec(string oper, double[] args)
        {
            // найти операцию в списке
            var operation = operations
                .FirstOrDefault(o => o.Name == oper);

            // если не найдено - возвращаем ошибку
            if (operation == null)
            { return Double.NaN; }

            // если нашли - передаем ей аргументы и вычисляем результат
            var res = operation.Exec(args);

            // возвращаем результат
            return res;
        }
    }
    */
        private IList<IOperation> operations { get; set; }
        public Calc()
        {
            operations = new List<IOperation>();

            string path = @"C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\libs";

            //// Загружаем наши операции
            LoadOperation(Assembly.GetExecutingAssembly());

            var files = Directory.GetFiles(path, "*.dll");

            foreach (var file in files)
            {
                LoadOperation(Assembly.LoadFile(file));
            }

        }

        private void LoadOperation(Assembly assembly)
        {

            var types = assembly.GetTypes();
            var typeOperation = typeof(IOperation);

            foreach (var item in types.Where(t => !t.IsAbstract && !t.IsInterface))
            {
                var interfaces = item.GetInterfaces();

                var isOperation = interfaces.Any(it => it == typeOperation);

                if (isOperation)
                {
                    // создаем эксземпляр объекта
                    var obj = Activator.CreateInstance(item);
                    // пытаемся превратить его в операцию
                    var operation = obj as IOperation;
                    // если удалось
                    if (operation != null)
                    {
                        // добавляем в список операций
                        operations.Add(operation);
                    }
                }
            }
        }

        /// <summary>
        /// Получить список имен операциий
        /// </summary>
        /// <returns></returns>
        public string[] GetOperNames()
        {
            return operations.Select(it => it.Name).ToArray();
        }

        /// <summary>
        /// Получить список имен операциий
        /// </summary>
        /// <returns></returns>
        [Obsolete("Будет удалено в след.версии")]
        public IOperation[] GetOpers()
        {
            return operations.ToArray();
        }

        public double Exec(string oper, double[] args)
        {
            // найти операцию в списке
            var operation = operations
                .FirstOrDefault(o => o.Name == oper);

            // если не найдено - возвращает ошибку
            if (operation == null)
                return double.NaN;

            // если нашли
            // передаем ей аргументы и вычисляем результат
            var result = operation.Exec(args);

            // возвращаем результат
            return result;
        }
    }
}
