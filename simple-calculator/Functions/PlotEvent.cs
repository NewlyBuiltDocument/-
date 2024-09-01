namespace simple_calculator.Functions;

/// <summary>
/// 画图功能类
/// </summary>
/// <param name="plot">画图计算器类</param>
public class PlotEvent(Plot plot) : BaseFunctionType(plot)
{
    /// <summary>
    /// 触发画图事件
    /// </summary>
    public override void Function()
    {
        plot.SendPlotEvent();
    }

    public override void Function(string args)
    {
        throw new NotImplementedException();
    }
}
