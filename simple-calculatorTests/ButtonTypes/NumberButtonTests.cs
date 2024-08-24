using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.ButtonTypes
{
    [TestClass()]
    public class NumberButtonTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("", "3", "3")]
        [DataRow("1+2", "3", "1+23")]
        [DataRow("1*23.", "5", "1*23.5")]
        [DataRow("(1+2.3)", "4", "(1+2.3)*4")]
        public void GeneratedNewExpressionTest(string expression, string number, string expected)
        {
            CalForm calForm = new()
            {
                display = expression
            };
            NumberButton numberButton = new(calForm);
            numberButton.GeneratedNewExpression(number);
            string result = calForm.display;
            Assert.AreEqual(expected, result);
        }
    }
}