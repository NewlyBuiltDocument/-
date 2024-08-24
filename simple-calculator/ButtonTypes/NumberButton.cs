using simple_calculator;

/// <summary>
/// 数字按钮类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public class NumberButton(CalForm calForm) : BaseInputButton(calForm)
{
    
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 输入数字时的处理方法
    /// </summary>
    /// <param name="number">数字</param>
    public override void GeneratedNewExpression(string number)
    {
        if (calForm.display.Length == 0)
        {
            InputEvent?.Invoke(calForm.display + number);
        }
        else if (calForm.display[^1] == ')')
        {
            InputEvent?.Invoke(calForm.display + "*" + number);
        }
        else
        {
            InputEvent?.Invoke(calForm.display + number);
        }
    }

    public override void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        GeneratedNewExpression(button.Text);
    }
}
