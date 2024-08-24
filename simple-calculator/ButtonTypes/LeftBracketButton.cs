using System.Text.RegularExpressions;
using simple_calculator;

/// <summary>
/// 左括号按钮类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public class LeftBracketButton(CalForm calForm) : BaseInputButton(calForm)
{
    
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 输入左括号时的处理方法
    /// </summary>
    /// <param name="LeftBracket">左括号</param>
    public override void GeneratedNewExpression(string LeftBracket)
    {
        if (calForm.display.Length == 0)
        {
            InputEvent?.Invoke("(");
        }
        else if (calForm.display[^1] == '.')
        {
            InputEvent?.Invoke(calForm.display);
        }
        //如果最后一个字符是数字，补全乘号
        else if (Regex.Match(calForm.display, @"[0-9]$", RegexOptions.Compiled).Success)
        {
            InputEvent?.Invoke(calForm.display + "*(");
        }
        else
        {
            InputEvent?.Invoke(calForm.display + "(");
        }
    }

    public override void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        GeneratedNewExpression(button.Text);
    }
}
