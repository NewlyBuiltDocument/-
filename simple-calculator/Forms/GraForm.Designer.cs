using OxyPlot.WindowsForms;

namespace simple_calculator.Forms
{
    partial class GraForm
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

        private void InitializePlot()
        {
            plot = new Plot();
            plot.OutputEvent += UpdateDisplay;
            plot.UpdateListEvent += UpdateList;
            plot.PlotEvent += UpdatePlot;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraForm));
            BtnClear = new Button();
            BtnDivide = new Button();
            BtnExp = new Button();
            BtnRBracket = new Button();
            BtnLBracket = new Button();
            Btn7 = new Button();
            Btn8 = new Button();
            Btn9 = new Button();
            BtnTimes = new Button();
            Btn4 = new Button();
            Btn5 = new Button();
            Btn6 = new Button();
            BtnMinus = new Button();
            Btn1 = new Button();
            Btn2 = new Button();
            Btn3 = new Button();
            BtnPlus = new Button();
            BtnDot = new Button();
            Btn0 = new Button();
            BtnDel = new Button();
            BtnX = new Button();
            FunctionList = new ListBox();
            panel1 = new Panel();
            BtnEnter = new Button();
            FuncExp = new TextBox();
            FuncPlot = new PlotView();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            numericUpDown2 = new NumericUpDown();
            BtnPlot = new Button();
            BtnRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(1021, 449);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(75, 116);
            BtnClear.TabIndex = 6;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += InputCharater;
            // 
            // BtnDivide
            // 
            BtnDivide.Location = new Point(941, 449);
            BtnDivide.Name = "BtnDivide";
            BtnDivide.Size = new Size(75, 55);
            BtnDivide.TabIndex = 7;
            BtnDivide.Text = "÷";
            BtnDivide.UseVisualStyleBackColor = true;
            BtnDivide.Click += InputCharater;
            // 
            // BtnExp
            // 
            BtnExp.Location = new Point(861, 449);
            BtnExp.Name = "BtnExp";
            BtnExp.Size = new Size(75, 55);
            BtnExp.TabIndex = 8;
            BtnExp.Text = "^";
            BtnExp.UseVisualStyleBackColor = true;
            BtnExp.Click += InputCharater;
            // 
            // BtnRBracket
            // 
            BtnRBracket.Location = new Point(781, 449);
            BtnRBracket.Name = "BtnRBracket";
            BtnRBracket.Size = new Size(75, 55);
            BtnRBracket.TabIndex = 9;
            BtnRBracket.Text = ")";
            BtnRBracket.UseVisualStyleBackColor = true;
            BtnRBracket.Click += InputCharater;
            // 
            // BtnLBracket
            // 
            BtnLBracket.Location = new Point(701, 449);
            BtnLBracket.Name = "BtnLBracket";
            BtnLBracket.Size = new Size(75, 55);
            BtnLBracket.TabIndex = 10;
            BtnLBracket.Text = "(";
            BtnLBracket.UseVisualStyleBackColor = true;
            BtnLBracket.Click += InputCharater;
            // 
            // Btn7
            // 
            Btn7.BackColor = SystemColors.Control;
            Btn7.Location = new Point(701, 510);
            Btn7.Name = "Btn7";
            Btn7.Size = new Size(75, 55);
            Btn7.TabIndex = 15;
            Btn7.Text = "7";
            Btn7.UseVisualStyleBackColor = true;
            Btn7.Click += InputCharater;
            // 
            // Btn8
            // 
            Btn8.Location = new Point(781, 510);
            Btn8.Name = "Btn8";
            Btn8.Size = new Size(75, 55);
            Btn8.TabIndex = 14;
            Btn8.Text = "8";
            Btn8.UseVisualStyleBackColor = true;
            Btn8.Click += InputCharater;
            // 
            // Btn9
            // 
            Btn9.Location = new Point(861, 510);
            Btn9.Name = "Btn9";
            Btn9.Size = new Size(75, 55);
            Btn9.TabIndex = 13;
            Btn9.Text = "9";
            Btn9.UseVisualStyleBackColor = true;
            Btn9.Click += InputCharater;
            // 
            // BtnTimes
            // 
            BtnTimes.Location = new Point(941, 510);
            BtnTimes.Name = "BtnTimes";
            BtnTimes.Size = new Size(75, 55);
            BtnTimes.TabIndex = 12;
            BtnTimes.Text = "×";
            BtnTimes.UseVisualStyleBackColor = true;
            BtnTimes.Click += InputCharater;
            // 
            // Btn4
            // 
            Btn4.Location = new Point(701, 571);
            Btn4.Name = "Btn4";
            Btn4.Size = new Size(75, 55);
            Btn4.TabIndex = 20;
            Btn4.Text = "4";
            Btn4.UseVisualStyleBackColor = true;
            Btn4.Click += InputCharater;
            // 
            // Btn5
            // 
            Btn5.Location = new Point(781, 571);
            Btn5.Name = "Btn5";
            Btn5.Size = new Size(75, 55);
            Btn5.TabIndex = 19;
            Btn5.Text = "5";
            Btn5.UseVisualStyleBackColor = true;
            Btn5.Click += InputCharater;
            // 
            // Btn6
            // 
            Btn6.Location = new Point(861, 571);
            Btn6.Name = "Btn6";
            Btn6.Size = new Size(75, 55);
            Btn6.TabIndex = 18;
            Btn6.Text = "6";
            Btn6.UseVisualStyleBackColor = true;
            Btn6.Click += InputCharater;
            // 
            // BtnMinus
            // 
            BtnMinus.Location = new Point(941, 571);
            BtnMinus.Name = "BtnMinus";
            BtnMinus.Size = new Size(75, 55);
            BtnMinus.TabIndex = 17;
            BtnMinus.Text = "-";
            BtnMinus.UseVisualStyleBackColor = true;
            BtnMinus.Click += InputCharater;
            // 
            // Btn1
            // 
            Btn1.Location = new Point(701, 632);
            Btn1.Name = "Btn1";
            Btn1.Size = new Size(75, 55);
            Btn1.TabIndex = 25;
            Btn1.Text = "1";
            Btn1.UseVisualStyleBackColor = true;
            Btn1.Click += InputCharater;
            // 
            // Btn2
            // 
            Btn2.Location = new Point(781, 632);
            Btn2.Name = "Btn2";
            Btn2.Size = new Size(75, 55);
            Btn2.TabIndex = 24;
            Btn2.Text = "2";
            Btn2.UseVisualStyleBackColor = true;
            Btn2.Click += InputCharater;
            // 
            // Btn3
            // 
            Btn3.Location = new Point(861, 632);
            Btn3.Name = "Btn3";
            Btn3.Size = new Size(75, 55);
            Btn3.TabIndex = 23;
            Btn3.Text = "3";
            Btn3.UseVisualStyleBackColor = true;
            Btn3.Click += InputCharater;
            // 
            // BtnPlus
            // 
            BtnPlus.Location = new Point(941, 632);
            BtnPlus.Name = "BtnPlus";
            BtnPlus.Size = new Size(75, 55);
            BtnPlus.TabIndex = 22;
            BtnPlus.Text = "+";
            BtnPlus.UseVisualStyleBackColor = true;
            BtnPlus.Click += InputCharater;
            // 
            // BtnDot
            // 
            BtnDot.Location = new Point(701, 693);
            BtnDot.Name = "BtnDot";
            BtnDot.Size = new Size(75, 55);
            BtnDot.TabIndex = 30;
            BtnDot.Text = ".";
            BtnDot.UseVisualStyleBackColor = true;
            BtnDot.Click += InputCharater;
            // 
            // Btn0
            // 
            Btn0.Location = new Point(781, 693);
            Btn0.Name = "Btn0";
            Btn0.Size = new Size(75, 55);
            Btn0.TabIndex = 29;
            Btn0.Text = "0";
            Btn0.UseVisualStyleBackColor = true;
            Btn0.Click += InputCharater;
            // 
            // BtnDel
            // 
            BtnDel.Location = new Point(861, 693);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(75, 55);
            BtnDel.TabIndex = 28;
            BtnDel.Text = "DEL";
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += InputCharater;
            // 
            // BtnX
            // 
            BtnX.Location = new Point(941, 693);
            BtnX.Name = "BtnX";
            BtnX.Size = new Size(75, 55);
            BtnX.TabIndex = 26;
            BtnX.Text = "x";
            BtnX.UseVisualStyleBackColor = true;
            BtnX.Click += InputCharater;
            // 
            // FunctionList
            // 
            FunctionList.FormattingEnabled = true;
            FunctionList.ItemHeight = 17;
            FunctionList.Location = new Point(702, 12);
            FunctionList.Name = "FunctionList";
            FunctionList.Size = new Size(395, 293);
            FunctionList.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 31;
            // 
            // BtnEnter
            // 
            BtnEnter.BackColor = SystemColors.Control;
            BtnEnter.Font = new Font("Microsoft YaHei UI", 20F);
            BtnEnter.Location = new Point(1022, 571);
            BtnEnter.Name = "BtnEnter";
            BtnEnter.Size = new Size(75, 177);
            BtnEnter.TabIndex = 32;
            BtnEnter.Text = "↵";
            BtnEnter.UseVisualStyleBackColor = true;
            BtnEnter.Click += InputFunction;
            // 
            // FuncExp
            // 
            FuncExp.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FuncExp.Location = new Point(701, 415);
            FuncExp.Name = "FuncExp";
            FuncExp.Size = new Size(395, 28);
            FuncExp.TabIndex = 34;
            // 
            // FuncPlot
            // 
            FuncPlot.Location = new Point(12, 12);
            FuncPlot.Name = "FuncPlot";
            FuncPlot.PanCursor = Cursors.Hand;
            FuncPlot.Size = new Size(660, 734);
            FuncPlot.TabIndex = 33;
            FuncPlot.Text = "Plot";
            FuncPlot.ZoomHorizontalCursor = Cursors.SizeWE;
            FuncPlot.ZoomRectangleCursor = Cursors.SizeNWSE;
            FuncPlot.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown1.Location = new Point(753, 317);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(702, 319);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 36;
            label1.Text = "x_start";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(930, 319);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 37;
            label2.Text = "x_end";
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown2.Location = new Point(977, 317);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 38;
            // 
            // BtnPlot
            // 
            BtnPlot.Location = new Point(702, 364);
            BtnPlot.Name = "BtnPlot";
            BtnPlot.Size = new Size(154, 45);
            BtnPlot.TabIndex = 39;
            BtnPlot.Text = "Plot";
            BtnPlot.UseVisualStyleBackColor = true;
            BtnPlot.Click += InputFunction;
            // 
            // BtnRemove
            // 
            BtnRemove.Location = new Point(943, 364);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(154, 45);
            BtnRemove.TabIndex = 40;
            BtnRemove.Text = "Remove";
            BtnRemove.UseVisualStyleBackColor = true;
            BtnRemove.Click += DeleteFunc;
            // 
            // GraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1108, 758);
            Controls.Add(BtnRemove);
            Controls.Add(BtnPlot);
            Controls.Add(numericUpDown2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(FuncExp);
            Controls.Add(BtnEnter);
            Controls.Add(panel1);
            Controls.Add(BtnDot);
            Controls.Add(Btn0);
            Controls.Add(BtnDel);
            Controls.Add(BtnX);
            Controls.Add(Btn1);
            Controls.Add(Btn2);
            Controls.Add(Btn3);
            Controls.Add(BtnPlus);
            Controls.Add(Btn4);
            Controls.Add(Btn5);
            Controls.Add(Btn6);
            Controls.Add(BtnMinus);
            Controls.Add(Btn7);
            Controls.Add(Btn8);
            Controls.Add(Btn9);
            Controls.Add(BtnTimes);
            Controls.Add(BtnLBracket);
            Controls.Add(BtnRBracket);
            Controls.Add(BtnExp);
            Controls.Add(BtnDivide);
            Controls.Add(BtnClear);
            Controls.Add(FunctionList);
            Controls.Add(FuncPlot);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GraForm";
            Text = "Graphics";
            Load += GraForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Plot plot;
        private Button BtnClear;
        private Button BtnDivide;
        private Button BtnExp;
        private Button BtnRBracket;
        private Button BtnLBracket;
        private Button Btn7;
        private Button Btn8;
        private Button Btn9;
        private Button BtnTimes;
        private Button Btn4;
        private Button Btn5;
        private Button Btn6;
        private Button BtnMinus;
        private Button Btn1;
        private Button Btn2;
        private Button Btn3;
        private Button BtnPlus;
        private Button BtnDot;
        private Button Btn0;
        private Button BtnDel;
        private Button BtnX;
        private ListBox FunctionList;
        private Panel panel1;
        private Button BtnEnter;
        private TextBox FuncExp;
        private PlotView FuncPlot;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown2;
        private Button BtnPlot;
        private Button BtnRemove;
    }
}
