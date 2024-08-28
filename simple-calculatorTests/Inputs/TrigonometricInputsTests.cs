using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.Inputs;

[TestClass()]
public class TrigonometricInputsTests
{
    private string result = "";

    private void GetOutput(object? sender, OutputEventArgs e)
    {
        result = e.OutputExpression;
    }

    [TestMethod()]
    [Timeout(2000)]
    [DataRow("", "sin(")]
    [DataRow("13.", "13.")]
    [DataRow("13.5", "13.5*sin(")]
    [DataRow("13.5+", "13.5+sin(")]
    [DataRow("sin(13.5+3)", "sin(13.5+3)*sin(")]
    [DataRow("3+2*i", "3+2*i*sin(")]
    public void GeneratedNewExpressionTest(string expression, string expected)
    {
        Calculator calculator = new()
        {
            expression = expression
        };
        calculator.OutputEvent += GetOutput;
        calculator.GetCharacter("sin");

        Assert.AreEqual(expected, result);
    }
}
