using System.Text.RegularExpressions;
using simple_calculator;

/// <summary>
/// 小数点按钮类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public class DotButton(CalForm calForm) : BaseInputButton(calForm)
{
    
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 输入小数点时的处理方法
    /// </summary>
    /// <param name="dot">小数点</param>
    public override void GeneratedNewExpression(string dot)
    {
        if (calForm.display[^1] == '.')
        {
            InputEvent?.Invoke(calForm.display);
        }
        //如果最后一个字符是运算符，补全0
        else if (Regex.Match(calForm.display, @"[+\-\*/^(]$", RegexOptions.Compiled).Success)
        {
            InputEvent?.Invoke(calForm.display + "0.");
        }
        //如果最后一串数字中已经有小数点，不再添加
        else if (Regex.Match(calForm.display, @"\.[0-9]+?$", RegexOptions.Compiled).Success)
        {
            InputEvent?.Invoke(calForm.display);
        }
        else
        {
            InputEvent?.Invoke(calForm.display + ".");
        }
    }

    public override void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        GeneratedNewExpression(button.Text);
    }
}
