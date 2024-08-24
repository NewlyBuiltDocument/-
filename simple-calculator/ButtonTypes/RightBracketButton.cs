using System.Text.RegularExpressions;
using simple_calculator;

/// <summary>
/// 右括号按钮类
/// </summary>
/// <param name="calForm">计算器窗体</param>
public class RightBracketButton(CalForm calForm) : BaseInputButton(calForm)
{
    
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 输入右括号时的处理方法
    /// </summary>
    /// <param name="RightBracket">右括号</param>
    public override void GeneratedNewExpression(string RightBracket)
    {
        string expression = calForm.display + ")";
        if (Regex.Count(expression, @"\(", RegexOptions.Compiled) < Regex.Count(expression, @"\)", RegexOptions.Compiled))
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft | RegexOptions.Compiled);
            expression = expression.Remove(match2.Index, 1);
            InputEvent?.Invoke(expression);
        }
        //如果右括号前面是运算符或左括号，删除右括号
        if (Regex.Match(expression, @"[+\-\*/^(]\)", RegexOptions.Compiled).Success)
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft | RegexOptions.Compiled);
            expression = expression.Remove(match2.Index, 1);
        }
        InputEvent?.Invoke(expression);
    }
    
    public override void ButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        GeneratedNewExpression(button.Text);
    }
}
