using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.ButtonTypes
{
    [TestClass()]
    public class DotButtonTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("1+32344", "1+32344.")]
        [DataRow("1+3.", "1+3.")]
        [DataRow("1+", "1+0.")]
        [DataRow("1-", "1-0.")]
        [DataRow("1*", "1*0.")]
        [DataRow("1/", "1/0.")]
        [DataRow("1^", "1^0.")]
        [DataRow("1+341233.55433", "1+341233.55433")]
        public void GeneratedNewExpressionTest(string expression, string expected)
        {
            CalForm calForm = new()
            {
                display = expression
            };
            DotButton dotButton = new(calForm);
            dotButton.GeneratedNewExpression(".");
            string result = calForm.display;
            Assert.AreEqual(expected, result);
        }
    }
}