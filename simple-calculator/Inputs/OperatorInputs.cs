using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 操作符输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class OperatorInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入操作符时的处理方法
    /// </summary>
    /// <param name="op">操作符</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string op)
    {   
        // 当输入为空时，不允许输入
        if (calculator.expression.Length == 0)
        {
            return calculator.expression;
        }
        // 当上一个输入为符号或左括号时，不允许输入
        else if (Regex.Match(calculator.expression, @"[+\-\*/^(]$", RegexOptions.Compiled).Success)
        {
            return calculator.expression;
        }
        else
        {
            return calculator.expression + op;
        }
    }
}
