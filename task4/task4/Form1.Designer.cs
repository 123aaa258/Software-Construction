using System;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1
    {
        private Label labelFile1;
        private Label labelFile2;
        private TextBox textBoxFile1;
        private TextBox textBoxFile2;
        private Button buttonBrowseFile1;
        private Button buttonBrowseFile2;
        private Button buttonMerge;
        private OpenFileDialog openFileDialog;

        private void InitializeComponent()
        {
            this.labelFile1 = new Label();
            this.labelFile2 = new Label();
            this.textBoxFile1 = new TextBox();
            this.textBoxFile2 = new TextBox();
            this.buttonBrowseFile1 = new Button();
            this.buttonBrowseFile2 = new Button();
            this.buttonMerge = new Button();
            this.openFileDialog = new OpenFileDialog();
            this.SuspendLayout();

            this.labelFile1.AutoSize = true;
            this.labelFile1.Location = new System.Drawing.Point(28, 34);
            this.labelFile1.Name = "labelFile1";
            this.labelFile1.Size = new System.Drawing.Size(83, 17);
            this.labelFile1.TabIndex = 0;
            this.labelFile1.Text = "文本文件 1：";

            this.textBoxFile1.Location = new System.Drawing.Point(117, 31);
            this.textBoxFile1.Name = "textBoxFile1";
            this.textBoxFile1.ReadOnly = true;
            this.textBoxFile1.Size = new System.Drawing.Size(316, 23);
            this.textBoxFile1.TabIndex = 1;

            this.buttonBrowseFile1.Location = new System.Drawing.Point(448, 30);
            this.buttonBrowseFile1.Name = "buttonBrowseFile1";
            this.buttonBrowseFile1.Size = new System.Drawing.Size(92, 27);
            this.buttonBrowseFile1.TabIndex = 2;
            this.buttonBrowseFile1.Text = "选择文件";
            this.buttonBrowseFile1.UseVisualStyleBackColor = true;
            this.buttonBrowseFile1.Click += new EventHandler(this.ButtonBrowseFile1_Click);

            this.labelFile2.AutoSize = true;
            this.labelFile2.Location = new System.Drawing.Point(28, 84);
            this.labelFile2.Name = "labelFile2";
            this.labelFile2.Size = new System.Drawing.Size(83, 17);
            this.labelFile2.TabIndex = 3;
            this.labelFile2.Text = "文本文件 2：";

            this.textBoxFile2.Location = new System.Drawing.Point(117, 81);
            this.textBoxFile2.Name = "textBoxFile2";
            this.textBoxFile2.ReadOnly = true;
            this.textBoxFile2.Size = new System.Drawing.Size(316, 23);
            this.textBoxFile2.TabIndex = 4;

            this.buttonBrowseFile2.Location = new System.Drawing.Point(448, 80);
            this.buttonBrowseFile2.Name = "buttonBrowseFile2";
            this.buttonBrowseFile2.Size = new System.Drawing.Size(92, 27);
            this.buttonBrowseFile2.TabIndex = 5;
            this.buttonBrowseFile2.Text = "选择文件";
            this.buttonBrowseFile2.UseVisualStyleBackColor = true;
            this.buttonBrowseFile2.Click += new EventHandler(this.ButtonBrowseFile2_Click);

            this.buttonMerge.Location = new System.Drawing.Point(206, 137);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(156, 34);
            this.buttonMerge.TabIndex = 6;
            this.buttonMerge.Text = "合并并生成新文件";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new EventHandler(this.ButtonMerge_Click);

            this.openFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            this.openFileDialog.Title = "选择文本文件";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 204);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.buttonBrowseFile2);
            this.Controls.Add(this.textBoxFile2);
            this.Controls.Add(this.labelFile2);
            this.Controls.Add(this.buttonBrowseFile1);
            this.Controls.Add(this.textBoxFile1);
            this.Controls.Add(this.labelFile1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "文本文件合并工具";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
