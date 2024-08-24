using System.Text.RegularExpressions;
using simple_calculator;

/// <summary>
/// 符号按钮类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public class SymbolButton(CalForm calForm) : BaseInputButton(calForm)
{
    
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 输入符号时的处理方法
    /// </summary>
    /// <param name="symbol">符号</param>
    public override void GeneratedNewExpression(string symbol)
    {
        if (calForm.display.Length == 0)
        {
            InputEvent?.Invoke(symbol);
        }
        else if (Regex.Match(calForm.display, @"[\*/^]$", RegexOptions.Compiled).Success)
        {
            InputEvent?.Invoke(calForm.display + "(" + symbol);
        }
        else if (Regex.Match(calForm.display, @"[+\-]$", RegexOptions.Compiled).Success)
        {
            InputEvent?.Invoke(calForm.display.Remove(calForm.display.Length - 1) + symbol);
        }
        else
        {
            InputEvent?.Invoke(calForm.display + symbol);
        }
    }

    public override void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        GeneratedNewExpression(button.Text);
    }
}
