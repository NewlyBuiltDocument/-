using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace simple_calculator
{
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
            SetTag(this);
        }

        //region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private static void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
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
                    string[] mytag = con.Tag.ToString().Split([';']);
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
        //字符计数
        private static int Chshu(ReadOnlySpan<char> a, char b = ' ')
        {
            int c = 0;
            foreach (char d in a)
            {
                if (d == b) { ++c; }
            }
            return c;
        }
        private static int Chshu(ref string a, int b, int c, char d = ' ')
        {
            return Chshu(a.AsSpan(b, c), d);
        }
        //字符串转数字
        private static double Svtoty(ref string a, int b = 0, int Base = 10)
        {
            double d = 0.0, e = Base;
            int? f = null, g = a.Length;
            for (; b < g && (a[b] >= '0' && a[b] <= '9' || a[b] == '.'); ++b)
            {
                if (f != null)
                {
                    ++f;
                }
                if (a[b] == '.')
                {
                    f = 0;
                }
                else
                {
                    d *= e;
                    d += a[b] - '0';
                }
            }
            if (f != null)
            {
                d /= Math.Pow(e, (double)f);
            }
            return d;
        }

        //数与符号分离
        private static List<double> Zhuan(ref string str)
        {
            List<double> a = [];
            str = str.Replace(" ", null);
            char[] c = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'];
            for (int d = str.IndexOfAny(c), e = (d == -1 ? 0 : str.IndexNotOfAny(c, d)); d != -1;)
            {
                a.Add(Svtoty(ref str, d));
                str = string.Concat(str.AsSpan(0, d), " ", e == -1 ? null : str.AsSpan(e));
                d = str.IndexOfAny(c);
                e = (d == -1 ? 0 : str.IndexNotOfAny(c, d));
            }
            return a;
        }
        //无括号部分计算
        private static void Sshu(ref string a, ref List<double> b, int c, int d)
        {
            char[] de = ['+', '-'], df = ['*', '/'], dg = ['^'];
            for (int e = a.IndexOfAny(dg, c), f; e != -1 && e < d; a = a.Remove(e, 2), d -= 2, b.RemoveAt(f), e = a.IndexOfAny(df, e))
            {
                f = Chshu(ref a, 0, e);
                b[f - 1] = Math.Pow(b[f - 1], b[f]);
            }
            for (int e = a.IndexOfAny(de, c), f = (e == -1 ? 0 : a.IndexNotOfAny(de, e)); e != -1 && e < d;)
            {
                if (e != 0 && a[e - 1] == ' ')
                {
                    ++e; continue;
                }
                if (f >= d) break;
                b[Chshu(ref a, 0, e)] *= (Chshu(ref a, e, f - e, '-') % 2 != 0 ? -1 : 1);
                a = a.Remove(e, f - e);
                d -= f - e;
                e = a.IndexOfAny(de, e);
                f = e == -1 ? 0 : a.IndexNotOfAny(de, e);
            }
            for (int e = a.IndexOfAny(df, c), f; e != -1 && e < d; a = a.Remove(e, 2), d -= 2, b.RemoveAt(f), e = a.IndexOfAny(df, e))
            {
                f = Chshu(ref a, 0, e);
                if (a[e] == '*')
                {
                    b[f - 1] *= b[f];
                }
                else
                {
                    b[f - 1] /= b[f];
                }
            }
            for (int e = a.IndexOfAny(de, c), f; e != -1 && e < d; a = a.Remove(e, 2), d -= 2, b.RemoveAt(f), e = a.IndexOfAny(de, e))
            {
                f = Chshu(ref a, 0, e);
                if (a[e] == '+')
                {
                    b[f - 1] += b[f];
                }
                else
                {
                    b[f - 1] -= b[f];
                }
            }
        }
        //核心计算，对括号处理
        public static double Calculate(string expression)
        {
            string b = expression;
            List<double> c = Zhuan(ref b);
            for (int d = b.IndexOf(')'), e, f; d != -1; d = b.IndexOf(')', e))//有括号时对括号的处理
            {
                e = b.LastIndexOf('(', d);
                f = Chshu(ref b, 0, d);
                if (e != -1)
                {
                    Sshu(ref b, ref c, e + 1, d);
                    b = b.Remove(e, 1).Remove(e + 1, 1);
                    f = Chshu(ref b, 0, e);
                    if (b.Length > e + 1 && b[e + 1] == ' ')
                    {
                        c[f] *= c[f + 1];
                        b = b.Remove(e, 1);
                        c.RemoveAt(f + 1);
                    }
                    if (e != 0 && b[e - 1] == ' ')
                    {
                        c[f - 1] *= c[f];
                        b = b.Remove(e, 1);
                        c.RemoveAt(f);
                    }
                }
                else
                {
                    if (d != 0)
                    {
                        if (b[d - 1] == ' ' && b[d + 1] == ' ')
                        {
                            c[f - 1] *= c[f];
                            b = b.Remove(d, 2);
                            c.RemoveAt(f);
                        }
                    }
                    else b = b.Remove(0, 1);
                    e = 0;
                }
            }
            if (b.Contains('('))
            {
                b = b.Remove(b.IndexOf('('), 1);
            }
            for (int d = b.IndexOf('('), e; d != -1;)
            {
                if (d != 0 && b.Length >= d && b[d - 1] == ' ' && b[d] == ' ')
                {
                    e = Chshu(ref b, 0, d);
                    c[e - 1] *= c[e];
                    c.RemoveAt(e);
                }
                d = b.IndexOf('(');
                if (d != -1)
                {
                    b = b.Remove(d, 1);
                }
            }
            Sshu(ref b, ref c, 0, b.Length);
            return c[0];
        }

        /// <summary>
        /// 检测右括号输入时的合法性
        /// </summary>
        /// <param name="expression">输入右括号后的字符串</param>
        /// <returns>修改后的字符串</returns>
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
        /// <returns>输入后的字符串</returns>
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
        /// <returns>输入后的字符串</returns>
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
        /// 按下等于时执行计算程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEqual_Click(object sender, EventArgs e)
        {
            if (display.Length == 0)
            {
                MessageBox.Show("请输入表达式！");
                return;
            }
            string ans = "";
            try
            {
                ans = Calculate(display).ToString();
            }
            catch
            {
                MessageBox.Show("输入有误！");
                return;
            }
            display += "=";
            display += ans;
            UpdateDisplay();
            AddToHistory(display);
            display = "";//清空显示字符串，等待下一次输入
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

        
        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string buttonText = clickedButton.Text;
                display += buttonText;
                UpdateDisplay();
            }
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

        private void BtnOp_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (CanInsertOperator(display))
                {
                    string buttonText = clickedButton.Text;
                    switch (buttonText)
                    {
                        case "+":
                            display += "+";
                            break;
                        case "-":
                            display += "-";
                            break;
                        case "×":
                            display += "*";
                            break;
                        case "÷":
                            display += "/";
                            break;
                        case "^":
                            display += "^";
                            break;
                    }
                    UpdateDisplay();
                }
            }
        }
    }
    //字符串和IndexOfAny对应方法
    public static class StringExtend
    {
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
                if (c)
                {
                    return a;
                }
            }
            return -1;
        }
    }
}
