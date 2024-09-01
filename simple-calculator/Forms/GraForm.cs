using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using System.Text.RegularExpressions;
using simple_calculator.Functions;

namespace simple_calculator.Forms;

public partial class GraForm : Form
{
    public GraForm()
    {
        InitializePlot();
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


    private void GraForm_Load(object sender, EventArgs e)
    {
        FuncExp.Text = "y=";
    }

    /// <summary>
    /// 更新显示的内容
    /// </summary>
    private void UpdateDisplay(object sneder, OutputEventArgs e)
    {
        FuncExp.Text = "y=" + e.OutputExpression;
    }

    /// <summary>
    /// 更新函数列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">函数列表事件参数</param>
    private void UpdateList(object sender, FuncListEventArgs e)
    {
        FunctionList.Items.Clear();
        foreach (string func in e.FuncList)
        {
            FunctionList.Items.Add(func);
        }
    }

    /// <summary>
    /// 输入字符到图形计算器中
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
        plot.GetCharacter(character);
    }

    /// <summary>
    /// 输入功能到图形计算器中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InputFunction(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string function = button.Text;
        plot.GetFunction(function);
    }

    /// <summary>
    /// 删除列表中的函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeleteFunc(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (FunctionList.SelectedItem == null)
        {
            MessageBox.Show("请选择要删除的函数！");
            return;
        }
        else
        {
            plot.GetFunction(button.Text, FunctionList.SelectedItem.ToString()!);
        }
    }

    /// <summary>
    /// 根据函数列表绘图
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">函数列表事件参数</param>
    private void UpdatePlot(object sender, FuncListEventArgs e)
    {
        if (numericUpDown1.Value >= numericUpDown2.Value)
        {
            MessageBox.Show("请检查输入的范围！");
            return;
        }

        if (e.FuncList.Count == 0)
        {
            MessageBox.Show("请添加函数！");
            return;
        }
        
        var plotModel = new PlotModel { Title = "Plot" };

        foreach (var func in e.FuncList)
        {
            // 解析函数并添加到图表中
            Func<double, double> parsedFunction = Calculation.ParseFunction(func);
            if (parsedFunction != null)
            {
                plotModel.Series.Add(new FunctionSeries(parsedFunction, (double)numericUpDown1.Value, (double)numericUpDown2.Value, 0.01, func));
            }
        }

        FuncPlot.Model = plotModel;
    }
}
