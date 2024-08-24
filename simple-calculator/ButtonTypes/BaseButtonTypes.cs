using simple_calculator;

/// <summary>
/// 按钮类型基类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public abstract class BaseButtonTypes(CalForm calForm)
{
    public readonly CalForm calForm = calForm;

    public abstract void ButtonClick(object sender, EventArgs e);
}
