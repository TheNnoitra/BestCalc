using BestCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItUniverCalcWinFormApp
{
    public partial class Form1 : Form
    {
        private Calc calc { get; set; }
        public Form1()
        {
            InitializeComponent();

            #region Загрузка операций

            calc = new Calc();
            var operations = calc.GetOperNames();
            //cbOperation.Items.AddRange(operations);

            cbOperation.DataSource = operations;

            //переводит фокус (каретку) на список операций.
            cbOperation.Select();
            #endregion
        }


        /// <summary>
        /// Кнопка "Мне повезет!"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuck_Click(object sender, EventArgs e)
        {
            int iL = cbOperation.Items.Count;
            Random i = new Random();
            int p = i.Next(iL);
            cbOperation.SelectedIndex = p;
            tbResult.Text = "Мне повезет!";
            //открыть поле ввода чисел (tbInput) для редактирования
            tbInput.Enabled = true;
            //перевести каретку на поле ввода
            tbInput.Select();
        }


        /// <summary>
        /// Кнопка "Расчитать"
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">E</param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            //получаем операцию
            var oper = $"{cbOperation.SelectedItem}";

            //получаем данные
            var args = tbInput.Text
                .Trim()
                .Split(' ')
                .Select(str => Convert.ToDouble(str))
                .ToArray();

            //получаем результат
            var result = calc.Exec(oper, args);
            tbResult.Text = $"{result}";

            tbInput.Focus();
            tbInput.SelectAll();

        }


        /// <summary>
        /// Проверяет выбрана ли операция:
        /// если да - активация поля ввода чисел,
        /// если нет - поле все так же заблокированно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbOperation_DropDownClosed(object sender, EventArgs e)
        {
            var oper = $"{cbOperation.SelectedItem}";
            if (oper == "")
            { tbInput.Enabled = false; }
            else tbInput.Enabled = true;

            //переводит фокус (каретку) на поле ввода чисел.
            tbInput.Select();
        }


        /// <summary>
        /// Проверяет введены ли числа:
        /// если да - активация кнопки расчета,
        /// если нет - кнопка все так же заблокированна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            var oper = $"{tbInput.Text}";
            oper = oper.Trim();

            //проверка на левые символы (пробел между числами не учитывается)
            //если обнаружено !число, то кнопка блокируется.
            bool verification = true;
            char[] array = oper.ToCharArray();
            foreach (var item in array)
            {
                if (item != ' ')
                {
                    if (!char.IsDigit(item) == true)
                    {
                        verification = false;
                    }
                }
            }
            if (oper != "" && verification == true)
            {
                btnCalc.Enabled = true;
            }
            else btnCalc.Enabled = false;
        }


        /// <summary>
        /// Кнопка сброса.
        /// Удаляются данные из полей tbInput и tbOutput.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            tbInput.ResetText();
            tbResult.ResetText();
        }
    }
}
