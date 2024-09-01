using System.Text.RegularExpressions;
using simple_calculator.Functions;
using simple_calculator.Inputs;

namespace simple_calculator;

/// <summary>
/// 画图计算器类
/// </summary>
public class Plot : Calculator
{
    private BaseInputType? inputType = null;
    private BaseFunctionType? functionType = null;
    /// <summary>
    /// 需要画图的函数列表
    /// </summary>
    public List<string> functionList = [];
    /// <summary>
    /// 更新函数列表事件
    /// </summary>
    public event EventHandler<FuncListEventArgs>? UpdateListEvent;
    /// <summary>
    /// 画图事件
    /// </summary>
    public event EventHandler<FuncListEventArgs>? PlotEvent;

    /// <summary>
    /// 获取输入的类型，生成新的显示表达式，并触发输出事件
    /// </summary>
    /// <param name="input">新输入的字符</param>
    public new void GetCharacter(string input)
    {
        inputType = GetInputType(input);
        expression = inputType.GeneratedNewExpression(input);
        OnOutputEvent(new OutputEventArgs(expression));
    }

    /// <summary>
    /// 获取功能类型，执行功能
    /// </summary>
    /// <param name="function">输入的功能名称</param>
    public new void GetFunction(string function)
    {
        functionType = GetFunctionType(function);
        functionType.Function();
        if (functionType is AddFuncToList)
        {
            expression = "";
            OnOutputEvent(new OutputEventArgs(expression));
        }
    }

    /// <summary>
    /// 获取功能类型，执行功能
    /// </summary>
    /// <param name="function">输入的功能名称</param>
    /// <param name="args">需要传递的参数</param>
    public void GetFunction(string function, string args)
    {
        functionType = GetFunctionType(function);
        functionType.Function(args);
    }

    /// <summary>
    /// 更新函数列表
    /// </summary>
    /// <param name="funcList">修改后的函数列表</param>
    public void ModifyFuncList(List<string> funcList)
    {
        functionList = funcList;
        OnUpdateListEvent(new FuncListEventArgs(functionList));
    }

    /// <summary>
    /// 触发画图事件
    /// </summary>
    public void SendPlotEvent()
    {
        OnPlotEvent(new FuncListEventArgs(functionList));
    }

    /// <summary>
    /// 根据输入获取输入类型
    /// </summary>
    /// <param name="input">输入的字符</param>
    /// <returns>输入类型</returns>
    /// <exception cref="ArgumentException"></exception>
    private BaseInputType GetInputType(string input)
    {
        return input switch
        {
            "Clear" => new ClearInputs(this),
            "DEL" => new DelInputs(this),
            string inputChar when Regex.Match(inputChar, @"[0-9]", RegexOptions.Compiled).Success => new NumberInputs(this),
            string inputChar when Regex.Match(inputChar, @"[+\-]", RegexOptions.Compiled).Success => new SymbolInputs(this),
            string inputChar when Regex.Match(inputChar, @"[\*/^]", RegexOptions.Compiled).Success => new OperatorInputs(this),
            "." => new DotInputs(this),
            "(" => new LeftBracketInputs(this),
            ")" => new RightBracketInputs(this),
            "x" => new VariableInputs(this),
            _ => throw new ArgumentException("Invalid input")
        };
    }

    /// <summary>
    /// 根据输入获取功能类型
    /// </summary>
    /// <param name="input">输入的字符</param>
    /// <returns>功能类型</returns>
    /// <exception cref="ArgumentException"></exception>    
    private BaseFunctionType GetFunctionType(string input)
    {
        return input switch
        {
            "↵" => new AddFuncToList(this),
            "Remove" => new RemoveFuncFromList(this),
            "Plot" => new PlotEvent(this),
            _ => throw new ArgumentException("Invalid function")
        };
    }

    /// <summary>
    /// 触发更新列表事件
    /// </summary>
    /// <param name="e">函数列表事件参数</param>
    protected virtual void OnUpdateListEvent(FuncListEventArgs e)
    {
        UpdateListEvent?.Invoke(this, e);
    }

    /// <summary>
    /// 触发更新列表事件
    /// </summary>
    /// <param name="e">函数列表事件参数</param>
    protected virtual void OnPlotEvent(FuncListEventArgs e)
    {
        PlotEvent?.Invoke(this, e);
    }
}

/// <summary>
/// 函数列表事件参数
/// </summary>
/// <param name="funcList">函数列表字符串</param>
public class FuncListEventArgs(List<string> funcList) : EventArgs
{
    /// <summary>
    /// 函数列表字符串
    /// </summary>
    public List<string> FuncList { get; set; } = funcList;
}
