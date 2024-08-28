using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 删除键输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class DelInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入删除键时的处理方法
    /// </summary>
    /// <param name="del">删除键</param>
    /// <returns>删除后的字符串</returns>
    public override string GeneratedNewExpression(string del)
    {
        if (calculator.expression.Length == 0)
        {
            return calculator.expression;
        }
        else if (Regex.Match(calculator.expression, @"sin\($|cos\($|tan\($", RegexOptions.Compiled).Success)
        {
            return calculator.expression[..^4];
        }
        else
        {
            return calculator.expression[..^1];
        }
    }
}
