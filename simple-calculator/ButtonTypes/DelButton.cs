using simple_calculator;

public class DelButton(CalForm calForm) : BaseButtonTypes(calForm)
{
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 删除最后一个字符
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public override void ButtonClick(object sender, EventArgs e)
    {
        if (calForm.display.Length > 0)
        {
            InputEvent?.Invoke(calForm.display.Remove(calForm.display.Length - 1));
        }
    }
}
