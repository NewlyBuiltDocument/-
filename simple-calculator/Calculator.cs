using System.Text.RegularExpressions;
using simple_calculator.Functions;
using simple_calculator.Inputs;

namespace simple_calculator;

/// <summary>
/// 计算器类
/// </summary>
public class Calculator
{
    /// <summary>
    /// 计算器当前的表达式
    /// </summary>
    public string expression = "";
    private BaseInputType? inputType = null;
    private BaseFunctionType? functionType = null;
    /// <summary>
    /// 输出字符串事件
    /// </summary>
    public event EventHandler<OutputEventArgs>? OutputEvent;

    /// <summary>
    /// 获取输入的类型，生成新的显示表达式，并触发输出事件
    /// </summary>
    /// <param name="input">新输入的字符</param>
    public void GetCharacter(string input)
    {
        inputType = GetInputType(input);
        expression = inputType.GeneratedNewExpression(input);
        OnOutputEvent(new OutputEventArgs(expression));
        if (inputType is EqualInputs)
        {
            expression = "";
        }
    }

    /// <summary>
    /// 获取功能类型，执行功能
    /// </summary>
    /// <param name="function">输入的功能名称</param>
    public void GetFunction(string function)
    {
        functionType = GetFunctionType(function);
        functionType.Function();
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
            "=" => new EqualInputs(this),
            string inputChar when Regex.Match(inputChar, @"[0-9]", RegexOptions.Compiled).Success => new NumberInputs(this),
            string inputChar when Regex.Match(inputChar, @"[+\-]", RegexOptions.Compiled).Success => new SymbolInputs(this),
            string inputChar when Regex.Match(inputChar, @"[\*/^]", RegexOptions.Compiled).Success => new OperatorInputs(this),
            "." => new DotInputs(this),
            "(" => new LeftBracketInputs(this),
            ")" => new RightBracketInputs(this),
            "sin" or "cos" or "tan" => new TrigonometricInputs(this),
            "i" => new ImaginaryInputs(this),
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
            "History" => new HistoryFunction(this),
            "Plot" => new ShowPlotFunction(this),
            _ => throw new ArgumentException("Invalid function")
        };
    }

    /// <summary>
    /// 触发输出事件
    /// </summary>
    /// <param name="e">输出事件参数</param>
    protected virtual void OnOutputEvent(OutputEventArgs e)
    {
        OutputEvent?.Invoke(this, e);
    }
}

/// <summary>
/// 输出事件参数类
/// </summary>
/// <param name="expression">输出的字符串</param>
public class OutputEventArgs(string expression) : EventArgs
{
    /// <summary>
    /// 输出的字符串
    /// </summary>
    public string OutputExpression { get; set; } = expression;
}
