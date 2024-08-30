namespace simple_calculator;

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
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
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
        DgvHistory.BackgroundColor = SystemColors.Window;
        DgvHistory.BorderStyle = BorderStyle.None;
        DgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        DgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
        DgvHistory.Location = new Point(0, 0);
        DgvHistory.Margin = new Padding(2);
        DgvHistory.Name = "DgvHistory";
        DgvHistory.RowHeadersWidth = 82;
        DgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DgvHistory.Size = new Size(650, 357);
        DgvHistory.TabIndex = 0;
        // 
        // BtnDel
        // 
        BtnDel.BackgroundImage = (Image)resources.GetObject("BtnDel.BackgroundImage");
        BtnDel.BackgroundImageLayout = ImageLayout.Stretch;
        BtnDel.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnDel.ForeColor = SystemColors.Window;
        BtnDel.Location = new Point(587, 361);
        BtnDel.Margin = new Padding(2);
        BtnDel.Name = "BtnDel";
        BtnDel.Size = new Size(52, 60);
        BtnDel.TabIndex = 1;
        BtnDel.UseVisualStyleBackColor = false;
        BtnDel.Click += BtnDel_Click;
        // 
        // HistoryForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Window;
        ClientSize = new Size(650, 432);
        Controls.Add(BtnDel);
        Controls.Add(DgvHistory);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(2);
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