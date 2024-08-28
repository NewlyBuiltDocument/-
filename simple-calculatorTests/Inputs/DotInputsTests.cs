using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.Inputs;

[TestClass()]
public class DotInputsTests
{
    private string result = "";

    private void GetOutput(object? sender, OutputEventArgs e)
    {
        result = e.OutputExpression;
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
    [DataRow("", "0.")]
    [DataRow("1+3*i", "1+3*i")]
    public void GeneratedNewExpressionTest(string expression, string expected)
    {
        Calculator calculator = new()
        {
            expression = expression
        };
        calculator.OutputEvent += GetOutput;
        calculator.GetCharacter(".");

        Assert.AreEqual(expected, result);
    }
}
