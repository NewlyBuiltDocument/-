using System.Text.RegularExpressions;

namespace simple_calculator.Inputs;

/// <summary>
/// 符号输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class SymbolInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入符号时的处理方法
    /// </summary>
    /// <param name="symbol">输入的符号</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string symbol)
    {   
        if (calculator.expression.Length == 0)
        {
            return symbol;
        }
        // 在乘除号或幂运算符后输入符号时，自动补全左括号
        else if (Regex.Match(calculator.expression, @"[\*/^]$", RegexOptions.Compiled).Success)
        {
            return calculator.expression + "(" + symbol;
        }
        // 在加减号后输入符号时，替换最后一个符号
        else if (Regex.Match(calculator.expression, @"[+\-]$", RegexOptions.Compiled).Success)
        {
            return calculator.expression.Remove(calculator.expression.Length - 1) + symbol;
        }
        else
        {
            return calculator.expression + symbol;
        }
    }
}
