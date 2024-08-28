using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_calculatorTests.Inputs;

[TestClass()]
public class NumberInputsTests
{
    private string result = "";

    private void GetOutput(object? sender, OutputEventArgs e)
    {
        result = e.OutputExpression;
    }

    [TestMethod()]
    [Timeout(2000)]
    [DataRow("", "3", "3")]
    [DataRow("1+2", "3", "1+23")]
    [DataRow("1*23.", "5", "1*23.5")]
    [DataRow("(1+2.3)", "4", "(1+2.3)*4")]
    [DataRow("1+2.3*i", "5", "1+2.3*i*5")]
    public void GeneratedNewExpressionTest(string expression, string number, string expected)
    {
        Calculator calculator = new()
        {
            expression = expression
        };
        calculator.OutputEvent += GetOutput;
        calculator.GetCharacter(number);

        Assert.AreEqual(expected, result);
    }
}
