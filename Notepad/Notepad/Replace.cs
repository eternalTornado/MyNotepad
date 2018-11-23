using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Replace : Form
    {
        public static Replace instance;
        public Replace()
        {
            InitializeComponent();
            instance = this;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        int startPos = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            String textToFind = Form1.instance.richTextBox1.Text;
            FindText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.instance.richTextBox1.Text
                = Form1.instance.richTextBox1.Text.Replace(textBox1.Text, textBox2.Text);
        }
        private void FindText()
        {
            try
            {
                Form1.instance.Focus();
                startPos = Form1.instance.richTextBox1.Find(textBox1.Text, startPos, RichTextBoxFinds.None);
                Form1.instance.richTextBox1.SelectionStart = startPos;
                Form1.instance.richTextBox1.SelectionLength = textBox1.TextLength;
                startPos += textBox1.TextLength;
            }
            catch
            {
                MessageBox.Show("No matches found");
                startPos = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindText();
            Form1.instance.richTextBox1.SelectedText = 
                Form1.instance.richTextBox1.SelectedText.Replace(textBox1.Text, textBox2.Text);
        }
    }
}
