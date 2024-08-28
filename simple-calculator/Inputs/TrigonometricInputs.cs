using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 三角函数输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class TrigonometricInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入三角函数时的处理方法
    /// </summary>
    /// <param name="triFunc">输入的三角函数</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string triFunc)
    {
        if (calculator.expression.Length == 0)
        {
            return triFunc + "(";
        }
        // 如果最后一个字符是小数点，不允许输入
        else if (calculator.expression[^1] == '.')
        {
            return calculator.expression;
        }
        // 如果最后一个字符是数字，i或右括号，补全乘号
        else if (Regex.Match(calculator.expression, @"[0-9\)i]$", RegexOptions.Compiled).Success)
        {
            return $"{calculator.expression}*{triFunc}(";
        }
        else
        {
            return calculator.expression + triFunc + "(";
        }
    }
}
