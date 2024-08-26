using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.Inputs
{
    [TestClass()]
    public class LeftBracketInputsTests
    {
        private string result = "";

        private void GetOutput(object? sender, OutputEventArgs e)
        {
            result = e.OutputExpression;
        }

        [TestMethod()]
        [Timeout(2000)]
        [DataRow("", "(")]
        [DataRow("13.", "13.")]
        [DataRow("13.5", "13.5*(")]
        [DataRow("13.5+", "13.5+(")]
        [DataRow("(13.5+3)", "(13.5+3)*(")]
        public void GeneratedNewExpressionTest(string expression, string expected)
        {
            Calculator calculator = new()
            {
                expression = expression
            };
            calculator.OutputEvent += GetOutput;
            calculator.GetCharacter("(");

            Assert.AreEqual(expected, result);
        }
    }
}