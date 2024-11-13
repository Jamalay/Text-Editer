using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using System.ComponentModel;

namespace _1_k_forms
{
    public partial class Form1 : Form
    {
        string fileName;
        bool mainButton_clicked;
        bool isSaved;
        string searching_text;
        int searching_index;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Form1()
        {
            mainButton_clicked = isSaved = false;
            searching_text = "";
            searching_index = 0;
            saveFileDialog.Filter = "(*.txt)|*.txt|(*.docx)|*.docx|(*.png)|*.png|(*.jamalay)|*.jamalay|(*.xml)|*.xml|(*.rtf)|*.rtf|All files(*.*)|*.*";
            InitializeComponent();
            richTextBox1.Size = new Size(this.Width - 150, this.Height - menuStrip1.Height - 35);
            this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + 2);

        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                fileName = openFileDialog.FileName;
                richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);
                this.Text = fileName;
                isSaved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string rtf_text = richTextBox1.Rtf;
            if (fileName != null)
            {
                richTextBox1.SaveFile(fileName);
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            fileName = saveFileDialog.FileName;
            richTextBox1.SaveFile(fileName);
            Text = Text.Substring(Text.IndexOf("*")-1,1);
        }

        private void CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            fileName = saveFileDialog.FileName;
            System.IO.File.Create(fileName).Close();
            this.Text = fileName;
        }

        private void FontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.Font = fontDialog1.Font;
            richTextBox1.ShowSelectionMargin = true;
        }

        private void Change_font_familyName(object sender, EventArgs e)
        {
            var f = richTextBox1.SelectionFont;
            if(f == null)
                return;
            ComboBox combo_box_familyName = sender as ComboBox;
            richTextBox1.SelectionFont = new Font(combo_box_familyName.Text, f.Size, f.Style);
        }

        private void Change_font_size(object sender, EventArgs e)
        {
            var f = richTextBox1.SelectionFont;
            ComboBox combo_box_size = sender as ComboBox;
            richTextBox1.SelectionFont = new Font(f.FontFamily, float.Parse(combo_box_size.Text), f.Style);
        }

        private void Fast_font_change_button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            FontStyle clicked_font_style;
            switch (button.Name)
            {
                case "italic_font_button":
                    clicked_font_style = FontStyle.Italic;
                    break;
                case "bold_font_button":
                    clicked_font_style = FontStyle.Bold;
                    break;
                case "underline_font_style":
                    clicked_font_style = FontStyle.Underline;
                    break;
                case "strikeout_font_style":
                    clicked_font_style = FontStyle.Strikeout;
                    break;
                default:
                    clicked_font_style = FontStyle.Regular;
                    break;
            }
            var highlighted_font = richTextBox1.SelectionFont;

            if ((highlighted_font.Style & clicked_font_style) != clicked_font_style)
                richTextBox1.SelectionFont = new Font(highlighted_font.FontFamily, highlighted_font.Size, highlighted_font.Style | clicked_font_style);
            
            else
            {
                FontStyle removing_font = highlighted_font.Style & ~clicked_font_style;
                richTextBox1.SelectionFont = new Font(highlighted_font.FontFamily, highlighted_font.Size, removing_font);
            }
        }

        private void MainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainButton_clicked = !mainButton_clicked;
            groupBox1.Visible = mainButton_clicked;
            if (mainButton_clicked)
            {
                richTextBox1.Size = new Size(this.Width - 150, this.Height - menuStrip1.Height - groupBox1.Height - 35);
                this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + groupBox1.Height + 2);
                mainToolStripMenuItem.BackColor = Color.Coral;
            }
            else
            {
                richTextBox1.Size = new Size(this.Width - 150, this.Height - menuStrip1.Height - 35);
                this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + 2);
                mainToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int start_index = 0;
            int index;
            if (textBox.Text.Length < searching_text.Length)
            {
                while ((index = richTextBox1.Find(searching_text, start_index, RichTextBoxFinds.None)) >= 0)
                {
                    HighlightFont(index, searching_text.Length, Color.White);
                    start_index = index + searching_text.Length;
                }
                searching_text = "";
            }
            else
            {
                while ((index = richTextBox1.Find(textBox.Text, start_index, RichTextBoxFinds.WholeWord)) >= 0 || start_index >= richTextBox1.Text.Length)
                {
                    HighlightFont(index, textBox.Text.Length, Color.Coral);
                    start_index = index + textBox.Text.Length;

                }
                searching_text = textBox.Text;
            }
        }
        
        private void FindText()
        {

        }

        private void HighlightFont(int index, int wordLength, Color color)
        {
            richTextBox1.Select(index, wordLength);
            richTextBox1.SelectionBackColor = color;
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 500)
                richTextBox1.Size = new Size(this.Width - 15, this.Height - menuStrip1.Height - 35);
            else
                richTextBox1.Size = new Size(this.Width - 150, this.Height - menuStrip1.Height - 35);

            if(mainButton_clicked)
                this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + groupBox1.Height + 2);
            else
                this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + 2);
        }

        //private void richTextBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if (isSaved)
        //    {
        //        isSaved = false;
        //        Text = Text + "*";
        //    }
        //}
    }
}