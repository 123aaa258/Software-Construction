using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace task8
{
    public partial class Form1 : Form
    {
        private readonly string databasePath;
        private readonly string sqlFilePath;
        private readonly Random random;
        private List<WordItem> currentWords;
        private int currentIndex;

        public Form1()
        {
            this.databasePath = Path.Combine(Application.StartupPath, "words.db");
            this.sqlFilePath = Path.Combine(Application.StartupPath, "sql", "init_words.sql");
            this.random = new Random();
            this.currentWords = new List<WordItem>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                EnsureDatabase();
                LoadLevels();
                StartNewRound();
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化失败：\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.buttonRestart.Enabled = false;
                this.comboBoxLevel.Enabled = false;
                this.textBoxAnswer.Enabled = false;
            }
        }

        private void EnsureDatabase()
        {
            string sql;

            if (File.Exists(this.databasePath))
            {
                return;
            }

            if (!File.Exists(this.sqlFilePath))
            {
                throw new FileNotFoundException("未找到初始化 SQL 文件。", this.sqlFilePath);
            }

            sql = File.ReadAllText(this.sqlFilePath);

            using (SqliteConnection connection = CreateConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadLevels()
        {
            this.comboBoxLevel.Items.Clear();
            this.comboBoxLevel.Items.Add("全部");

            using (SqliteConnection connection = CreateConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT DISTINCT Level FROM Words ORDER BY Id";
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.comboBoxLevel.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }

            this.comboBoxLevel.SelectedIndex = 0;
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated)
            {
                return;
            }

            StartNewRound();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            StartNewRound();
        }

        private void textBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CheckAnswer();
            }
        }

        private void StartNewRound()
        {
            string selectedLevel;

            if (this.comboBoxLevel.SelectedItem == null)
            {
                return;
            }

            selectedLevel = this.comboBoxLevel.SelectedItem.ToString();
            this.currentWords = LoadWords(selectedLevel);

            if (this.currentWords.Count == 0)
            {
                this.labelMeaning.Text = "当前词库没有数据。";
                this.labelResult.Text = "请切换其他等级";
                this.labelProgress.Text = "0 / 0";
                this.textBoxAnswer.Clear();
                this.textBoxAnswer.Enabled = false;
                return;
            }

            ShuffleWords(this.currentWords);
            this.currentIndex = 0;
            this.textBoxAnswer.Enabled = true;
            this.labelResult.Text = "请输入英文后按回车";
            ShowCurrentWord();
        }

        private List<WordItem> LoadWords(string level)
        {
            List<WordItem> words;

            words = new List<WordItem>();

            using (SqliteConnection connection = CreateConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    if (level == "全部")
                    {
                        command.CommandText = "SELECT Id, Level, English, Chinese FROM Words ORDER BY Id";
                    }
                    else
                    {
                        command.CommandText = "SELECT Id, Level, English, Chinese FROM Words WHERE Level = @Level ORDER BY Id";
                        command.Parameters.AddWithValue("@Level", level);
                    }

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            words.Add(new WordItem(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3)));
                        }
                    }
                }
            }

            return words;
        }

        private void ShuffleWords(List<WordItem> words)
        {
            int i;
            int j;
            WordItem temp;

            for (i = words.Count - 1; i > 0; i--)
            {
                j = this.random.Next(i + 1);
                temp = words[i];
                words[i] = words[j];
                words[j] = temp;
            }
        }

        private void ShowCurrentWord()
        {
            WordItem item;

            if (this.currentWords.Count == 0)
            {
                return;
            }

            item = this.currentWords[this.currentIndex];
            this.labelMeaning.Text = item.Chinese;
            this.labelCurrentLevel.Text = "当前等级：" + item.Level;
            this.labelProgress.Text = string.Format("第 {0} / {1} 个", this.currentIndex + 1, this.currentWords.Count);
            this.textBoxAnswer.Clear();
            this.textBoxAnswer.Focus();
        }

        private void CheckAnswer()
        {
            string userAnswer;
            WordItem item;

            if (this.currentWords.Count == 0)
            {
                return;
            }

            userAnswer = this.textBoxAnswer.Text.Trim();
            if (userAnswer.Length == 0)
            {
                return;
            }

            item = this.currentWords[this.currentIndex];
            if (string.Equals(userAnswer, item.English, StringComparison.OrdinalIgnoreCase))
            {
                this.labelResult.Text = "正确";
            }
            else
            {
                this.labelResult.Text = "错误，正确答案：" + item.English;
            }

            MoveNext();
        }

        private void MoveNext()
        {
            this.currentIndex++;
            if (this.currentIndex >= this.currentWords.Count)
            {
                ShuffleWords(this.currentWords);
                this.currentIndex = 0;
                MessageBox.Show("本轮已完成，已为你重新随机开始下一轮。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ShowCurrentWord();
        }

        private SqliteConnection CreateConnection()
        {
            return new SqliteConnection("Data Source=" + this.databasePath);
        }

        private sealed class WordItem
        {
            public WordItem(int id, string level, string english, string chinese)
            {
                this.Id = id;
                this.Level = level;
                this.English = english;
                this.Chinese = chinese;
            }

            public int Id { get; private set; }

            public string Level { get; private set; }

            public string English { get; private set; }

            public string Chinese { get; private set; }
        }
    }
}
