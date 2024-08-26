using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 左括号输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class LeftBracketInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入左括号时的处理方法
    /// </summary>
    /// <param name="leftBracket">左括号</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string leftBracket)
    {
        if (calculator.expression.Length == 0)
        {
            return "(";
        }
        // 如果最后一个字符是小数点，不允许输入
        else if (calculator.expression[^1] == '.')
        {
            return calculator.expression;
        }
        // 如果最后一个字符是数字或右括号，补全乘号
        else if (Regex.Match(calculator.expression, @"[0-9\)]$", RegexOptions.Compiled).Success)
        {
            return calculator.expression + "*(";
        }
        else
        {
            return calculator.expression + "(";
        }
    }
}
