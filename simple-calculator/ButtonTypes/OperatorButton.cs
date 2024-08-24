using System.Text.RegularExpressions;
using simple_calculator;

/// <summary>
/// 操作符按钮类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public class OperatorButton(CalForm calForm) : BaseInputButton(calForm)
{
    
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 输入操作符时的处理方法
    /// </summary>
    /// <param name="op">操作符</param>
    public override void GeneratedNewExpression(string op)
    {
        switch (op)
        {
            case "×":
                op = "*";
                break;
            case "÷":
                op = "/";
                break;
            default:
                break;
        }
        
        if (calForm.display.Length == 0)
        {
            InputEvent?.Invoke(calForm.display);
        }
        else if (Regex.Match(calForm.display, @"[+\-\*/^(]$", RegexOptions.Compiled).Success)
        {
            InputEvent?.Invoke(calForm.display);
        }
        else
        {
            InputEvent?.Invoke(calForm.display + op);
        }
    }

    public override void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        GeneratedNewExpression(button.Text);
    }
}
