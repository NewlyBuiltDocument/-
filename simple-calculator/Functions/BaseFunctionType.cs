namespace simple_calculator.Functions;

/// <summary>
/// 功能处理基类
/// </summary>
/// <param name="calculator">计算器类</param>
public abstract class BaseFunctionType(Calculator calculator)
{
    /// <summary>
    /// 计算器类
    /// </summary>
    public readonly Calculator calculator = calculator;

    /// <summary>
    /// 执行的功能
    /// </summary>
    public abstract void Function();

    /// <summary>
    /// 执行的功能
    /// </summary>
    /// <param name="args">需要的参数</param>
    public abstract void Function(string args);
}
