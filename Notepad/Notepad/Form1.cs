using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        String filePath;
        Find findForm;
        Replace replaceForm;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            this.Text = "My Notepad";
            filePath = "";
            findNextToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                String text = File.ReadAllText(filePath);
                this.Text = openFileDialog1.SafeFileName + " - My Notepad";
                richTextBox1.Text = text;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath != "")
            {
                TextWriter textWriter = new StreamWriter(filePath);
                textWriter.Write(richTextBox1.Text);
                textWriter.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "sample.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            String fName = saveFileDialog1.FileName;
            StreamWriter streamWriter = new StreamWriter(fName);
            streamWriter.Write(richTextBox1.Text);
            streamWriter.Flush();
            streamWriter.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Find.instance == null)
                findForm = new Find();
            if (Find.instance != null)
                findForm.Show();
            findForm.Focus();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText()) {
                richTextBox1.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now.ToString();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == false)
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by NgDucVuTruong, MSSV: 15520951", "About me");
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Replace.instance == null)
                replaceForm = new Replace();
            if (Replace.instance != null)
                replaceForm.Show();
            replaceForm.Focus();
        }
        int startSearchPos = 0;
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = Find.instance.textBox1.Text;
            try
            {
                richTextBox1.Find(text, startSearchPos, RichTextBoxFinds.None);
                richTextBox1.Select(startSearchPos, text.Length);
            }
            catch
            {
                MessageBox.Show("No Matches Found");
                startSearchPos = 0;
            }
        }

        
    }
}
