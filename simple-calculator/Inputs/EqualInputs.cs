using simple_calculator.Functions;
using System.Data.SQLite;
using System.Numerics;

namespace simple_calculator.Inputs;

/// <summary>
/// 等于输入处理类
/// </summary>
/// <param name="calculator">计算器类</param>
public class EqualInputs(Calculator calculator) : BaseInputType(calculator)
{
    /// <summary>
    /// 输入等号时的计算方法
    /// </summary>
    /// <param name="eq">等号</param>
    /// <returns>包含计算结果的字符串</returns>
    public override string GeneratedNewExpression(string eq)
    {
        if (calculator.expression.Length != 0)
        {
            try
            {
                string expression = CompleteRightBrackets();
                Complex ans = Calculation.Calculate(expression);
                expression += "=";
                if (ans.Imaginary == 0.0)
                {
                    expression += ans.Real.ToString();
                }
                else if (ans.Real == 0.0)
                {
                    expression = string.Concat(expression.AsSpan(), ans.Imaginary.ToString(), "i");
                }
                else if (ans.Imaginary > 0.0)
                {
                    expression = string.Concat(expression.AsSpan(), ans.Real.ToString(), string.Concat("+", ans.Imaginary.ToString(), "i"));
                }
                else
                {
                    expression = string.Concat(expression.AsSpan(), ans.Real.ToString(), ans.Imaginary.ToString() + "i");
                }
                AddToHistory(expression);
                return expression;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("除数不能为0！");
            }
            catch
            {
                MessageBox.Show("输入有误！");
            }
        }
        return "";
    }

    /// <summary>
    /// 为不匹配的左括号补全右括号
    /// </summary>
    /// <returns>补全后的字符串</returns>
    private string CompleteRightBrackets()
    {
        string expression = calculator.expression;
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
