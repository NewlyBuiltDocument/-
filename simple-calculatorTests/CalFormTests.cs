using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculator.Tests
{
    [TestClass()]
    public class CalFormTests
    {
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("1+2", 3.0)]
        [DataRow("4.5-6.17", -1.67)]
        [DataRow("3.5*-2.6", -9.1)]
        [DataRow("3.5*2.6", 9.1)]
        [DataRow("2/9", 2.0 / 9.0)]
        [DataRow("(3.5+2)*4", (3.5 + 2) * 4)]
        [DataRow("3.5+2*4", 3.5 + 2 * 4)]
        [DataRow("((3.5+2)*4-1)/6", ((3.5 + 2) * 4 - 1) / 6.0)]
        [DataRow("((3.5+2)^2-1)/6", (30.25 - 1) / 6.0)]
        [DataRow("-2^2", -4)]
        public void CalculateTest(string input, double expected)
        {
            double result = CalForm.Calculate(input);
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod()]
        [Timeout(2000)]
        [DataRow("3^2", 3, 2)]
        [DataRow("-2^3", -2, 3)]
        [DataRow("2^(-2)", 2, -2)]
        [DataRow("16^0.5", 16, 0.5)]
        [DataRow("3.2^2.5", 3.2, 2.5)]
        public void CalculatePowerTest(string input, double baseNumber, double exponent)
        {
            double result = CalForm.Calculate(input);
            double expected = Math.Pow(baseNumber, exponent);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [Timeout(2000)]
        public void InvalidInputTest()
        {
            try
            {
                CalForm.Calculate("3.5+2*");
                Assert.Fail();
            }
            catch {; }
        }

        [TestMethod()]
        [Timeout(2000)]
        [DataRow("3.5+(2)", "3.5+(2)")]
        [DataRow("3.5+2)", "3.5+2")]
        [DataRow("3.5+()", "3.5+(")]
        [DataRow("(3.5+(2))", "(3.5+(2))")]
        [DataRow("(3.5+2))", "(3.5+2)")]
        [DataRow("(3.5+)", "(3.5+")]
        [DataRow("(3.5-)", "(3.5-")]
        [DataRow("(3.5*)", "(3.5*")]
        [DataRow("(3.5/)", "(3.5/")]
        [DataRow("(3.5^)", "(3.5^")]
        public void ValidRightBracketsTest(string expression, string expected)
        {
            string result = CalForm.ValidRightBrackets(expression);
            Assert.AreEqual(expected, result);
        }

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
        public void ValidDotTest(string expression, string expected)
        {
            string result = CalForm.ValidDot(expression);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [Timeout(2000)]
        [DataRow("", "(")]
        [DataRow("13.", "13.")]
        [DataRow("13.5", "13.5*(")]
        [DataRow("13.5+", "13.5+(")]
        public void ValidLeftBracketTest(string expression, string expected)
        {
            string result = CalForm.ValidLeftBrackets(expression);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [Timeout(2000)]
        [DataRow("1+2", true)]
        [DataRow("", false)]
        [DataRow("1+", false)]
        [DataRow("1+2+", false)]
        [DataRow("1+2-", false)]
        [DataRow("1+2*", false)]
        [DataRow("1+2/", false)]
        [DataRow("1+2^", false)]
        [DataRow("1+2(", false)]
        public void CanInsertOperatorTest(string expression, bool expected)
        {
            bool result = CalForm.CanInsertOperator(expression);
            Assert.AreEqual(expected, result);
        }
    }
}