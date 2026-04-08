using System;
using System.Windows.Forms;

namespace task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button;

            if (this.textBoxDisplay.Text.IndexOf('=') >= 0)
            {
                this.textBoxDisplay.Clear();
            }

            button = sender as Button;
            if (button != null)
            {
                this.textBoxDisplay.Text += button.Text;
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button;
            string text;
            char lastChar;

            if (this.textBoxDisplay.Text.Length == 0)
            {
                return;
            }

            if (this.textBoxDisplay.Text.IndexOf('=') >= 0)
            {
                text = this.textBoxDisplay.Text;
                this.textBoxDisplay.Text = text.Substring(text.IndexOf('=') + 1);
            }

            text = this.textBoxDisplay.Text;
            lastChar = text[text.Length - 1];
            if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
            {
                return;
            }

            button = sender as Button;
            if (button != null)
            {
                this.textBoxDisplay.Text += button.Text;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxDisplay.Clear();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            string expression;
            double leftValue;
            double rightValue;
            double result;
            char op;

            expression = this.textBoxDisplay.Text;
            if (!TryParseExpression(expression, out leftValue, out op, out rightValue))
            {
                MessageBox.Show("请输入完整的表达式。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (op == '/' && rightValue == 0)
            {
                MessageBox.Show("除数不能为 0。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (op)
            {
                case '+':
                    result = leftValue + rightValue;
                    break;
                case '-':
                    result = leftValue - rightValue;
                    break;
                case '*':
                    result = leftValue * rightValue;
                    break;
                default:
                    result = leftValue / rightValue;
                    break;
            }

            this.textBoxDisplay.Text = expression + "=" + FormatNumber(result);
        }

        private bool TryParseExpression(string expression, out double leftValue, out char op, out double rightValue)
        {
            int i;
            int operatorIndex;
            string leftText;
            string rightText;

            leftValue = 0;
            rightValue = 0;
            op = '\0';
            operatorIndex = -1;

            for (i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    operatorIndex = i;
                    op = expression[i];
                    break;
                }
            }

            if (operatorIndex <= 0 || operatorIndex >= expression.Length - 1)
            {
                return false;
            }

            leftText = expression.Substring(0, operatorIndex);
            rightText = expression.Substring(operatorIndex + 1);

            if (!double.TryParse(leftText, out leftValue))
            {
                return false;
            }

            if (!double.TryParse(rightText, out rightValue))
            {
                return false;
            }

            return true;
        }

        private string FormatNumber(double value)
        {
            if (value == (int)value)
            {
                return ((int)value).ToString();
            }

            return value.ToString();
        }
    }
}
