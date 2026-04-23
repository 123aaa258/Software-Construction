using System;
using System.Windows.Forms;

namespace task7
{
    public partial class Form1
    {
        private Label labelKeyword;
        private Label labelLength;
        private TextBox textBoxKeyword;
        private TextBox textBoxLength;
        private Button buttonSearch;
        private Label labelBaidu;
        private Label labelBing;
        private TextBox textBoxBaiduResult;
        private TextBox textBoxBingResult;

        private void InitializeComponent()
        {
            this.labelKeyword = new Label();
            this.labelLength = new Label();
            this.textBoxKeyword = new TextBox();
            this.textBoxLength = new TextBox();
            this.buttonSearch = new Button();
            this.labelBaidu = new Label();
            this.labelBing = new Label();
            this.textBoxBaiduResult = new TextBox();
            this.textBoxBingResult = new TextBox();
            this.SuspendLayout();

            this.labelKeyword.AutoSize = true;
            this.labelKeyword.Location = new System.Drawing.Point(21, 23);
            this.labelKeyword.Name = "labelKeyword";
            this.labelKeyword.Size = new System.Drawing.Size(56, 17);
            this.labelKeyword.TabIndex = 0;
            this.labelKeyword.Text = "关键字：";

            this.textBoxKeyword.Location = new System.Drawing.Point(83, 20);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(281, 23);
            this.textBoxKeyword.TabIndex = 1;

            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(379, 23);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(44, 17);
            this.labelLength.TabIndex = 2;
            this.labelLength.Text = "字数：";

            this.textBoxLength.Location = new System.Drawing.Point(429, 20);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(53, 23);
            this.textBoxLength.TabIndex = 3;
            this.textBoxLength.Text = "200";

            this.buttonSearch.Location = new System.Drawing.Point(499, 18);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(94, 27);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new EventHandler(this.buttonSearch_Click);

            this.labelBaidu.AutoSize = true;
            this.labelBaidu.Location = new System.Drawing.Point(24, 67);
            this.labelBaidu.Name = "labelBaidu";
            this.labelBaidu.Size = new System.Drawing.Size(49, 17);
            this.labelBaidu.TabIndex = 5;
            this.labelBaidu.Text = "Baidu";

            this.labelBing.AutoSize = true;
            this.labelBing.Location = new System.Drawing.Point(309, 67);
            this.labelBing.Name = "labelBing";
            this.labelBing.Size = new System.Drawing.Size(35, 17);
            this.labelBing.TabIndex = 6;
            this.labelBing.Text = "Bing";

            this.textBoxBaiduResult.Location = new System.Drawing.Point(27, 97);
            this.textBoxBaiduResult.Multiline = true;
            this.textBoxBaiduResult.Name = "textBoxBaiduResult";
            this.textBoxBaiduResult.ReadOnly = true;
            this.textBoxBaiduResult.ScrollBars = ScrollBars.Vertical;
            this.textBoxBaiduResult.Size = new System.Drawing.Size(247, 214);
            this.textBoxBaiduResult.TabIndex = 7;

            this.textBoxBingResult.Location = new System.Drawing.Point(312, 97);
            this.textBoxBingResult.Multiline = true;
            this.textBoxBingResult.Name = "textBoxBingResult";
            this.textBoxBingResult.ReadOnly = true;
            this.textBoxBingResult.ScrollBars = ScrollBars.Vertical;
            this.textBoxBingResult.Size = new System.Drawing.Size(264, 214);
            this.textBoxBingResult.TabIndex = 8;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 338);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.textBoxBingResult);
            this.Controls.Add(this.textBoxBaiduResult);
            this.Controls.Add(this.labelBing);
            this.Controls.Add(this.labelBaidu);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.labelKeyword);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "搜索结果摘抄";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
