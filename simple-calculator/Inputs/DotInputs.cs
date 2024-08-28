using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 小数点输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class DotInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入小数点时的处理方法
    /// </summary>
    /// <param name="dot">小数点</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string dot)
    {
        if (calculator.expression.Length == 0)
        {
            return "0.";
        }
        // 如果上一个输入为小数点或i，不允许输入
        else if (calculator.expression[^1] == '.' || calculator.expression[^1] == 'i')
        {
            return calculator.expression;
        }
        // 如果上一个输入为符号，自动补全0
        else if (Regex.Match(calculator.expression, @"[+\-\*/^(]$", RegexOptions.Compiled).Success)
        {
            return calculator.expression + "0.";
        }
        // 如果之前的输入为数字且已有小数点，不允许输入
        else if (Regex.Match(calculator.expression, @"\.[0-9]+?$", RegexOptions.Compiled).Success)
        {
            return calculator.expression;
        }
        else
        {
            return calculator.expression + ".";
        }
    }
}
