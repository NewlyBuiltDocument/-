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

    /// <summary>
    /// Method to initialize the button type
    /// </summary>
    private void InitializeCalculator()
    {
        calculator = new Calculator();
        calculator.OutputEvent += UpdateDisplay;
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
        BtnGraphics = new Button();
        BtnI = new Button();
        BtnTan = new Button();
        BtnCos = new Button();
        BtnSin = new Button();
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
        panel1.Margin = new Padding(2);
        panel1.Name = "panel1";
        panel1.Size = new Size(528, 90);
        panel1.TabIndex = 0;
        // 
        // DisplayText
        // 
        DisplayText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        DisplayText.BackColor = SystemColors.Window;
        DisplayText.Font = new Font("Times New Roman", 42F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DisplayText.Location = new Point(6, 7);
        DisplayText.Margin = new Padding(2);
        DisplayText.Name = "DisplayText";
        DisplayText.Size = new Size(518, 72);
        DisplayText.TabIndex = 0;
        DisplayText.Text = "1+2=3";
        DisplayText.TextAlign = HorizontalAlignment.Right;
        // 
        // panel2
        // 
        panel2.BackColor = SystemColors.ButtonShadow;
        panel2.Controls.Add(BtnGraphics);
        panel2.Controls.Add(BtnI);
        panel2.Controls.Add(BtnTan);
        panel2.Controls.Add(BtnCos);
        panel2.Controls.Add(BtnSin);
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
        panel2.Location = new Point(0, 90);
        panel2.Margin = new Padding(2);
        panel2.Name = "panel2";
        panel2.Size = new Size(528, 548);
        panel2.TabIndex = 1;
        // 
        // BtnGraphics
        // 
        BtnGraphics.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnGraphics.Location = new Point(419, 195);
        BtnGraphics.Margin = new Padding(2);
        BtnGraphics.Name = "BtnGraphics";
        BtnGraphics.Size = new Size(90, 148);
        BtnGraphics.TabIndex = 39;
        BtnGraphics.Text = "Graphics";
        BtnGraphics.UseVisualStyleBackColor = true;
        BtnGraphics.Click += InputFunction;
        // 
        // BtnI
        // 
        BtnI.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnI.Location = new Point(220, 110);
        BtnI.Margin = new Padding(2);
        BtnI.Name = "BtnI";
        BtnI.Size = new Size(80, 63);
        BtnI.TabIndex = 38;
        BtnI.Text = "i";
        BtnI.UseVisualStyleBackColor = true;
        BtnI.Click += InputCharater;
        // 
        // BtnTan
        // 
        BtnTan.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnTan.Location = new Point(220, 25);
        BtnTan.Margin = new Padding(2);
        BtnTan.Name = "BtnTan";
        BtnTan.Size = new Size(80, 63);
        BtnTan.TabIndex = 37;
        BtnTan.Text = "tan";
        BtnTan.UseVisualStyleBackColor = true;
        BtnTan.Click += InputCharater;
        // 
        // BtnCos
        // 
        BtnCos.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnCos.Location = new Point(120, 25);
        BtnCos.Margin = new Padding(2);
        BtnCos.Name = "BtnCos";
        BtnCos.Size = new Size(80, 63);
        BtnCos.TabIndex = 36;
        BtnCos.Text = "cos";
        BtnCos.UseVisualStyleBackColor = true;
        BtnCos.Click += InputCharater;
        // 
        // BtnSin
        // 
        BtnSin.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnSin.Location = new Point(20, 25);
        BtnSin.Margin = new Padding(2);
        BtnSin.Name = "BtnSin";
        BtnSin.Size = new Size(80, 63);
        BtnSin.TabIndex = 35;
        BtnSin.Text = "sin";
        BtnSin.UseVisualStyleBackColor = true;
        BtnSin.Click += InputCharater;
        // 
        // BtnHistory
        // 
        BtnHistory.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnHistory.Location = new Point(419, 365);
        BtnHistory.Margin = new Padding(2);
        BtnHistory.Name = "BtnHistory";
        BtnHistory.Size = new Size(90, 148);
        BtnHistory.TabIndex = 34;
        BtnHistory.Text = "History";
        BtnHistory.UseVisualStyleBackColor = true;
        BtnHistory.Click += InputFunction;
        // 
        // BtnClear
        // 
        BtnClear.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnClear.Location = new Point(419, 25);
        BtnClear.Margin = new Padding(2);
        BtnClear.Name = "BtnClear";
        BtnClear.Size = new Size(90, 148);
        BtnClear.TabIndex = 33;
        BtnClear.Text = "Clear";
        BtnClear.UseVisualStyleBackColor = true;
        BtnClear.Click += InputCharater;
        // 
        // BtnExp
        // 
        BtnExp.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnExp.Location = new Point(320, 25);
        BtnExp.Margin = new Padding(2);
        BtnExp.Name = "BtnExp";
        BtnExp.Size = new Size(80, 63);
        BtnExp.TabIndex = 32;
        BtnExp.Text = "^";
        BtnExp.UseVisualStyleBackColor = true;
        BtnExp.Click += InputCharater;
        // 
        // BtnRBracket
        // 
        BtnRBracket.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnRBracket.Location = new Point(120, 110);
        BtnRBracket.Margin = new Padding(2);
        BtnRBracket.Name = "BtnRBracket";
        BtnRBracket.Size = new Size(80, 63);
        BtnRBracket.TabIndex = 31;
        BtnRBracket.Text = ")";
        BtnRBracket.UseVisualStyleBackColor = true;
        BtnRBracket.Click += InputCharater;
        // 
        // BtnLBracket
        // 
        BtnLBracket.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnLBracket.Location = new Point(20, 110);
        BtnLBracket.Margin = new Padding(2);
        BtnLBracket.Name = "BtnLBracket";
        BtnLBracket.Size = new Size(80, 63);
        BtnLBracket.TabIndex = 30;
        BtnLBracket.Text = "(";
        BtnLBracket.UseVisualStyleBackColor = true;
        BtnLBracket.Click += InputCharater;
        // 
        // BtnTimes
        // 
        BtnTimes.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnTimes.Location = new Point(320, 195);
        BtnTimes.Margin = new Padding(2);
        BtnTimes.Name = "BtnTimes";
        BtnTimes.Size = new Size(80, 63);
        BtnTimes.TabIndex = 28;
        BtnTimes.Text = "×";
        BtnTimes.UseVisualStyleBackColor = true;
        BtnTimes.Click += InputCharater;
        // 
        // Btn9
        // 
        Btn9.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn9.Location = new Point(220, 195);
        Btn9.Margin = new Padding(2);
        Btn9.Name = "Btn9";
        Btn9.Size = new Size(80, 63);
        Btn9.TabIndex = 27;
        Btn9.Text = "9";
        Btn9.UseVisualStyleBackColor = true;
        Btn9.Click += InputCharater;
        // 
        // Btn8
        // 
        Btn8.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn8.Location = new Point(120, 195);
        Btn8.Margin = new Padding(2);
        Btn8.Name = "Btn8";
        Btn8.Size = new Size(80, 63);
        Btn8.TabIndex = 26;
        Btn8.Text = "8";
        Btn8.UseVisualStyleBackColor = true;
        Btn8.Click += InputCharater;
        // 
        // BtnMinus
        // 
        BtnMinus.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnMinus.Location = new Point(320, 280);
        BtnMinus.Margin = new Padding(2);
        BtnMinus.Name = "BtnMinus";
        BtnMinus.Size = new Size(80, 63);
        BtnMinus.TabIndex = 25;
        BtnMinus.Text = "-";
        BtnMinus.UseVisualStyleBackColor = true;
        BtnMinus.Click += InputCharater;
        // 
        // Btn6
        // 
        Btn6.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn6.Location = new Point(220, 280);
        Btn6.Margin = new Padding(2);
        Btn6.Name = "Btn6";
        Btn6.Size = new Size(80, 63);
        Btn6.TabIndex = 24;
        Btn6.Text = "6";
        Btn6.UseVisualStyleBackColor = true;
        Btn6.Click += InputCharater;
        // 
        // Btn5
        // 
        Btn5.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn5.Location = new Point(120, 280);
        Btn5.Margin = new Padding(2);
        Btn5.Name = "Btn5";
        Btn5.Size = new Size(80, 63);
        Btn5.TabIndex = 23;
        Btn5.Text = "5";
        Btn5.UseVisualStyleBackColor = true;
        Btn5.Click += InputCharater;
        // 
        // BtnPlus
        // 
        BtnPlus.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnPlus.Location = new Point(320, 365);
        BtnPlus.Margin = new Padding(2);
        BtnPlus.Name = "BtnPlus";
        BtnPlus.Size = new Size(80, 63);
        BtnPlus.TabIndex = 22;
        BtnPlus.Text = "+";
        BtnPlus.UseVisualStyleBackColor = true;
        BtnPlus.Click += InputCharater;
        // 
        // Btn3
        // 
        Btn3.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn3.Location = new Point(220, 365);
        Btn3.Margin = new Padding(2);
        Btn3.Name = "Btn3";
        Btn3.Size = new Size(80, 63);
        Btn3.TabIndex = 21;
        Btn3.Text = "3";
        Btn3.UseVisualStyleBackColor = true;
        Btn3.Click += InputCharater;
        // 
        // Btn2
        // 
        Btn2.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn2.Location = new Point(120, 365);
        Btn2.Margin = new Padding(2);
        Btn2.Name = "Btn2";
        Btn2.Size = new Size(80, 63);
        Btn2.TabIndex = 20;
        Btn2.Text = "2";
        Btn2.UseVisualStyleBackColor = true;
        Btn2.Click += InputCharater;
        // 
        // BtnEqual
        // 
        BtnEqual.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnEqual.Location = new Point(320, 450);
        BtnEqual.Margin = new Padding(2);
        BtnEqual.Name = "BtnEqual";
        BtnEqual.Size = new Size(80, 63);
        BtnEqual.TabIndex = 19;
        BtnEqual.Text = "=";
        BtnEqual.UseVisualStyleBackColor = true;
        BtnEqual.Click += InputCharater;
        // 
        // BtnDel
        // 
        BtnDel.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnDel.Location = new Point(220, 450);
        BtnDel.Margin = new Padding(2);
        BtnDel.Name = "BtnDel";
        BtnDel.Size = new Size(80, 63);
        BtnDel.TabIndex = 18;
        BtnDel.Text = "DEL";
        BtnDel.UseVisualStyleBackColor = true;
        BtnDel.Click += InputCharater;
        // 
        // Btn0
        // 
        Btn0.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn0.Location = new Point(120, 450);
        Btn0.Margin = new Padding(2);
        Btn0.Name = "Btn0";
        Btn0.Size = new Size(80, 63);
        Btn0.TabIndex = 17;
        Btn0.Text = "0";
        Btn0.UseVisualStyleBackColor = true;
        Btn0.Click += InputCharater;
        // 
        // BtnDot
        // 
        BtnDot.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        BtnDot.Location = new Point(20, 450);
        BtnDot.Margin = new Padding(2);
        BtnDot.Name = "BtnDot";
        BtnDot.Size = new Size(80, 63);
        BtnDot.TabIndex = 16;
        BtnDot.Text = ".";
        BtnDot.UseVisualStyleBackColor = true;
        BtnDot.Click += InputCharater;
        // 
        // Btn1
        // 
        Btn1.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn1.Location = new Point(20, 365);
        Btn1.Margin = new Padding(2);
        Btn1.Name = "Btn1";
        Btn1.Size = new Size(80, 63);
        Btn1.TabIndex = 12;
        Btn1.Text = "1";
        Btn1.UseVisualStyleBackColor = true;
        Btn1.Click += InputCharater;
        // 
        // Btn4
        // 
        Btn4.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn4.Location = new Point(20, 280);
        Btn4.Margin = new Padding(2);
        Btn4.Name = "Btn4";
        Btn4.Size = new Size(80, 63);
        Btn4.TabIndex = 8;
        Btn4.Text = "4";
        Btn4.UseVisualStyleBackColor = true;
        Btn4.Click += InputCharater;
        // 
        // Btn7
        // 
        Btn7.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 134);
        Btn7.Location = new Point(20, 195);
        Btn7.Margin = new Padding(2);
        Btn7.Name = "Btn7";
        Btn7.Size = new Size(80, 63);
        Btn7.TabIndex = 4;
        Btn7.Text = "7";
        Btn7.UseVisualStyleBackColor = true;
        Btn7.Click += InputCharater;
        // 
        // BtnDivide
        // 
        BtnDivide.Font = new Font("Microsoft YaHei UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 134);
        BtnDivide.Location = new Point(320, 110);
        BtnDivide.Margin = new Padding(2);
        BtnDivide.Name = "BtnDivide";
        BtnDivide.Size = new Size(80, 63);
        BtnDivide.TabIndex = 3;
        BtnDivide.Text = "÷";
        BtnDivide.UseVisualStyleBackColor = true;
        BtnDivide.Click += InputCharater;
        // 
        // CalForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(528, 638);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Margin = new Padding(2);
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
    private Calculator calculator;
    private Button BtnI;
    private Button BtnTan;
    private Button BtnCos;
    private Button BtnSin;
    private Button BtnGraphics;
}
