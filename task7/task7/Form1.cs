using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword;
            int extractLength;
            Task<string> baiduTask;
            Task<string> bingTask;
            string[] results;

            keyword = this.textBoxKeyword.Text.Trim();
            if (keyword.Length == 0)
            {
                MessageBox.Show("请输入关键字。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!int.TryParse(this.textBoxLength.Text.Trim(), out extractLength) || extractLength <= 0)
            {
                MessageBox.Show("请输入正确的摘取字数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxLength.Focus();
                return;
            }

            this.buttonSearch.Enabled = false;
            this.textBoxBaiduResult.Text = "正在搜索百度...";
            this.textBoxBingResult.Text = "正在搜索 Bing...";

            baiduTask = FetchSearchSummaryAsync("https://www.baidu.com/s?wd=" + Uri.EscapeDataString(keyword), "百度", extractLength);
            bingTask = FetchSearchSummaryAsync("https://www.bing.com/search?q=" + Uri.EscapeDataString(keyword), "Bing", extractLength);

            try
            {
                results = await Task.WhenAll(baiduTask, bingTask);
                this.textBoxBaiduResult.Text = results[0];
                this.textBoxBingResult.Text = results[1];
            }
            finally
            {
                this.buttonSearch.Enabled = true;
            }
        }

        private async Task<string> FetchSearchSummaryAsync(string url, string engineName, int extractLength)
        {
            string html;
            string text;
            HttpRequestMessage request;

            try
            {
                using (HttpClient client = new HttpClient())
                using (request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/134.0.0.0 Safari/537.36 Edg/134.0.0.0");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Cache-Control", "max-age=0");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Sec-CH-UA", "\"Chromium\";v=\"134\", \"Microsoft Edge\";v=\"134\", \"Not:A-Brand\";v=\"24\"");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Sec-CH-UA-Mobile", "?0");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Sec-CH-UA-Platform", "\"Windows\"");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                    if (engineName == "百度")
                    {
                        request.Headers.Referrer = new Uri("https://www.baidu.com/");
                    }
                    else
                    {
                        request.Headers.Referrer = new Uri("https://www.bing.com/");
                    }

                    html = await (await client.SendAsync(request)).Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return engineName + " 搜索失败：" + ex.Message;
            }

            if (engineName == "百度" && IsBaiduVerificationPage(html))
            {
                return "百度返回了安全验证内容，应该是当前网络环境被限制了。我试过使用香港节点后就没问题，可以再试一下。";
            }

            text = ExtractPlainText(html);
            if (text.Length == 0)
            {
                return engineName + " 没有提取到有效文字。";
            }

            if (text.Length > extractLength)
            {
                text = text.Substring(0, extractLength);
            }

            return text;
        }

        private string ExtractPlainText(string html)
        {
            string text;

            text = Regex.Replace(html, @"<script[\s\S]*?</script>", " ", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"<style[\s\S]*?</style>", " ", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"<[^>]+>", " ");
            text = WebUtility.HtmlDecode(text);
            text = Regex.Replace(text, @"\s+", " ");
            text = text.Trim();
            return text;
        }

        private bool IsBaiduVerificationPage(string html)
        {
            return html.IndexOf("安全验证") >= 0
                || html.IndexOf("验证码") >= 0
                || html.IndexOf("网络不给力") >= 0
                || html.IndexOf("稍后重试") >= 0
                || html.IndexOf("问题反馈") >= 0;
        }
    }
}
