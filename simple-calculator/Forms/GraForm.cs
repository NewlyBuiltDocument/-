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
    /// <summary>
    /// 初始化画图计算器类及窗体组件
    /// </summary>
    public GraForm()
    {
        InitializePlot();
        InitializeComponent();
    }

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
