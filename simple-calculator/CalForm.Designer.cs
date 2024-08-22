
namespace simple_calculator;

partial class CalForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        DisplayText = new TextBox();
        panel2 = new Panel();
        BtnHistory = new Button();
        BtnClear = new Button();
        BtnExp = new Button();
        BtnRBracket = new Button();
        BtnLBracket = new Button();
        BtnTimes = new Button();
        Btn9 = new Button();
        Btn8 = new Button();
        BtnMinus = new Button();
        Btn6 = new Button();
        Btn5 = new Button();
        BtnPlus = new Button();
        Btn3 = new Button();
        Btn2 = new Button();
        BtnEqual = new Button();
        BtnDel = new Button();
        Btn0 = new Button();
        BtnDot = new Button();
        Btn1 = new Button();
        Btn4 = new Button();
        Btn7 = new Button();
        BtnDivide = new Button();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.BackColor = SystemColors.ButtonShadow;
        panel1.Controls.Add(DisplayText);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Margin = new Padding(4, 4, 4, 4);
        panel1.Name = "panel1";
        panel1.Size = new Size(1056, 164);
        panel1.TabIndex = 0;
        // 
        // DisplayText
        // 
        DisplayText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        DisplayText.BackColor = SystemColors.Window;
        DisplayText.Font = new Font("Times New Roman", 42F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DisplayText.Location = new Point(12, 13);
        DisplayText.Margin = new Padding(4, 4, 4, 4);
        DisplayText.Name = "DisplayText";
        DisplayText.Size = new Size(1032, 136);
        DisplayText.TabIndex = 0;
        DisplayText.Text = "1+2=3";
        DisplayText.TextAlign = HorizontalAlignment.Right;
        // 
        // panel2
        // 
        panel2.BackColor = SystemColors.ButtonShadow;
        panel2.Controls.Add(BtnHistory);
        panel2.Controls.Add(BtnClear);
        panel2.Controls.Add(BtnExp);
        panel2.Controls.Add(BtnRBracket);
        panel2.Controls.Add(BtnLBracket);
        panel2.Controls.Add(BtnTimes);
        panel2.Controls.Add(Btn9);
        panel2.Controls.Add(Btn8);
        panel2.Controls.Add(BtnMinus);
        panel2.Controls.Add(Btn6);
        panel2.Controls.Add(Btn5);
        panel2.Controls.Add(BtnPlus);
        panel2.Controls.Add(Btn3);
        panel2.Controls.Add(Btn2);
        panel2.Controls.Add(BtnEqual);
        panel2.Controls.Add(BtnDel);
        panel2.Controls.Add(Btn0);
        panel2.Controls.Add(BtnDot);
        panel2.Controls.Add(Btn1);
        panel2.Controls.Add(Btn4);
        panel2.Controls.Add(Btn7);
        panel2.Controls.Add(BtnDivide);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(0, 164);
        panel2.Margin = new Padding(4, 4, 4, 4);
        panel2.Name = "panel2";
        panel2.Size = new Size(1056, 823);
        panel2.TabIndex = 1;
        // 
        // BtnHistory
        // 
        BtnHistory.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnHistory.Location = new Point(838, 356);
        BtnHistory.Margin = new Padding(4, 4, 4, 4);
        BtnHistory.Name = "BtnHistory";
        BtnHistory.Size = new Size(180, 425);
        BtnHistory.TabIndex = 34;
        BtnHistory.Text = "History";
        BtnHistory.UseVisualStyleBackColor = true;
        BtnHistory.Click += BtnHistory_Click;
        // 
        // BtnClear
        // 
        BtnClear.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnClear.Location = new Point(838, 46);
        BtnClear.Margin = new Padding(4, 4, 4, 4);
        BtnClear.Name = "BtnClear";
        BtnClear.Size = new Size(180, 270);
        BtnClear.TabIndex = 33;
        BtnClear.Text = "Clear";
        BtnClear.UseVisualStyleBackColor = true;
        BtnClear.Click += BtnClear_Click;
        // 
        // BtnExp
        // 
        BtnExp.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnExp.Location = new Point(440, 46);
        BtnExp.Margin = new Padding(4, 4, 4, 4);
        BtnExp.Name = "BtnExp";
        BtnExp.Size = new Size(160, 115);
        BtnExp.TabIndex = 32;
        BtnExp.Text = "^";
        BtnExp.UseVisualStyleBackColor = true;
        BtnExp.Click += BtnExp_Click;
        // 
        // BtnRBracket
        // 
        BtnRBracket.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnRBracket.Location = new Point(240, 46);
        BtnRBracket.Margin = new Padding(4, 4, 4, 4);
        BtnRBracket.Name = "BtnRBracket";
        BtnRBracket.Size = new Size(160, 115);
        BtnRBracket.TabIndex = 31;
        BtnRBracket.Text = ")";
        BtnRBracket.UseVisualStyleBackColor = true;
        BtnRBracket.Click += BtnRBracket_Click;
        // 
        // BtnLBracket
        // 
        BtnLBracket.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnLBracket.Location = new Point(40, 46);
        BtnLBracket.Margin = new Padding(4, 4, 4, 4);
        BtnLBracket.Name = "BtnLBracket";
        BtnLBracket.Size = new Size(160, 115);
        BtnLBracket.TabIndex = 30;
        BtnLBracket.Text = "(";
        BtnLBracket.UseVisualStyleBackColor = true;
        BtnLBracket.Click += BtnLBracket_Click;
        // 
        // BtnTimes
        // 
        BtnTimes.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnTimes.Location = new Point(640, 201);
        BtnTimes.Margin = new Padding(4, 4, 4, 4);
        BtnTimes.Name = "BtnTimes";
        BtnTimes.Size = new Size(160, 115);
        BtnTimes.TabIndex = 28;
        BtnTimes.Text = "×";
        BtnTimes.UseVisualStyleBackColor = true;
        BtnTimes.Click += BtnTimes_Click;
        // 
        // Btn9
        // 
        Btn9.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn9.Location = new Point(440, 201);
        Btn9.Margin = new Padding(4, 4, 4, 4);
        Btn9.Name = "Btn9";
        Btn9.Size = new Size(160, 115);
        Btn9.TabIndex = 27;
        Btn9.Text = "9";
        Btn9.UseVisualStyleBackColor = true;
        Btn9.Click += Btn9_Click;
        // 
        // Btn8
        // 
        Btn8.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn8.Location = new Point(240, 201);
        Btn8.Margin = new Padding(4, 4, 4, 4);
        Btn8.Name = "Btn8";
        Btn8.Size = new Size(160, 115);
        Btn8.TabIndex = 26;
        Btn8.Text = "8";
        Btn8.UseVisualStyleBackColor = true;
        Btn8.Click += Btn8_Click;
        // 
        // BtnMinus
        // 
        BtnMinus.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnMinus.Location = new Point(640, 356);
        BtnMinus.Margin = new Padding(4, 4, 4, 4);
        BtnMinus.Name = "BtnMinus";
        BtnMinus.Size = new Size(160, 115);
        BtnMinus.TabIndex = 25;
        BtnMinus.Text = "-";
        BtnMinus.UseVisualStyleBackColor = true;
        BtnMinus.Click += BtnMinus_Click;
        // 
        // Btn6
        // 
        Btn6.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn6.Location = new Point(440, 356);
        Btn6.Margin = new Padding(4, 4, 4, 4);
        Btn6.Name = "Btn6";
        Btn6.Size = new Size(160, 115);
        Btn6.TabIndex = 24;
        Btn6.Text = "6";
        Btn6.UseVisualStyleBackColor = true;
        Btn6.Click += Btn6_Click;
        // 
        // Btn5
        // 
        Btn5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn5.Location = new Point(240, 356);
        Btn5.Margin = new Padding(4, 4, 4, 4);
        Btn5.Name = "Btn5";
        Btn5.Size = new Size(160, 115);
        Btn5.TabIndex = 23;
        Btn5.Text = "5";
        Btn5.UseVisualStyleBackColor = true;
        Btn5.Click += Btn5_Click;
        // 
        // BtnPlus
        // 
        BtnPlus.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnPlus.Location = new Point(640, 511);
        BtnPlus.Margin = new Padding(4, 4, 4, 4);
        BtnPlus.Name = "BtnPlus";
        BtnPlus.Size = new Size(160, 115);
        BtnPlus.TabIndex = 22;
        BtnPlus.Text = "+";
        BtnPlus.UseVisualStyleBackColor = true;
        BtnPlus.Click += BtnPlus_Click;
        // 
        // Btn3
        // 
        Btn3.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn3.Location = new Point(440, 511);
        Btn3.Margin = new Padding(4, 4, 4, 4);
        Btn3.Name = "Btn3";
        Btn3.Size = new Size(160, 115);
        Btn3.TabIndex = 21;
        Btn3.Text = "3";
        Btn3.UseVisualStyleBackColor = true;
        Btn3.Click += Btn3_Click;
        // 
        // Btn2
        // 
        Btn2.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn2.Location = new Point(240, 511);
        Btn2.Margin = new Padding(4, 4, 4, 4);
        Btn2.Name = "Btn2";
        Btn2.Size = new Size(160, 115);
        Btn2.TabIndex = 20;
        Btn2.Text = "2";
        Btn2.UseVisualStyleBackColor = true;
        Btn2.Click += Btn2_Click;
        // 
        // BtnEqual
        // 
        BtnEqual.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnEqual.Location = new Point(640, 666);
        BtnEqual.Margin = new Padding(4, 4, 4, 4);
        BtnEqual.Name = "BtnEqual";
        BtnEqual.Size = new Size(160, 115);
        BtnEqual.TabIndex = 19;
        BtnEqual.Text = "=";
        BtnEqual.UseVisualStyleBackColor = true;
        BtnEqual.Click += BtnEqual_Click;
        // 
        // BtnDel
        // 
        BtnDel.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnDel.Location = new Point(440, 666);
        BtnDel.Margin = new Padding(4, 4, 4, 4);
        BtnDel.Name = "BtnDel";
        BtnDel.Size = new Size(160, 115);
        BtnDel.TabIndex = 18;
        BtnDel.Text = "DEL";
        BtnDel.UseVisualStyleBackColor = true;
        BtnDel.Click += BtnDel_Click;
        // 
        // Btn0
        // 
        Btn0.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn0.Location = new Point(240, 666);
        Btn0.Margin = new Padding(4, 4, 4, 4);
        Btn0.Name = "Btn0";
        Btn0.Size = new Size(160, 115);
        Btn0.TabIndex = 17;
        Btn0.Text = "0";
        Btn0.UseVisualStyleBackColor = true;
        Btn0.Click += Btn0_Click;
        // 
        // BtnDot
        // 
        BtnDot.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnDot.Location = new Point(40, 666);
        BtnDot.Margin = new Padding(4, 4, 4, 4);
        BtnDot.Name = "BtnDot";
        BtnDot.Size = new Size(160, 115);
        BtnDot.TabIndex = 16;
        BtnDot.Text = ".";
        BtnDot.UseVisualStyleBackColor = true;
        BtnDot.Click += BtnDot_Click;
        // 
        // Btn1
        // 
        Btn1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn1.Location = new Point(40, 511);
        Btn1.Margin = new Padding(4, 4, 4, 4);
        Btn1.Name = "Btn1";
        Btn1.Size = new Size(160, 115);
        Btn1.TabIndex = 12;
        Btn1.Text = "1";
        Btn1.UseVisualStyleBackColor = true;
        Btn1.Click += Btn1_Click;
        // 
        // Btn4
        // 
        Btn4.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn4.Location = new Point(40, 356);
        Btn4.Margin = new Padding(4, 4, 4, 4);
        Btn4.Name = "Btn4";
        Btn4.Size = new Size(160, 115);
        Btn4.TabIndex = 8;
        Btn4.Text = "4";
        Btn4.UseVisualStyleBackColor = true;
        Btn4.Click += Btn4_Click;
        // 
        // Btn7
        // 
        Btn7.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn7.Location = new Point(40, 201);
        Btn7.Margin = new Padding(4, 4, 4, 4);
        Btn7.Name = "Btn7";
        Btn7.Size = new Size(160, 115);
        Btn7.TabIndex = 4;
        Btn7.Text = "7";
        Btn7.UseVisualStyleBackColor = true;
        Btn7.Click += Btn7_Click;
        // 
        // BtnDivide
        // 
        BtnDivide.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnDivide.Location = new Point(640, 46);
        BtnDivide.Margin = new Padding(4, 4, 4, 4);
        BtnDivide.Name = "BtnDivide";
        BtnDivide.Size = new Size(160, 115);
        BtnDivide.TabIndex = 3;
        BtnDivide.Text = "÷";
        BtnDivide.UseVisualStyleBackColor = true;
        BtnDivide.Click += BtnDivide_Click;
        // 
        // CalForm
        // 
        AutoScaleDimensions = new SizeF(14F, 31F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1056, 987);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Margin = new Padding(4, 4, 4, 4);
        Name = "CalForm";
        Text = "Calculator";
        Load += CalForm_Load;
        Resize += CalForm_Resize;
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private TextBox DisplayText;
    private Panel panel2;
    private Button BtnDivide;
    private Button BtnEqual;
    private Button BtnDel;
    private Button Btn0;
    private Button BtnDot;
    private Button Btn1;
    private Button Btn4;
    private Button Btn7;
    private Button BtnPlus;
    private Button Btn3;
    private Button Btn2;
    private Button BtnTimes;
    private Button Btn9;
    private Button Btn8;
    private Button BtnMinus;
    private Button Btn6;
    private Button Btn5;
    private Button BtnRBracket;
    private Button BtnLBracket;
    private Button BtnHistory;
    private Button BtnClear;
    private Button BtnExp;
}
