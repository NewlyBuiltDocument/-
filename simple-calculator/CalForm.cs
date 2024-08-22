using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace simple_calculator;

/// <summary>
/// 窗体类，需为第一个类以便设计器渲染
/// </summary>
public partial class CalForm : Form
{
    //显示字符串
    public string display = "";
    
    public CalForm()
    {
        InitializeComponent();
        x = this.Width;
        y = this.Height;
        setTag(this);
    }

    //region 控件大小随窗体大小等比例缩放
    private float x;//定义当前窗体的宽度
    private float y;//定义当前窗体的高度
    private void setTag(Control cons)
    {
        foreach (Control con in cons.Controls)
        {
            con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
            if (con.Controls.Count > 0)
            {
                setTag(con);
            }
        }
    }
    private void setControls(float newx, float newy, Control cons)
    {
        //遍历窗体中的控件，重新设置控件的值
        foreach (Control con in cons.Controls)
        {
            //获取控件的Tag属性值，并分割后存储字符串数组
            if (con.Tag != null)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                //根据窗体缩放的比例确定控件的值
                con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }
    }
    private void CalForm_Resize(object sender, EventArgs e)
    {
        float newx = (this.Width) / x;
        float newy = (this.Height) / y;
        setControls(newx, newy, this);
    }

    //endregion

    private void CalForm_Load(object sender, EventArgs e)
    {
        UpdateDisplay();
    }

