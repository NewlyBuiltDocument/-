using System.Data.SQLite;

namespace simple_calculator
{
    public partial class CalForm : Form
    {
        //��ʾ�ַ���
        public string display = "";
        
        public CalForm()
        {
            InitializeComponent();
        }

        private void CalForm_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// ������ʾ������
        /// </summary>
        private void UpdateDisplay()
        {
            DisplayText.Text = display;
        }

        /// <summary>
        /// ���µ���ʱִ�м���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void BtnEqual_Click(object sender, EventArgs e)
        {
            display += "=";
            display += "ans";//�˴�ӦΪ������
            UpdateDisplay();
            AddToHistory(display);
            display = "";//�����ʾ�ַ������ȴ���һ������
        }

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
                MessageBox.Show("�޷���ӵ���ʷ��");
            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new();
            historyForm.ShowDialog();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            display = display.Remove(display.Length - 1);
            UpdateDisplay();
        }

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
}
