using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonBrowseFile1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFile1.Text = this.openFileDialog.FileName;
            }
        }

        private void ButtonBrowseFile2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxFile2.Text = this.openFileDialog.FileName;
            }
        }

        private void ButtonMerge_Click(object sender, EventArgs e)
        {
            string file1Path = this.textBoxFile1.Text.Trim();
            string file2Path = this.textBoxFile2.Text.Trim();

            if (file1Path.Length == 0 || file2Path.Length == 0)
            {
                MessageBox.Show("请先选择两个文本文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!File.Exists(file1Path) || !File.Exists(file2Path))
            {
                MessageBox.Show("所选文件不存在，请重新选择。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string content1 = File.ReadAllText(file1Path, Encoding.UTF8);
                string content2 = File.ReadAllText(file2Path, Encoding.UTF8);
                string dataDirectory = Path.Combine(Application.StartupPath, "Data");
                string outputFileName = "Merged_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                string outputFilePath = Path.Combine(dataDirectory, outputFileName);
                string mergedContent;

                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                mergedContent = content1 + Environment.NewLine + content2;
                File.WriteAllText(outputFilePath, mergedContent, Encoding.UTF8);

                MessageBox.Show("合并完成，新文件已保存到：\n" + outputFilePath, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("处理文件时发生错误：\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
