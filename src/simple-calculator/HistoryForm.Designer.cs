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
            DgvHistory = new DataGridView();
            BtnDel = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvHistory).BeginInit();
            SuspendLayout();
            // 
            // DgvHistory
            // 
            DgvHistory.AllowUserToAddRows = false;
            DgvHistory.AllowUserToDeleteRows = false;
            DgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvHistory.Location = new Point(0, 0);
            DgvHistory.Name = "DgvHistory";
            DgvHistory.RowHeadersWidth = 82;
            DgvHistory.Size = new Size(1301, 567);
            DgvHistory.TabIndex = 0;
            // 
            // BtnDel
            // 
            BtnDel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnDel.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
            BtnDel.Location = new Point(73, 597);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(1172, 157);
            BtnDel.TabIndex = 1;
            BtnDel.Text = "删除";
            BtnDel.UseVisualStyleBackColor = true;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1301, 787);
            Controls.Add(BtnDel);
            Controls.Add(DgvHistory);
            Name = "HistoryForm";
            Text = "History";
            ((System.ComponentModel.ISupportInitialize)DgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvHistory;
        private Button BtnDel;
    }
}