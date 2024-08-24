using System.Data.SQLite;
using simple_calculator;

public class EqualButton(CalForm calForm) : BaseButtonTypes(calForm)
{
    public event InputHandler? InputEvent;
    
    /// <summary>
    /// 计算结果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public override void ButtonClick(object sender, EventArgs e)
    {
        if (calForm.display.Length != 0)//如果为空：没有输入或已经得到结果，应当什么也不做
        {
            try
            {
                string expression = calForm.display;
                expression = CompleteRightBrackets();
                string ans = Calculation.Calculate(expression).ToString();
                expression += "=";
                expression += ans;
                AddToHistory(expression);
                InputEvent?.Invoke(expression);
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
    /// 为不匹配的左括号补全右括号
    /// </summary>
    /// <returns>补全后的字符串</returns>
    private string CompleteRightBrackets()
    {
        string expression = calForm.display;
        int difference = expression.Count(x => x == '(') - expression.Count(x => x == ')');
        if (difference > 0)
        {
            expression = expression.PadRight(expression.Length + difference, ')');
        }
        return expression;
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
}
