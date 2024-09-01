using simple_calculator.Forms;

namespace simple_calculator.Functions;

/// <summary>
/// 打开画图计算器功能类
/// </summary>
/// <param name="calculator">计算器类</param>
public class ShowPlotFunction(Calculator calculator) : BaseFunctionType(calculator)
{
    /// <summary>
    /// 显示画图窗口
    /// </summary>
    public override void Function()
    {
        GraForm graForm = new();
        graForm.ShowDialog();
    }

    public override void Function(string args)
    {
        throw new NotImplementedException();
    }
}
