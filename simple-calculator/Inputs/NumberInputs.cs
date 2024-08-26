namespace simple_calculator.Inputs;

/// <summary>
/// 数字输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class NumberInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入数字时的处理方法
    /// </summary>
    /// <param name="number">输入的数字</param>
    /// <returns>处理输入后的字符串</returns>
    public override string GeneratedNewExpression(string number)
    {
        if (calculator.expression.Length == 0)
        {
            return calculator.expression + number;
        }
        // 在右括号后输入数字时，自动补全乘号
        else if (calculator.expression[^1] == ')')
        {
            return calculator.expression + "*" + number;
        }
        else
        {
            return calculator.expression + number;
        }
    }
}