    /// <summary>
    /// 更新显示的内容
    /// </summary>
    private void UpdateDisplay()
    {
        DisplayText.Text = display;
    }
    public static string ValidRightBrackets(string expression)
    {
        string pattern = @"\(\)";
        Match match1 = Regex.Match(expression, pattern);
        if (match1.Success)
        {
            expression = Regex.Replace(expression, @"\)*", "");
        }
        if (Regex.Count(expression, @"\(") < Regex.Count(expression, @"\)"))
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft);
            expression = expression.Remove(match2.Index, 1);
        }
        return expression;
    }
    


    /// <summary>
    /// 按下等于时执行计算程序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void BtnEqual_Click(object sender, EventArgs e)
    {
        if (display.Length != 0)//如果为空：没有输入或已经得到结果，应当什么也不做
        {
            try
            {
                string ans = AnyCalculate.Calculate(display).ToString();
                display += "=";
                display += ans;
                UpdateDisplay();
                AddToHistory(display);
                display = "";//清空显示字符串，等待下一次输入
            }
            catch
            {
                MessageBox.Show("输入有误！");
            }
        }
    }

    /// <summary>
    /// 将计算结果添加到历史记录
    /// </summary>
    /// <param name="result">上一次结果的字符串</param>
    private static void AddToHistory(string result)
    {
        using SQLiteConnection conn = new(Program.myConnectionString);
        conn.Open();
        SQLiteCommand cmd = new();
        string insertStr = $"INSERT INTO history (results) VALUES ('{result}');";
        cmd = new SQLiteCommand(insertStr, conn);
        try { cmd.ExecuteNonQuery(); }
        catch (SQLiteException)
        {
            MessageBox.Show("无法添加到历史！");
        }
    }

    /// <summary>
    /// 显示历史记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnHistory_Click(object sender, EventArgs e)
    {
        HistoryForm historyForm = new();
        historyForm.ShowDialog();
    }

    /// <summary>
    /// 删除最后一个字符
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnDel_Click(object sender, EventArgs e)
    {
        if (display.Length > 0)
        {
            display = display.Remove(display.Length - 1);
            UpdateDisplay();
        }
    }

    /// <summary>
    /// 清空输入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnClear_Click(object sender, EventArgs e)
    {
        display = "";
        UpdateDisplay();
    }

    private void Btn0_Click(object sender, EventArgs e)
    {
        display += "0";
        UpdateDisplay();
    }

    private void Btn1_Click(object sender, EventArgs e)
    {
        display += "1";
        UpdateDisplay();
    }

    private void Btn2_Click(object sender, EventArgs e)
    {
        display += "2";
        UpdateDisplay();
    }

    private void Btn3_Click(object sender, EventArgs e)
    {
        display += "3";
        UpdateDisplay();
    }

    private void Btn4_Click(object sender, EventArgs e)
    {
        display += "4";
        UpdateDisplay();
    }

    private void Btn5_Click(object sender, EventArgs e)
    {
        display += "5";
        UpdateDisplay();
    }

    private void Btn6_Click(object sender, EventArgs e)
    {
        display += "6";
        UpdateDisplay();
    }

    private void Btn7_Click(object sender, EventArgs e)
    {
        display += "7";
        UpdateDisplay();
    }

    private void Btn8_Click(object sender, EventArgs e)
    {
        display += "8";
        UpdateDisplay();
    }

    private void Btn9_Click(object sender, EventArgs e)
    {
        display += "9";
        UpdateDisplay();
    }

    private void BtnDot_Click(object sender, EventArgs e)
    {
        display += ".";
        UpdateDisplay();
    }

    private void BtnLBracket_Click(object sender, EventArgs e)
    {
        display += "(";
        UpdateDisplay();
    }

    private void BtnRBracket_Click(object sender, EventArgs e)
    {
        display += ")";
        display = ValidRightBrackets(display);
        UpdateDisplay();
    }

    private void BtnPlus_Click(object sender, EventArgs e)
    {
        display += "+";
        UpdateDisplay();
    }

    private void BtnMinus_Click(object sender, EventArgs e)
    {
        display += "-";
        UpdateDisplay();
    }

    private void BtnTimes_Click(object sender, EventArgs e)
    {
        display += "*";
        UpdateDisplay();
    }

    private void BtnDivide_Click(object sender, EventArgs e)
    {
        display += "/";
        UpdateDisplay();
    }

    private void BtnExp_Click(object sender, EventArgs e)
    {
        display += "^";
        UpdateDisplay();
    }

}
/// <summary>
/// 计算方法类
/// </summary>
public static class AnyCalculate
{
    /// <summary>
    /// 查找在str中从startIndex开始首个不属于anyOf的字符
    /// </summary>
    /// <param name="str">要查找的字符串全集</param>
    /// <param name="anyOf">要查找字符目标集合</param>
    /// <param name="startIndex">查找开始位置</param>
    /// <returns>查找的结果，-1为没有找到</returns>
    public static int IndexNotOfAny(this string str, char[] anyOf, int startIndex)
    {
        for (int a = startIndex; a < str.Length; ++a)
        {
            char b = str[a];
            bool c = true;
            foreach (char d in anyOf)
            {
                if (b == d)
                {
                    c = false;
                    break;
                }
            }
            if (c) return a;
        }
        return -1;
    }
    /// <summary>
    /// 逆序查找在str中从startIndex开始的count个字符中首个不属于anyOf的字符
    /// </summary>
    /// <param name="str">要查找的字符串全集</param>
    /// <param name="anyOf">要查找字符目标集合</param>
    /// <param name="startIndex">查找开始位置</param>
    /// <param name="count">查找字符数量</param>
    /// <returns>查找的结果，-1为没有找到</returns>
    public static int LastIndexNotOfAny(this string str, char[] anyOf, int startIndex, int count)
    {
        for (int a = startIndex; a > startIndex - count; --a) 
        {
            char b = str[a];
            bool c = true;
            foreach (char d in anyOf)
            {
                if (b == d)
                {
                    c = false;
                    break;
                }
            }
            if (c) return a;
        }
        return -1;
    }
    /// <summary>
    /// 计数str中从startIndex开始的count个字符中为value的字符数
    /// </summary>
    /// <param name="str">要查找的字符串全集</param>
    /// <param name="Startindex">查找字符数量</param>
    /// <param name="count">查找开始位置</param>
    /// <param name="value">查找目标字符</param>
    /// <returns>查找的结果数量</returns>
    public static int Count(this string str, int Startindex, int count, char value = ' ')
    {
        return str.AsSpan(Startindex, count).Count(value);
    }
    /// <summary>
    /// 将str从startIndex开始的连续字符序列转换为以Base为基数的double类型数
    /// </summary>
    /// <param name="str">要转换的字符串全集</param>
    /// <param name="Base">基数</param>
    /// <returns>转换为的浮点数</returns>
    private static double Svtoty(ref string str, int Startindex = 0, int Base = 10)
    {
        double d = 0.0, e = Base;
        int? f = null, g = str.Length;
        for (; Startindex < g && (str[Startindex] >= '0' && str[Startindex] <= '9' || str[Startindex] == '.'); ++Startindex)
        {
            if (f != null) ++f;
            if (str[Startindex] == '.') f = 0;
            else
            {
                d *= e;
                d += str[Startindex] - '0';
            }
        }
        if (f != null)
            d /= Math.Pow(e, (double)f);
        return d;
    }
    /// <summary>
    /// 将str中数与符号分离
    /// </summary>
    /// <param name="str">要转换的字符串全集，转换为原字符串中的剩余符号集合</param>
    /// <returns>字符串中的浮点数集合</returns>
    private static List<double> Zhuan(ref string str)
    {
        List<double> a = [];
        str = str.Replace(" ", null);
        char[] c = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];
        for (int d = str.IndexOfAny(c), e; d != -1;)
        {
            e = str.IndexNotOfAny(c, d);
            a.Add(Svtoty(ref str, d));
            str = string.Concat(str.AsSpan(0, d), " ", e == -1 ? null : str.AsSpan(e));
            d = str.IndexOfAny(c);
        }
        return a;
    }
    /// <summary>
    /// 将范围中的算式计算为结果
    /// </summary>
    /// <param name="a">要计算的存有符号的字符串全集，计算将删除被计算的部分</param>
    /// <param name="b">要计算的浮点数全集，计算将删除被计算的部分</param>
    /// <param name="c">要计算的字符串开始字符</param>
    /// <param name="d">要计算的字符串结束字符（左开右闭）</param>
    private static void Sshu(ref string a, ref List<double> b, int c, int d)
    {
        char[] de = ['+', '-'], df = ['*', '/'], dh = ['+', '-', '^'];
        for (int e = a.LastIndexOfAny(dh, d - 1, d - c), f; e != -1 && e >= c; e = a.LastIndexOfAny(dh, e - 1, e - c))
        {
            if (a[e] == '^')
            {
                f = a.Count(0, e);
                b[f - 1] = Math.Pow(b[f - 1], b[f]);
                a = a.Remove(e, 2);
                d -= 2;
                b.RemoveAt(f);
            }
            else
            {
                f = a.LastIndexNotOfAny(de, e, e - c + 1);
                if (f != -1)
                    f += a[f] == ' ' ? 2 : 1;
                else f = 0;
                b[a.Count(0, e)] *= (a.Count(f, e - f + 1, '-') % 2 != 0 ? -1 : 1);
                a = a.Remove(f, e - f + 1);
                d -= e - f + 1;
                e = f + 1;
            }
        }
        for (int e = a.IndexOfAny(df, c), f; e != -1 && e < d; a = a.Remove(e, 2), d -= 2, b.RemoveAt(f), e = a.IndexOfAny(df, e))
        {
            f = a.Count(0, e);
            if (a[e] == '*') b[f - 1] *= b[f];
            else b[f - 1] /= b[f];
        }
        for (int e = a.IndexOfAny(de, c), f; e != -1 && e < d; a = a.Remove(e, 2), d -= 2, b.RemoveAt(f), e = a.IndexOfAny(de, e))
        {
            f = a.Count(0, e);
            if (a[e] == '+') b[f - 1] += b[f];
            else b[f - 1] -= b[f];
        }
    }
    /// <summary>
    /// 将算式计算为结果
    /// </summary>
    /// <param name="expression">要计算的表达式</param>
    /// <returns>计算结果</returns>
    public static double Calculate(string expression)
    {
        List<double> c = Zhuan(ref expression);
        for (int d = expression.IndexOf(')'), e, f; d != -1; d = expression.IndexOf(')', e))//有括号时对括号的处理
        {
            e = expression.LastIndexOf('(', d);
            f = expression.Count(0, d);
            if (e != -1)
            {
                Sshu(ref expression, ref c, e + 1, d);
                expression = expression.Remove(e, 1).Remove(e + 1, 1);
                f = expression.Count(0, e);
                if (expression.Length > e + 1 && expression[e + 1] == ' ')
                {
                    c[f] *= c[f + 1];
                    expression = expression.Remove(e, 1);
                    c.RemoveAt(f + 1);
                }
                if (e != 0 && expression[e - 1] == ' ')
                {
                    c[f - 1] *= c[f];
                    expression = expression.Remove(e, 1);
                    c.RemoveAt(f);
                }
            }
            else
            {
                if (d != 0)
                {
                    if (expression[d - 1] == ' ' && expression[d + 1] == ' ')
                    {
                        c[f - 1] *= c[f];
                        expression = expression.Remove(d, 2);
                        c.RemoveAt(f);
                    }
                }
                else expression = expression.Remove(0, 1);
                e = 0;
            }
        }
        while (expression.Contains('('))
            expression = expression.Remove(expression.IndexOf('('), 1);
        for (int d = expression.IndexOf('('), e; d != -1;)
        {
            if (d != 0 && expression.Length >= d && expression[d - 1] == ' ' && expression[d] == ' ')
            {
                e = expression.Count(0, d);
                c[e - 1] *= c[e];
                c.RemoveAt(e);
            }
            d = expression.IndexOf('(');
            if (d != -1) expression = expression.Remove(d, 1);
        }
        Sshu(ref expression, ref c, 0, expression.Length);
        return c[0];
    }
}
