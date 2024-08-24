using simple_calculator;

/// <summary>
/// 输入按钮类型基类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public abstract class BaseInputButton(CalForm calForm): BaseButtonTypes(calForm)
{
    public abstract void GeneratedNewExpression(string content);
}
