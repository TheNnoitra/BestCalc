using BestCalc;
using ItUniverCalcCore.Interfaces;
using ItUniverCalcWinFormApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//CONSTRAINT[FK_History_Operation] FOREIGN KEY([Operation]) REFERENCES[dbo].[Operation] ([Id])

namespace ItUniverCalcWinFormApp
{
    public partial class Form1 : Form
    {
        private Calc calc { get; set; }

        private IOperation lastOperation { get; set; }

        public Form1()
        {
            InitializeComponent();
            cbOperation.Items.Clear();

            #region Загрузка операций

            calc = new Calc();
            var operations = calc.GetOperNames();
            var own = calc.GetSettings();
            var ow = own.Select(n => n.Name).ToArray();
            foreach (var item in own.Select(o => o.Owner).ToArray())
            {
                if (item == "IT Univer Co.")
                {
                    cbOperation.ForeColor = System.Drawing.Color.Green;
                    cbOperation.Items.AddRange(ow);
                }
                cbOperation.ForeColor = System.Drawing.Color.Green; ;
                cbOperation.Items.AddRange(operations.Except(ow).ToArray());
            }

            //cbOperation.DataSource = operations;

            //var superOperations = superoperations.OfType<SuperOperation>();

            //cbOperation.Items.AddRange(
            //    own
            //        .Select(s => s.Owner)
            //        .ToArray()
            //);

            //cbOperation.Items.AddRange(
            //    operations
            //        .Except(own)
            //        .Select(s => s.Name)
            //        .ToArray()
            //);


            //переводит фокус (каретку) на список операций.
            cbOperation.Select();

            #endregion
            //resCount();
            
            #region загрузка истории
            lbHistory.DataSource = IHelper.GetAll();
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
            var oper = $"{cbOperation.SelectedItem}";
            // получить данные
            var args = tbInput.Text
                .Trim()
                .Split(' ')
                .Select(str => Convert.ToDouble(str))
                .ToArray();

            // вычислить результат
            var result = calc.Exec(oper, args);

            // показать результат
            tbResult.Text = $"{result}";
            //lbHistory.Items.Add(result);

            // добавить в историю в БД
            IHelper.AddToHistory(oper, args, result);

            // добавить в историю на форму
            //lbHistory.Items.Clear();
            //lbHistory.DataSource = IHelper.GetAll();

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

        /// <summary>
        /// Расчет по нажанию на Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnCalc_Click(sender, e);
            }
        }

    }
}
