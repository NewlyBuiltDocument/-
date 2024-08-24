﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculator.Tests;

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
    [DataRow("(-2)*7", -14)]
    [DataRow("7^(-2)", 1 / 49.0)]
    [DataRow("7^(+2)", 49)]
    [DataRow("+2-5*(-7)", 37)]
    [DataRow("(+3)*(-5)", -15)]
    [DataRow("(-3)*(-5)", 15)]
    public void CalculateTest(string input, double expected)
    {
        double result = AnyCalculate.Calculate(input);
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
        double result = AnyCalculate.Calculate(input);
        double expected = Math.Pow(baseNumber, exponent);
        Assert.AreEqual(expected, result);
    }

    [TestMethod()]
    [Timeout(2000)]
    public void InvalidInputTest()
    {
        try
        {
            AnyCalculate.Calculate("3.5+2*");
            Assert.Fail();
        }
        catch {; }
        Assert.ThrowsException<DivideByZeroException>(() => AnyCalculate.Calculate("3.5/0"));
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
    public void ValidSymbolsTest(string expression, string op, string expected)
    {
        string result = CalForm.ValidSymbols(expression, op);
        Assert.AreEqual(expected, result);
    }

    [TestMethod()]
    [Timeout(2000)]
    [DataRow("", "3", "3")]
    [DataRow("1+2", "3", "1+23")]
    [DataRow("1*23.", "5", "1*23.5")]
    [DataRow("(1+2.3)", "4", "(1+2.3)*4")]
    public void ValidNumbersTest(string expression, string number, string expected)
    {
        string result = CalForm.ValidNumbers(expression, number);
        Assert.AreEqual(expected, result);
    }
}
