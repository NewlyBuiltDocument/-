namespace simple_calculator.Functions;

public class RemoveFuncFromList(Plot plot) : BaseFunctionType(plot)
{
    public override void Function()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 从函数列表中移除函数
    /// </summary>
    /// <param name="args">需要移除的函数</param>
    public override void Function(string args)
    {
        List<string> newFuncList = plot.functionList;
        newFuncList.Remove(args);
        plot.ModifyFuncList(newFuncList);
    }
}
