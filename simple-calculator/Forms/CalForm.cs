using System.CodeDom;
using System.Text.RegularExpressions;
using System.Windows.Forms; // Add this line to import the System.Windows.Forms namespace

namespace simple_calculator.Forms;

public delegate void InputHandler(string expression);

/// <summary>
/// 窗体类，需为第一个类以便设计器渲染
/// </summary>
public partial class CalForm : Form
{
    public CalForm()
    {
        InitializeCalculator();
        InitializeComponent();

        x = Width;
        y = Height;
        SetTag(this);
    }


    #region 控件大小随窗体大小等比例缩放

    private readonly float x;//定义当前窗体的宽度
    private readonly float y;//定义当前窗体的高度
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
    private static void SetControls(float newx, float newy, Control cons)
    {
        //遍历窗体中的控件，重新设置控件的值
        foreach (Control con in cons.Controls)
        {
            //获取控件的Tag属性值，并分割后存储字符串数组
            if (con.Tag != null)
            {
                string[] mytag = con.Tag.ToString()!.Split([';']);
                //根据窗体缩放的比例确定控件的值
                con.Width = Convert.ToInt32(Convert.ToSingle(mytag[0]) * newx);//宽度
                con.Height = Convert.ToInt32(Convert.ToSingle(mytag[1]) * newy);//高度
                con.Left = Convert.ToInt32(Convert.ToSingle(mytag[2]) * newx);//左边距
                con.Top = Convert.ToInt32(Convert.ToSingle(mytag[3]) * newy);//顶边距
                float currentSize = Convert.ToSingle(mytag[4]) * newy;//字体大小
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

    #endregion

    private void CalForm_Load(object sender, EventArgs e)
    {
        DisplayText.Text = "";
    }

    /// <summary>
    /// 更新显示的内容
    /// </summary>
    private void UpdateDisplay(object sneder, OutputEventArgs e)
    {
        DisplayText.Text = e.OutputExpression;
    }

    /// <summary>
    /// 输入字符到计算器中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputCharater(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string character = button.Text;
        switch (character)
        {
            case "×":
                character = "*";
                break;
            case "÷":
                character = "/";
                break;
            default:
                break;
        }
        calculator.GetCharacter(character);
    }

    /// <summary>
    /// 输入功能到计算器中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputFunction(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string function = button.Text;
        calculator.GetFunction(function);
    }

}
