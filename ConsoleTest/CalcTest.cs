using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestCalc;


namespace ConsoleTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            var calc = new Calc();
            double[] args = { 10, 5 };

            double resS = calc.Exec("Sum", args);
            Assert.AreEqual(15, resS);
        }

        [TestMethod]
        public void TestMin()
        {
            var calc = new Calc();
            double[] args = { 10, 5 };

            double resM = calc.Exec("Min", args);
            Assert.AreEqual(5, resM);
        }

        [TestMethod]
        public void TestDiv()
        {
            var calc = new Calc();
            double[] args = { 10, 5 };

            double resD = calc.Exec("Div", args);
            Assert.AreEqual(2, resD);
        }

        [TestMethod]
        public void TestMul()
        {
            var calc = new Calc();
            double[] args = { 10, 5 };

            double resMu = calc.Exec("Mul", args);
            Assert.AreEqual(50, resMu);
        }
    }
}
