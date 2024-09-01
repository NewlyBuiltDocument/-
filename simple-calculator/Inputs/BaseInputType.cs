namespace simple_calculator.Inputs;

/// <summary>
/// 输入处理基类
/// </summary>
/// <param name="calculator">计算器类</param>
public abstract class BaseInputType(Calculator calculator)
{
    /// <summary>
    /// 计算器类
    /// </summary>
    public readonly Calculator calculator = calculator;

    /// <summary>
    /// 根据输入内容生成新的表达式
    /// </summary>
    /// <param name="content">输入内容</param>
    /// <returns>新的字符串</returns>
    public abstract string GeneratedNewExpression(string content);
}
