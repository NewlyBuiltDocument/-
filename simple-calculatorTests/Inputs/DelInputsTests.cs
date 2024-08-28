using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.Inputs;

[TestClass()]
public class DelInputsTests
{
    private string result = "";

    private void GetOutput(object? sender, OutputEventArgs e)
    {
        result = e.OutputExpression;
    }

    [TestMethod()]
    [Timeout(2000)]
    [DataRow("1+2", "1+")]
    [DataRow("1+2-", "1+2")]
    [DataRow("1+2*", "1+2")]
    [DataRow("1+2/", "1+2")]
    [DataRow("1+2^", "1+2")]
    [DataRow("1+2*(", "1+2*")]
    [DataRow("1+2*cos(5)", "1+2*cos(5")]
    [DataRow("1+2*cos(", "1+2*")]
    public void GeneratedNewExpressionTest(string expression, string expected)
    {
        Calculator calculator = new()
        {
            expression = expression
        };
        calculator.OutputEvent += GetOutput;
        calculator.GetCharacter("DEL");

        Assert.AreEqual(expected, result);
    }
}
