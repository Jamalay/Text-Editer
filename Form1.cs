using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using System.ComponentModel;
using System.Security.Cryptography;

namespace _1_k_forms
{
    public partial class Form1 : Form
    {
        string fileName;
        bool mainButton_clicked;
        bool isSaved;
        bool wrongFileFormat;
        string searching_text;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Form1()
        {
            mainButton_clicked = isSaved = wrongFileFormat = false;
            searching_text = "";
            saveFileDialog.Filter = "(*.txt)|*.txt|(*.docx)|*.docx|(*.png)|*.png|(*.jamalay)|*.jamalay|(*.xml)|*.xml|(*.rtf)|*.rtf|All files(*.*)|*.*";
            InitializeComponent();
            richTextBox1.Size = new Size(this.Width - 150, this.Height - menuStrip1.Height - 35);
            this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + 2);

        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            wrongFileFormat = false;
            try
            {
                fileName = openFileDialog.FileName;
                richTextBox1.LoadFile(fileName/*, RichTextBoxStreamType.RichText*/);
                this.Text = fileName;
                isSaved = true;
            }
            catch (Exception ex)
            {
                wrongFileFormat = true;
                MessageBox.Show($"Ошибка: {ex.Message}.\nФайл будет открыт в режиме \"Только для чтения\"");
            }
            finally
            {
                if(wrongFileFormat)
                {
                    richTextBox1.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                    richTextBox1.ReadOnly = true;
                }
            }
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (wrongFileFormat) return;
            string rtf_text = richTextBox1.Rtf;
            isSaved = true;
            Text = Text.Substring(0, Text.IndexOf("*"));
            if (fileName != null)
            {
                richTextBox1.SaveFile(fileName);
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            fileName = saveFileDialog.FileName;
            richTextBox1.SaveFile(fileName);
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
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.ShowSelectionMargin = true;
        }

        private void Change_font_familyName(object sender, EventArgs e)
        {
            int start_index = richTextBox1.SelectionStart;
            int selection_length = richTextBox1.SelectionLength;
            for (int i = start_index, j = 0; j < selection_length; i++, j++)
            {
                richTextBox1.Select(i, 1);
                var f = richTextBox1.SelectionFont;
                ComboBox combo_box_familyName = sender as ComboBox;
                richTextBox1.SelectionFont = new Font(combo_box_familyName.Text, f.Size, f.Style);
            }
            richTextBox1.SelectionStart = start_index;
            richTextBox1.SelectionLength = selection_length;
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
            if (textBox.Text.Length < searching_text.Length)
                FindText(searching_text, Color.White);
            else
                FindText(textBox.Text, Color.Coral, textBox.Text);
        }

        private void FindText(string text, Color colorOfFoundText, string searching_text_val = "")
        {
            int start_index = 0;
            int index;
            while ((index = richTextBox1.Find(text, start_index, RichTextBoxFinds.WholeWord)) >= 0 || start_index >= richTextBox1.Text.Length)
            {
                HighlightFont(index, text.Length, colorOfFoundText);
                start_index = index + text.Length;
            }
            searching_text = searching_text_val;
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

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(!Text.Contains("*"))
            {
                isSaved = false;
                Text += "*";
            }
        }

        private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream("../../TestData.txt", FileMode.OpenOrCreate))
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] key =
                    {
                        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                        0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                     };
                    aes.Key = key;

                    byte[] iv = aes.IV;
                    fileStream.Write(iv, 0, iv.Length);
                    using (CryptoStream cryptoStream = new CryptoStream(
                        fileStream,
                        aes.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        // By default, the StreamWriter uses UTF-8 encoding.
                        // To change the text encoding, pass the desired encoding as the second parameter.
                        // For example, new StreamWriter(cryptoStream, Encoding.Unicode).
                        using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
                        {
                            encryptWriter.WriteLine(richTextBox1.Text);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}