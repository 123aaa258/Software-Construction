using System;
using System.Windows.Forms;

namespace task5
{
    public partial class Form1
    {
        private TextBox textBoxDisplay;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonDivide;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button buttonMultiply;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button buttonMinus;
        private Button button0;
        private Button buttonClear;
        private Button buttonEqual;
        private Button buttonPlus;

        private void InitializeComponent()
        {
            this.textBoxDisplay = new TextBox();
            this.button7 = new Button();
            this.button8 = new Button();
            this.button9 = new Button();
            this.buttonDivide = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            this.button6 = new Button();
            this.buttonMultiply = new Button();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.buttonMinus = new Button();
            this.button0 = new Button();
            this.buttonClear = new Button();
            this.buttonEqual = new Button();
            this.buttonPlus = new Button();
            this.SuspendLayout();

            this.textBoxDisplay.Location = new System.Drawing.Point(22, 22);
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.ReadOnly = true;
            this.textBoxDisplay.Size = new System.Drawing.Size(246, 23);
            this.textBoxDisplay.TabIndex = 0;
            this.textBoxDisplay.TextAlign = HorizontalAlignment.Right;

            this.button7.Location = new System.Drawing.Point(22, 63);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(52, 40);
            this.button7.TabIndex = 1;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(this.NumberButton_Click);

            this.button8.Location = new System.Drawing.Point(84, 63);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 40);
            this.button8.TabIndex = 2;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new EventHandler(this.NumberButton_Click);

            this.button9.Location = new System.Drawing.Point(146, 63);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(52, 40);
            this.button9.TabIndex = 3;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new EventHandler(this.NumberButton_Click);

            this.buttonDivide.Location = new System.Drawing.Point(216, 63);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(52, 40);
            this.buttonDivide.TabIndex = 4;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new EventHandler(this.OperatorButton_Click);

            this.button4.Location = new System.Drawing.Point(22, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(52, 40);
            this.button4.TabIndex = 5;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.NumberButton_Click);

            this.button5.Location = new System.Drawing.Point(84, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(52, 40);
            this.button5.TabIndex = 6;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.NumberButton_Click);

            this.button6.Location = new System.Drawing.Point(146, 113);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(52, 40);
            this.button6.TabIndex = 7;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.NumberButton_Click);

            this.buttonMultiply.Location = new System.Drawing.Point(216, 113);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(52, 40);
            this.buttonMultiply.TabIndex = 8;
            this.buttonMultiply.Text = "*";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            this.buttonMultiply.Click += new EventHandler(this.OperatorButton_Click);

            this.button1.Location = new System.Drawing.Point(22, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.NumberButton_Click);

            this.button2.Location = new System.Drawing.Point(84, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.NumberButton_Click);

            this.button3.Location = new System.Drawing.Point(146, 163);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 40);
            this.button3.TabIndex = 11;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.NumberButton_Click);

            this.buttonMinus.Location = new System.Drawing.Point(216, 163);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(52, 40);
            this.buttonMinus.TabIndex = 12;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new EventHandler(this.OperatorButton_Click);

            this.button0.Location = new System.Drawing.Point(22, 213);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(52, 40);
            this.button0.TabIndex = 13;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new EventHandler(this.NumberButton_Click);

            this.buttonClear.Location = new System.Drawing.Point(84, 213);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(52, 40);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new EventHandler(this.buttonClear_Click);

            this.buttonEqual.Location = new System.Drawing.Point(146, 213);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(52, 40);
            this.buttonEqual.TabIndex = 15;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new EventHandler(this.buttonEqual_Click);

            this.buttonPlus.Location = new System.Drawing.Point(216, 213);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(52, 40);
            this.buttonPlus.TabIndex = 16;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new EventHandler(this.OperatorButton_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 275);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonMultiply);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBoxDisplay);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "简单计算器";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
