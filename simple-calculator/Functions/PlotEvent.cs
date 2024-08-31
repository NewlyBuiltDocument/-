namespace simple_calculator.Functions;

public class PlotEvent(Plot plot) : BaseFunctionType(plot)
{
    public override void Function()
    {
        plot.SendPlotEvent();
    }

    public override void Function(string args)
    {
        throw new NotImplementedException();
    }
}
