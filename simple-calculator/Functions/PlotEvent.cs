namespace simple_calculator.Functions;

/// <summary>
/// ��ͼ������
/// </summary>
/// <param name="plot">��ͼ��������</param>
public class PlotEvent(Plot plot) : BaseFunctionType(plot)
{
    /// <summary>
    /// ������ͼ�¼�
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
