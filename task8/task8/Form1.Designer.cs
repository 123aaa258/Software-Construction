using System;
using System.Windows.Forms;

namespace task8
{
    public partial class Form1
    {
        private Label labelLevelTitle;
        private ComboBox comboBoxLevel;
        private Button buttonRestart;
        private Label labelMeaningTitle;
        private Label labelMeaning;
        private Label labelAnswerTitle;
        private TextBox textBoxAnswer;
        private Label labelResultTitle;
        private Label labelResult;
        private Label labelProgress;
        private Label labelCurrentLevel;

        private void InitializeComponent()
        {
            this.labelLevelTitle = new Label();
            this.comboBoxLevel = new ComboBox();
            this.buttonRestart = new Button();
            this.labelMeaningTitle = new Label();
            this.labelMeaning = new Label();
            this.labelAnswerTitle = new Label();
            this.textBoxAnswer = new TextBox();
            this.labelResultTitle = new Label();
            this.labelResult = new Label();
            this.labelProgress = new Label();
            this.labelCurrentLevel = new Label();
            this.SuspendLayout();

            this.labelLevelTitle.AutoSize = true;
            this.labelLevelTitle.Location = new System.Drawing.Point(24, 24);
            this.labelLevelTitle.Name = "labelLevelTitle";
            this.labelLevelTitle.Size = new System.Drawing.Size(68, 17);
            this.labelLevelTitle.TabIndex = 0;
            this.labelLevelTitle.Text = "选择词库：";

            this.comboBoxLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(98, 21);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(148, 25);
            this.comboBoxLevel.TabIndex = 1;
            this.comboBoxLevel.SelectedIndexChanged += new EventHandler(this.comboBoxLevel_SelectedIndexChanged);

            this.buttonRestart.Location = new System.Drawing.Point(264, 20);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(108, 27);
            this.buttonRestart.TabIndex = 2;
            this.buttonRestart.Text = "重新开始本轮";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new EventHandler(this.buttonRestart_Click);

            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(397, 24);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(31, 17);
            this.labelProgress.TabIndex = 3;
            this.labelProgress.Text = "0 / 0";

            this.labelCurrentLevel.AutoSize = true;
            this.labelCurrentLevel.Location = new System.Drawing.Point(24, 67);
            this.labelCurrentLevel.Name = "labelCurrentLevel";
            this.labelCurrentLevel.Size = new System.Drawing.Size(68, 17);
            this.labelCurrentLevel.TabIndex = 4;
            this.labelCurrentLevel.Text = "当前等级：";

            this.labelMeaningTitle.AutoSize = true;
            this.labelMeaningTitle.Location = new System.Drawing.Point(24, 103);
            this.labelMeaningTitle.Name = "labelMeaningTitle";
            this.labelMeaningTitle.Size = new System.Drawing.Size(68, 17);
            this.labelMeaningTitle.TabIndex = 5;
            this.labelMeaningTitle.Text = "中文词义：";

            this.labelMeaning.BorderStyle = BorderStyle.FixedSingle;
            this.labelMeaning.Location = new System.Drawing.Point(27, 130);
            this.labelMeaning.Name = "labelMeaning";
            this.labelMeaning.Size = new System.Drawing.Size(525, 98);
            this.labelMeaning.TabIndex = 6;
            this.labelMeaning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.labelAnswerTitle.AutoSize = true;
            this.labelAnswerTitle.Location = new System.Drawing.Point(24, 251);
            this.labelAnswerTitle.Name = "labelAnswerTitle";
            this.labelAnswerTitle.Size = new System.Drawing.Size(68, 17);
            this.labelAnswerTitle.TabIndex = 7;
            this.labelAnswerTitle.Text = "输入英文：";

            this.textBoxAnswer.Location = new System.Drawing.Point(98, 248);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(454, 23);
            this.textBoxAnswer.TabIndex = 8;
            this.textBoxAnswer.KeyDown += new KeyEventHandler(this.textBoxAnswer_KeyDown);

            this.labelResultTitle.AutoSize = true;
            this.labelResultTitle.Location = new System.Drawing.Point(24, 293);
            this.labelResultTitle.Name = "labelResultTitle";
            this.labelResultTitle.Size = new System.Drawing.Size(44, 17);
            this.labelResultTitle.TabIndex = 9;
            this.labelResultTitle.Text = "结果：";

            this.labelResult.BorderStyle = BorderStyle.FixedSingle;
            this.labelResult.Location = new System.Drawing.Point(98, 288);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(454, 34);
            this.labelResult.TabIndex = 10;
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 350);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelResultTitle);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.labelAnswerTitle);
            this.Controls.Add(this.labelMeaning);
            this.Controls.Add(this.labelMeaningTitle);
            this.Controls.Add(this.labelCurrentLevel);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.labelLevelTitle);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "背单词练习";
            this.Load += new EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
