namespace simple_calculator.Inputs;

/// <summary>
/// 清除键输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class ClearInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入清除键时的处理方法
    /// </summary>
    /// <param name="clear">清除键</param>
    /// <returns>清除后的字符串</returns>
    public override string GeneratedNewExpression(string clear)
    {
        return "";
    }
}
