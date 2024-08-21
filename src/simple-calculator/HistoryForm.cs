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

namespace simple_calculator
{
    public partial class HistoryForm : Form
    {
        public DataTable dataTable = new();
        
        public HistoryForm()
        {
            InitializeComponent();
        }

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

            DgvHistory.AutoGenerateColumns = false;
            DgvHistory.Columns.Clear();
            DgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataTable.Columns[1].ColumnName,
                HeaderText = dataTable.Columns[1].ColumnName
            });

            DgvHistory.DataSource = dataTable;
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
                    cmd.ExecuteNonQuery();
                }
                UpdateHistory();
            }
            else { MessageBox.Show("请选择需要删除的行"); }
        }
    }
}
