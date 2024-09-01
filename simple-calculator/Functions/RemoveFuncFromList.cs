namespace simple_calculator.Functions;

/// <summary>
/// 移除列表函数功能类
/// </summary>
/// <param name="plot">画图计算器类</param>
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
