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
    public class SymbolButtonTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("1+2", "+", "1+2+")]
        [DataRow("1+2", "-", "1+2-")]
        [DataRow("", "-", "-")]
        [DataRow("1+", "-", "1-")]
        [DataRow("1-", "+", "1+")]
        [DataRow("1-", "-", "1-")]
        [DataRow("2*", "+", "2*(+")]
        [DataRow("3^", "-", "3^(-")]
        public void GeneratedNewExpressionTest(string expression, string op, string expected)
        {
            CalForm calForm = new()
            {
                display = expression
            };
            SymbolButton symbolButton = new(calForm);
            symbolButton.GeneratedNewExpression(op);
            string result = calForm.display;
            Assert.AreEqual(expected, result);
        }
    }
}