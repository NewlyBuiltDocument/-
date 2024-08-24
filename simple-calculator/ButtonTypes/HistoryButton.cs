using simple_calculator;

public class HistoryButton(CalForm calForm) : BaseButtonTypes(calForm)
{
    /// <summary>
    /// 显示历史记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public override void ButtonClick(object sender, EventArgs e)
    {
        HistoryForm historyForm = new();
        historyForm.ShowDialog();
    }
}
