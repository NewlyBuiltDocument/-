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
    public class LeftBracketButtonTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("", "(")]
        [DataRow("13.", "13.")]
        [DataRow("13.5", "13.5*(")]
        [DataRow("13.5+", "13.5+(")]
        public void GeneratedNewExpressionTest(string expression, string expected)
        {
            CalForm calForm = new()
            {
                display = expression
            };
            LeftBracketButton leftBracketButton = new(calForm);
            leftBracketButton.GeneratedNewExpression("(");
            string result = calForm.display;
            Assert.AreEqual(expected, result);
        }
    }
}