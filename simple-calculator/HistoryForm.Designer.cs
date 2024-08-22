namespace simple_calculator
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DgvHistory = new DataGridView();
            BtnDel = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvHistory).BeginInit();
            SuspendLayout();
            // 
            // DgvHistory
            // 
            DgvHistory.AllowUserToAddRows = false;
            DgvHistory.AllowUserToDeleteRows = false;
            DgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DgvHistory.DefaultCellStyle = dataGridViewCellStyle1;
            DgvHistory.Location = new Point(0, 0);
            DgvHistory.Margin = new Padding(4);
            DgvHistory.Name = "DgvHistory";
            DgvHistory.RowHeadersWidth = 82;
            DgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvHistory.Size = new Size(1300, 568);
            DgvHistory.TabIndex = 0;
            // 
            // BtnDel
            // 
            BtnDel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnDel.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
            BtnDel.Location = new Point(72, 596);
            BtnDel.Margin = new Padding(4);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(1172, 157);
            BtnDel.TabIndex = 1;
            BtnDel.Text = "删除";
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += BtnDel_Click;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 788);
            Controls.Add(BtnDel);
            Controls.Add(DgvHistory);
            Margin = new Padding(4);
            Name = "HistoryForm";
            Text = "History";
            Load += HistoryForm_Load;
            Resize += CalForm_Resize;
            ((System.ComponentModel.ISupportInitialize)DgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvHistory;
        private Button BtnDel;
    }
}