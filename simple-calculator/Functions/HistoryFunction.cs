namespace simple_calculator.Functions;

public class HistoryFunction(Calculator calculator) : BaseFunctionType(calculator)
{
    /// <summary>
    /// 显示历史记录
    /// </summary>
    public override void Function()
    {
        HistoryForm historyForm = new();
        historyForm.ShowDialog();
    }
}