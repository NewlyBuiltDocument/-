namespace simple_calculator.Functions;

/// <summary>
/// 添加函数到列表功能类
/// </summary>
/// <param name="plot">画图计算器类</param>
public class AddFuncToList(Plot plot) : BaseFunctionType(plot)
{
    /// <summary>
    /// 添加函数到函数列表
    /// </summary>
    public override void Function()
    {
        if (plot.expression == "")
        {
            MessageBox.Show("请输入函数！");
            return;
        }
        else if (!plot.expression.Contains('x'))
        {
            MessageBox.Show("请输入含有x的函数！");
            return;
        }
        else
        {
            List<string> newFuncList = plot.functionList;
            newFuncList.Add("y=" + plot.expression);
            plot.ModifyFuncList(newFuncList);
        }
    }

    public override void Function(string args)
    {
        throw new NotImplementedException();
    }
}
