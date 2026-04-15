using System;
using System.Windows.Forms;

namespace task6
{
    public partial class Form1
    {
        private Label labelUrl;
        private TextBox textBoxUrl;
        private Button buttonFetch;
        private Label labelPhones;
        private Label labelEmails;
        private ListBox listBoxPhones;
        private ListBox listBoxEmails;

        private void InitializeComponent()
        {
            this.labelUrl = new Label();
            this.textBoxUrl = new TextBox();
            this.buttonFetch = new Button();
            this.labelPhones = new Label();
            this.labelEmails = new Label();
            this.listBoxPhones = new ListBox();
            this.listBoxEmails = new ListBox();
            this.SuspendLayout();

            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(22, 24);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(34, 17);
            this.labelUrl.TabIndex = 0;
            this.labelUrl.Text = "URL";

            this.textBoxUrl.Location = new System.Drawing.Point(62, 21);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(430, 23);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.Text = "http://localhost:5000/test.html";

            this.buttonFetch.Location = new System.Drawing.Point(510, 19);
            this.buttonFetch.Name = "buttonFetch";
            this.buttonFetch.Size = new System.Drawing.Size(108, 27);
            this.buttonFetch.TabIndex = 2;
            this.buttonFetch.Text = "获取并提取";
            this.buttonFetch.UseVisualStyleBackColor = true;
            this.buttonFetch.Click += new EventHandler(this.buttonFetch_Click);

            this.labelPhones.AutoSize = true;
            this.labelPhones.Location = new System.Drawing.Point(25, 71);
            this.labelPhones.Name = "labelPhones";
            this.labelPhones.Size = new System.Drawing.Size(56, 17);
            this.labelPhones.TabIndex = 3;
            this.labelPhones.Text = "手机号：";

            this.labelEmails.AutoSize = true;
            this.labelEmails.Location = new System.Drawing.Point(329, 71);
            this.labelEmails.Name = "labelEmails";
            this.labelEmails.Size = new System.Drawing.Size(44, 17);
            this.labelEmails.TabIndex = 4;
            this.labelEmails.Text = "邮箱：";

            this.listBoxPhones.FormattingEnabled = true;
            this.listBoxPhones.ItemHeight = 17;
            this.listBoxPhones.Location = new System.Drawing.Point(28, 100);
            this.listBoxPhones.Name = "listBoxPhones";
            this.listBoxPhones.Size = new System.Drawing.Size(265, 225);
            this.listBoxPhones.TabIndex = 5;

            this.listBoxEmails.FormattingEnabled = true;
            this.listBoxEmails.ItemHeight = 17;
            this.listBoxEmails.Location = new System.Drawing.Point(332, 100);
            this.listBoxEmails.Name = "listBoxEmails";
            this.listBoxEmails.Size = new System.Drawing.Size(286, 225);
            this.listBoxEmails.TabIndex = 6;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 355);
            this.Controls.Add(this.listBoxEmails);
            this.Controls.Add(this.listBoxPhones);
            this.Controls.Add(this.labelEmails);
            this.Controls.Add(this.labelPhones);
            this.Controls.Add(this.buttonFetch);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.labelUrl);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "网页手机号和邮箱提取";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
