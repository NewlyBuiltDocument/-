using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms; // Add this line to import the System.Windows.Forms namespace

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
    private static void SetControls(float newx, float newy, Control cons)
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
                    SetControls(newx, newy, con);
                }
            }
        }
    }
    private void CalForm_Resize(object sender, EventArgs e)
    {
        float newx = (this.Width) / x;
        float newy = (this.Height) / y;
        SetControls(newx, newy, this);
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
    
    /// <summary>
    /// 检测右括号输入时的合法性
    /// </summary>
    /// <param name="expression">输入右括号后的字符串</param>
    /// <returns>输入操作后的字符串</returns>
    public static string ValidRightBrackets(string expression)
    {
        //如果左括号数量小于右括号数量，删除右括号
        if (Regex.Count(expression, @"\(", RegexOptions.Compiled) < Regex.Count(expression, @"\)", RegexOptions.Compiled))
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft | RegexOptions.Compiled);
            expression = expression.Remove(match2.Index, 1);
            return expression;
        }
        //如果右括号前面是运算符或左括号，删除右括号
        if (Regex.Match(expression, @"[+\-\*/^(]\)", RegexOptions.Compiled).Success)
        {
            Match match2 = Regex.Match(expression, @"\)", RegexOptions.RightToLeft | RegexOptions.Compiled);
            expression = expression.Remove(match2.Index, 1);
        }
        return expression;
    }

    /// <summary>
    /// 检测小数点输入时的合法性，自动补齐前面的0
    /// </summary>
    /// <param name="expression">输入小数点前的字符串</param>
    /// <returns>输入操作后的字符串</returns>
    public static string ValidDot(string expression)
    {
        if (expression[^1] == '.')
        {
            return expression;
        }
        //如果最后一个字符是运算符，补全0
        else if (Regex.Match(expression, @"[+\-\*/^(]$", RegexOptions.Compiled).Success)
        {
            return expression + "0.";
        }
        //如果最后一串数字中已经有小数点，不再添加
        else if (Regex.Match(expression, @"\.[0-9]+?$", RegexOptions.Compiled).Success)
        {
            return expression;
        }
        else
        {
            return expression + ".";
        }
    }

    /// <summary>
    /// 检测左括号输入时的合法性，自动补全乘号
    /// </summary>
    /// <param name="expression">输入左括号前的字符串</param>
    /// <returns>输入操作后的字符串</returns>
    public static string ValidLeftBrackets(string expression)
    {
        if (expression.Length == 0)
        {
            return "(";
        }
        else if (expression[^1] == '.')
        {
            return expression;
        }
        //如果最后一个字符是数字，补全乘号
        else if (Regex.Match(expression, @"[0-9]$", RegexOptions.Compiled).Success)
        {
            return expression + "*(";
        }
        else
        {
            return expression + "(";
        }
        
    }
    /// <summary>
    /// 为不匹配的左括号补全右括号
    /// </summary>
    /// <returns>原字符串需要补右括号返回true，不需要则返回false</returns>
    private bool CompleteRightBrackets()
    {
        bool condition = false;
        int difference = display.Count(x => x == '(') - display.Count(x => x == ')');
        if (difference > 0)
        {
            display = display.PadRight(display.Length + difference, ')');
            condition = true;
        }
        return condition;
    }
    /// <summary>
    /// 检测是否可以插入运算符
    /// </summary>
    /// <param name="expression">插入运算符前的字符串</param>
    /// <returns>是否可以插入</returns>
    public static bool CanInsertOperator(string expression)
    {
        if (expression.Length == 0)
        {
            return false;
        }
        else if (Regex.Match(expression, @"[+\-\*/^(]$", RegexOptions.Compiled).Success)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// 检测是否可以插入符号
    /// </summary>
    /// <param name="expression">待插入的字符串</param>
    /// <param name="symbol">符号类型</param>
    /// <returns>插入操作后的字符串</returns>
    public static string ValidSymbols(string expression, string symbol)
    {
        if (expression.Length == 0)
        {
            return symbol;
        }
        else if (Regex.Match(expression, @"[\*/^]$", RegexOptions.Compiled).Success)
        {
            return expression + "(" + symbol;
        }
        else if (Regex.Match(expression, @"[+\-]$", RegexOptions.Compiled).Success)
        {
            return expression.Remove(expression.Length - 1) + symbol;
        }
        else
        {
            return expression + symbol;
        }
    }

    /// <summary>
    /// 按下数字键时执行的操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnNum_Click(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            string buttonText = clickedButton.Text;
            display += buttonText;
            UpdateDisplay();
        }
    }
    
    /// <summary>
    /// 按下运算符时执行的操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnOp_Click(object sender, EventArgs e)
    {
        if (sender is Button clickedButton)
        {
            string buttonText = clickedButton.Text;
            switch (buttonText)
            {
                case "+":
                    display = ValidSymbols(display, "+");
                    UpdateDisplay();
                    break;
                case "-":
                    display = ValidSymbols(display, "-");
                    UpdateDisplay();
                    break;
                case "×":
                    if (CanInsertOperator(display))
                    {
                        display += "*";
                        UpdateDisplay();
                    }
                    break;
                case "÷":
                    if (CanInsertOperator(display))
                    {
                        display += "/";
                        UpdateDisplay();
                    }
                    break;
                case "^":
                    if (CanInsertOperator(display))
                    {
                        display += "^";
                        UpdateDisplay();
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 按下等于时执行计算程序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnEqual_Click(object sender, EventArgs e)
    {
        if (display.Length != 0)//如果为空：没有输入或已经得到结果，应当什么也不做
        {
            try
            {
                CompleteRightBrackets();
                string ans = AnyCalculate.Calculate(display).ToString();
                display += "=";
                display += ans;
                UpdateDisplay();
                AddToHistory(display);
                display = "";//清空显示字符串，等待下一次输入
            }
            catch(DivideByZeroException)
            {
                MessageBox.Show("除数不能为0！");
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

        DateTime dateTime = DateTime.Now;
        string time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        string insertStr = $"INSERT INTO history (time, results) VALUES ('{time}', '{result}');";
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

    private void BtnDot_Click(object sender, EventArgs e)
    {
        display = ValidDot(display);
        UpdateDisplay();
    }

    private void BtnLBracket_Click(object sender, EventArgs e)
    {
        display = ValidLeftBrackets(display);
        UpdateDisplay();
    }

    private void BtnRBracket_Click(object sender, EventArgs e)
    {
        display += ")";
        display = ValidRightBrackets(display);
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
                if (e != 0 && a[e - 1] == ' ')
                    continue;
                f = a.LastIndexNotOfAny(de, e, e - c + 1);
                if (f != -1)
                    f += a[f] == ' ' ? 2 : 1;
                else f = c;
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
            else if (b[f] != 0) b[f - 1] /= b[f];
            else throw new DivideByZeroException();
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
