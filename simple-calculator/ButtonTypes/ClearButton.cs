using simple_calculator;

public class ClearButton(CalForm calForm) : BaseButtonTypes(calForm)
{
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 清空输入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public override void ButtonClick(object sender, EventArgs e)
    {
        InputEvent?.Invoke("");
    }
}
