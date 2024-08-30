using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace simple_calculatorTests.Functions;

[TestClass()]
public class CalculationTests
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
        double result = Calculation.Calculate(input).Real;
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
        double result = Calculation.Calculate(input).Real;
        double expected = Math.Pow(baseNumber, exponent);
        Assert.AreEqual(expected, result);
    }
    [TestMethod()]
    [Timeout(2000)]
    [DataRow("sin(i)")]
    public void CalculateImaginaryTest(string input)
    {
        Assert.AreEqual(Calculation.Calculate(input), Complex.Sin(Complex.ImaginaryOne));
    }
    [TestMethod()]
    [Timeout(2000)]
    public void InvalidInputTest()
    {
        try
        {
            Calculation.Calculate("3.5+2*");
            Assert.Fail();
        }
        catch {; }
        Assert.ThrowsException<DivideByZeroException>(() => Calculation.Calculate("3.5/0"));
    }
}