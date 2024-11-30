using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.IO.Compression;

namespace _1_k_forms
{
    public partial class Form1 : Form
    {
        string fileName;
        string filePath;
        string fileNameWithPath;
        bool mainButton_clicked;
        bool isSaved;
        bool wrongFileFormat;
        string searching_text;
        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;

        public Form1()
        {
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            mainButton_clicked = isSaved = wrongFileFormat = false;
            searching_text = "";
            saveFileDialog.Filter = "(*.rtf)|*.rtf|(*.txt)|*.txt|(*.docx)|*.docx|All files(*.*)|*.*";
            InitializeComponent();
            richTextBox1.Size = new Size(this.Width - 150, this.Height - menuStrip1.Height - 35);
            this.richTextBox1.Location = new System.Drawing.Point((this.ClientSize.Width - richTextBox1.Width) / 2, menuStrip1.Height + 2);

        }

        private void OpenFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            wrongFileFormat = false;
            try
            {
                fileName = Path.GetFileName(openFileDialog.FileName);
                filePath = Path.GetDirectoryName(openFileDialog.FileName);
                fileNameWithPath = $"{filePath}\\{fileName}";
                richTextBox1.LoadFile(fileNameWithPath, RichTextBoxStreamType.RichText);
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
                if (wrongFileFormat)
                {
                    richTextBox1.LoadFile(fileNameWithPath, RichTextBoxStreamType.PlainText);
                    richTextBox1.ReadOnly = true;
                }
            }
        }

        private void OpenFile(string fileNameWithPath)
        {
            //richTextBox1.LoadFile(fileNameWithPath, RichTextBoxStreamType.PlainText);
            //richTextBox1.ReadOnly = true;
            wrongFileFormat = false;
            try
            {
                richTextBox1.LoadFile(fileNameWithPath, RichTextBoxStreamType.RichText);
                this.Text = fileName;
                isSaved = true;
            }
            catch (Exception ex)
            {
                wrongFileFormat = true;
                //MessageBox.Show($"Ошибка: {ex.Message}.\nФайл будет открыт в режиме \"Только для чтения\"");
            }
            finally
            {
                if (wrongFileFormat)
                {
                    richTextBox1.LoadFile(fileNameWithPath, RichTextBoxStreamType.PlainText);
                    richTextBox1.ReadOnly = true;
                }
            }
        }

        private void SaveFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (wrongFileFormat) return;
            string rtf_text = richTextBox1.Rtf;
            isSaved = true;
            Text = Text.Substring(0, Text.IndexOf("*"));
            if (fileName != null)
            {
                richTextBox1.SaveFile(fileNameWithPath);
                return;
            }
            SaveFile();
        }

        private void SaveFile()
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                fileNameWithPath = saveFileDialog.FileName;
                filePath = Path.GetDirectoryName(fileNameWithPath);
                fileName = Path.GetFileName(fileNameWithPath);
                richTextBox1.SaveFile(fileNameWithPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateNewFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        private void CreateNewFile()
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                fileName = saveFileDialog.FileName;
                System.IO.File.Create(fileName).Close();
                this.Text = fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            ComboBox combo_box_familyName = sender as ComboBox;
            int start_index = richTextBox1.SelectionStart;
            int selection_length = richTextBox1.SelectionLength;
            for (int i = start_index, j = 0; j < selection_length; i++, j++)
            {
                richTextBox1.Select(i, 1);
                var f = richTextBox1.SelectionFont;
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
            while ((index = richTextBox1.Find(text, start_index, RichTextBoxFinds.WholeWord)) >= 0)
            {
                if (start_index >= richTextBox1.TextLength)
                {
                    searching_text = searching_text_val;
                    return;
                }
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
            if (fileName == null) SaveFile();

            try
            {
                // Генерируем новый ключ
                using (Aes aes = Aes.Create())
                {
                    aes.GenerateKey();
                    byte[] key = aes.Key;

                    // Шифруем ключ с помощью DPAPI
                    byte[] protectedKey = ProtectedData.Protect(key, null, DataProtectionScope.CurrentUser);

                    //Путь к архиву, который будет создан или открыт
                    string zipPath = $"{filePath}\\{fileName}.zip";

                    // Сохраняем зашифрованный ключ в файл
                    string keyFilePath = $"{filePath}\\key.dat"; // Путь к файлу для сохранения зашифрованного ключа
                    File.WriteAllBytes(keyFilePath, protectedKey);


                    // Генерируем IV и записываем его в файл
                    byte[] iv = aes.IV;

                    using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.OpenOrCreate))
                    {
                        // Записываем IV в начало файла
                        fileStream.Write(iv, 0, iv.Length);

                        using (CryptoStream cryptoStream = new CryptoStream(
                            fileStream,
                            aes.CreateEncryptor(),
                            CryptoStreamMode.Write))
                        {
                            using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
                                encryptWriter.WriteLine(richTextBox1.Rtf);
                        }
                    }
                    // Создаем или открываем ZIP-архив
                    using (var zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                    {
                        // Добавляем файлы в архив
                        zipArchive.CreateEntryFromFile(keyFilePath, Path.GetFileName(keyFilePath));
                        zipArchive.CreateEntryFromFile(fileNameWithPath, Path.GetFileName(fileNameWithPath));
                        File.Delete(keyFilePath);
                        File.Delete(fileNameWithPath);
                    }
                    File.Move(zipPath, $"{filePath}\\{fileName}.enc");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == null) OpenFile();

            try
            {
                if(!fileName.Contains(".enc"))
                    throw new Exception("Файлы без расширения .enc нельзя расшифровать");

                string f = Path.ChangeExtension(fileNameWithPath, ".zip");
                File.Move(fileNameWithPath, f);
                fileNameWithPath = f;

                ZipFile.ExtractToDirectory(fileNameWithPath, filePath);
                File.Delete(fileNameWithPath);
                fileNameWithPath = Path.ChangeExtension(fileNameWithPath, "");
                fileName = Path.GetFileName(fileNameWithPath);
                filePath = Path.GetDirectoryName(fileNameWithPath);

                OpenFile(fileNameWithPath);

                // Считываем зашифрованный ключ из файла
                string keyFilePath = $"{filePath}\\key.dat"; // Путь к файлу, где хранится зашифрованный ключ
                byte[] protectedKey = File.ReadAllBytes(keyFilePath);
                // Дешифруем ключ с помощью DPAPI
                byte[] key = ProtectedData.Unprotect(protectedKey, null, DataProtectionScope.CurrentUser);
                using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Open))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] iv = new byte[aes.IV.Length];
                        int numBytesToRead = aes.IV.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                            if (n == 0) break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        using (CryptoStream cryptoStream = new CryptoStream(
                           fileStream,
                           aes.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                        {
                            using (StreamReader decryptReader = new StreamReader(cryptoStream))
                            {
                                richTextBox1.Text = await decryptReader.ReadToEndAsync();
                            }
                        }
                    }
                    File.Delete(keyFilePath);
                }

                wrongFileFormat = false;
                richTextBox1.ReadOnly = false;
                richTextBox1.Rtf = richTextBox1.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}