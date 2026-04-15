using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace task6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFetch_Click(object sender, EventArgs e)
        {
            string url;
            string html;
            MatchCollection phoneMatches;
            MatchCollection emailMatches;

            this.listBoxPhones.Items.Clear();
            this.listBoxEmails.Items.Clear();

            url = this.textBoxUrl.Text.Trim();
            if (url.Length == 0)
            {
                MessageBox.Show("请输入网页地址。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                MessageBox.Show("请输入正确的 URL。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    html = client.GetStringAsync(url).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取网页失败：\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            phoneMatches = Regex.Matches(html, @"1[3-9]\d{9}");
            emailMatches = Regex.Matches(html, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}");

            AddUniqueMatches(this.listBoxPhones, phoneMatches);
            AddUniqueMatches(this.listBoxEmails, emailMatches);

            if (this.listBoxPhones.Items.Count == 0)
            {
                this.listBoxPhones.Items.Add("未找到手机号");
            }

            if (this.listBoxEmails.Items.Count == 0)
            {
                this.listBoxEmails.Items.Add("未找到邮箱");
            }
        }

        private void AddUniqueMatches(ListBox listBox, MatchCollection matches)
        {
            HashSet<string> values;
            int i;

            values = new HashSet<string>();
            for (i = 0; i < matches.Count; i++)
            {
                if (values.Add(matches[i].Value))
                {
                    listBox.Items.Add(matches[i].Value);
                }
            }
        }
    }
}
