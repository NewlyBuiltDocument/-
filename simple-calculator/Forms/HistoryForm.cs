using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_calculator;

public partial class HistoryForm : Form
{
    public DataTable dataTable = new();
    
    public HistoryForm()
    {
        InitializeComponent();
        x = this.Width;
        y = this.Height;
        setTag(this);
    }
    #region 控件大小随窗体大小等比例缩放
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

    #endregion

    private void HistoryForm_Load(object sender, EventArgs e)
    {
        UpdateHistory();
    }

    public void UpdateHistory()
    {
        using SQLiteConnection conn = new(Program.myConnectionString);
        conn.Open();
        SQLiteCommand cmd = new();
        string queryStr = "SELECT * FROM history;";
        cmd = new SQLiteCommand(queryStr, conn);
        SQLiteDataAdapter adapter = new(cmd);
        dataTable = new();
        adapter.Fill(dataTable);

        DgvHistory.DataSource = dataTable;
        // 隐藏所有列
        foreach (DataGridViewColumn column in DgvHistory.Columns)
        {
            column.Visible = false;
        }
        // 显示第二列和第三列
        DgvHistory.Columns[1].Visible = true; // 第二列
        DgvHistory.Columns[2].Visible = true; // 第三列
    }

    private void BtnDel_Click(object sender, EventArgs e)
    {
        if (DgvHistory.SelectedRows.Count > 1 || (DgvHistory.SelectedRows.Count == 1 && DgvHistory.SelectedRows[0].Cells[0].Value != null))
        {
            using SQLiteConnection conn = new(Program.myConnectionString);
            conn.Open();
            SQLiteCommand cmd = new();

            DataGridViewRow selectedRow;
            object id = -1;
            for (int i = 0; i < DgvHistory.SelectedRows.Count; i++)
            {
                selectedRow = DgvHistory.SelectedRows[i];
                id = dataTable.Rows[selectedRow.Index][0];
                string delStr = $"DELETE FROM history where id={id};";
                cmd = new SQLiteCommand(delStr, conn);
                try { cmd.ExecuteNonQuery(); }
                catch (SQLiteException)
                {
                    MessageBox.Show("无法删除！");
                }
            }
            UpdateHistory();
        }
        else { MessageBox.Show("请选择需要删除的行"); }
    }
}
