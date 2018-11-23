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
    public partial class Find : Form
    {
        public static Find instance;
        int startPos = 0;
        public Find()
        {
            InitializeComponent();
            instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.instance.findNextToolStripMenuItem.Enabled = true;
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
    }
}
