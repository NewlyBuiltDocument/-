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
    public class RightBracketButtonTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("3.5+(2", "3.5+(2)")]
        [DataRow("3.5+2", "3.5+2")]
        [DataRow("3.5+(", "3.5+(")]
        [DataRow("(3.5+(2)", "(3.5+(2))")]
        [DataRow("(3.5+2)", "(3.5+2)")]
        [DataRow("(3.5+", "(3.5+")]
        [DataRow("(3.5-", "(3.5-")]
        [DataRow("(3.5*", "(3.5*")]
        [DataRow("(3.5/", "(3.5/")]
        [DataRow("(3.5^", "(3.5^")]
        public void GeneratedNewExpressionTest(string expression, string expected)
        {
            CalForm calForm = new()
            {
                display = expression
            };
            RightBracketButton rightBracketButton = new(calForm);
            rightBracketButton.GeneratedNewExpression(")");
            string result = calForm.display;
            Assert.AreEqual(expected, result);
        }
    }
}