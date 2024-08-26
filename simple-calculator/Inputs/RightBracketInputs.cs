using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 右括号输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class RightBracketInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入右括号时的处理方法
    /// </summary>
    /// <param name="rightBracket">右括号</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string rightBracket)
    {
        string expression = calculator.expression + ")";
        // 如果左括号数量小于右括号数量，删除右括号
        if (Regex.Count(expression, @"\(", RegexOptions.Compiled) < Regex.Count(expression, @"\)", RegexOptions.Compiled))
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft | RegexOptions.Compiled);
            expression = expression.Remove(match2.Index, 1);
            return expression;
        }
        // 如果右括号前面是运算符或左括号，删除右括号
        if (Regex.Match(expression, @"[+\-\*/^(]\)", RegexOptions.Compiled).Success)
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft | RegexOptions.Compiled);
            expression = expression.Remove(match2.Index, 1);
        }
        return expression;
    }
}
