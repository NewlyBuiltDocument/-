using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.Inputs;

[TestClass()]
public class RightBracketInputsTests
{
    private string result = "";

    private void GetOutput(object? sender, OutputEventArgs e)
    {
        result = e.OutputExpression;
    }

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
        Calculator calculator = new()
        {
            expression = expression
        };
        calculator.OutputEvent += GetOutput;
        calculator.GetCharacter(")");

        Assert.AreEqual(expected, result);
    }
}