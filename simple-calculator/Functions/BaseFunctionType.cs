namespace simple_calculator.Functions;

/// <summary>
/// 功能处理基类
/// </summary>
/// <param name="calculator">计算器类</param>
public abstract class BaseFunctionType(Calculator calculator)
{
    public readonly Calculator calculator = calculator;

    public abstract void Function();
    public abstract void Function(string args);
}
