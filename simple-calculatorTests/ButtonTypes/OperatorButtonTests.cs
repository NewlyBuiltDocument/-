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
    public class OperatorButtonTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("1+2", "1+2*")]
        [DataRow("", "")]
        [DataRow("1+", "1+")]
        [DataRow("1+2+", "1+2+")]
        [DataRow("1+2-", "1+2-")]
        [DataRow("1+2*", "1+2*")]
        [DataRow("1+2/", "1+2/")]
        [DataRow("1+2^", "1+2^")]
        [DataRow("1+2(", "1+2(")]
        public void GeneratedNewExpressionTest(string expression, string expected)
        {
            CalForm calForm = new()
            {
                display = expression
            };
            OperatorButton operatorButton = new(calForm);
            operatorButton.GeneratedNewExpression("*");
            string result = calForm.display;
            Assert.AreEqual(expected, result);
        }
    }
}