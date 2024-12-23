﻿using System.Windows.Forms;
using System.Drawing;

namespace _1_k_forms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.open = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.save_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextColorChangeButton = new System.Windows.Forms.Button();
            this.BackColorChangeButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.strikeout_font_style = new System.Windows.Forms.Button();
            this.underline_font_style = new System.Windows.Forms.Button();
            this.italic_font_button = new System.Windows.Forms.Button();
            this.bold_font_button = new System.Windows.Forms.Button();
            this.font_size_box = new System.Windows.Forms.ComboBox();
            this.font_familyName_box = new System.Windows.Forms.ComboBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 14F);
            this.richTextBox1.Location = new System.Drawing.Point(0, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(836, 456);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(0, 0);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 8;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(0, 0);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mainToolStripMenuItem,
            this.fontsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(836, 30);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.createToolStripMenuItem1,
            this.encryptToolStripMenuItem,
            this.decryptToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.OpenFileToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.saveToolStripMenuItem1.Text = "SaveFile";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.SaveFileToolStripMenuItem1_Click);
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.createToolStripMenuItem1.Text = "Create";
            this.createToolStripMenuItem1.Click += new System.EventHandler(this.CreateNewFileToolStripMenuItem1_Click);
            // 
            // encryptToolStripMenuItem
            // 
            this.encryptToolStripMenuItem.Name = "encryptToolStripMenuItem";
            this.encryptToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.encryptToolStripMenuItem.Text = "Encrypt";
            this.encryptToolStripMenuItem.Click += new System.EventHandler(this.EncryptToolStripMenuItem_Click);
            // 
            // decryptToolStripMenuItem
            // 
            this.decryptToolStripMenuItem.Name = "decryptToolStripMenuItem";
            this.decryptToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.decryptToolStripMenuItem.Text = "Decrypt";
            this.decryptToolStripMenuItem.Click += new System.EventHandler(this.DecryptToolStripMenuItem_Click);
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.MainToolStripMenuItem_Click);
            // 
            // fontsToolStripMenuItem
            // 
            this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
            this.fontsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.fontsToolStripMenuItem.Text = "fonts";
            this.fontsToolStripMenuItem.Click += new System.EventHandler(this.FontsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.OldLace;
            this.groupBox1.Controls.Add(this.TextColorChangeButton);
            this.groupBox1.Controls.Add(this.BackColorChangeButton);
            this.groupBox1.Controls.Add(this.searchBox);
            this.groupBox1.Controls.Add(this.strikeout_font_style);
            this.groupBox1.Controls.Add(this.underline_font_style);
            this.groupBox1.Controls.Add(this.italic_font_button);
            this.groupBox1.Controls.Add(this.bold_font_button);
            this.groupBox1.Controls.Add(this.font_size_box);
            this.groupBox1.Controls.Add(this.font_familyName_box);
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 123);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // TextColorChangeButton
            // 
            this.TextColorChangeButton.FlatAppearance.BorderSize = 0;
            this.TextColorChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextColorChangeButton.Location = new System.Drawing.Point(219, 67);
            this.TextColorChangeButton.Name = "TextColorChangeButton";
            this.TextColorChangeButton.Size = new System.Drawing.Size(40, 35);
            this.TextColorChangeButton.TabIndex = 13;
            this.TextColorChangeButton.Text = "A";
            this.TextColorChangeButton.UseVisualStyleBackColor = true;
            // 
            // BackColorChangeButton
            // 
            this.BackColorChangeButton.FlatAppearance.BorderSize = 0;
            this.BackColorChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColorChangeButton.Location = new System.Drawing.Point(173, 67);
            this.BackColorChangeButton.Name = "BackColorChangeButton";
            this.BackColorChangeButton.Size = new System.Drawing.Size(40, 35);
            this.BackColorChangeButton.TabIndex = 12;
            this.BackColorChangeButton.Text = "A";
            this.BackColorChangeButton.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.AccessibleDescription = "";
            this.searchBox.AllowDrop = true;
            this.searchBox.ForeColor = System.Drawing.Color.Gray;
            this.searchBox.Location = new System.Drawing.Point(310, 21);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(190, 31);
            this.searchBox.TabIndex = 11;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // strikeout_font_style
            // 
            this.strikeout_font_style.FlatAppearance.BorderSize = 0;
            this.strikeout_font_style.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.strikeout_font_style.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Strikeout);
            this.strikeout_font_style.Location = new System.Drawing.Point(129, 67);
            this.strikeout_font_style.Name = "strikeout_font_style";
            this.strikeout_font_style.Size = new System.Drawing.Size(40, 35);
            this.strikeout_font_style.TabIndex = 5;
            this.strikeout_font_style.Text = "ab";
            this.strikeout_font_style.UseVisualStyleBackColor = true;
            this.strikeout_font_style.Click += new System.EventHandler(this.Fast_font_change_button_Click);
            // 
            // underline_font_style
            // 
            this.underline_font_style.FlatAppearance.BorderSize = 0;
            this.underline_font_style.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.underline_font_style.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Underline);
            this.underline_font_style.Location = new System.Drawing.Point(88, 67);
            this.underline_font_style.Name = "underline_font_style";
            this.underline_font_style.Size = new System.Drawing.Size(35, 35);
            this.underline_font_style.TabIndex = 4;
            this.underline_font_style.Text = "U";
            this.underline_font_style.UseVisualStyleBackColor = true;
            this.underline_font_style.Click += new System.EventHandler(this.Fast_font_change_button_Click);
            // 
            // italic_font_button
            // 
            this.italic_font_button.FlatAppearance.BorderSize = 0;
            this.italic_font_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.italic_font_button.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Italic);
            this.italic_font_button.Location = new System.Drawing.Point(47, 67);
            this.italic_font_button.Name = "italic_font_button";
            this.italic_font_button.Size = new System.Drawing.Size(35, 35);
            this.italic_font_button.TabIndex = 3;
            this.italic_font_button.Text = "I";
            this.italic_font_button.UseVisualStyleBackColor = true;
            this.italic_font_button.Click += new System.EventHandler(this.Fast_font_change_button_Click);
            // 
            // bold_font_button
            // 
            this.bold_font_button.FlatAppearance.BorderSize = 0;
            this.bold_font_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bold_font_button.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.bold_font_button.Location = new System.Drawing.Point(6, 67);
            this.bold_font_button.Name = "bold_font_button";
            this.bold_font_button.Size = new System.Drawing.Size(35, 35);
            this.bold_font_button.TabIndex = 2;
            this.bold_font_button.Text = "B";
            this.bold_font_button.UseVisualStyleBackColor = false;
            this.bold_font_button.Click += new System.EventHandler(this.Fast_font_change_button_Click);
            // 
            // font_size_box
            // 
            this.font_size_box.Font = new System.Drawing.Font("Calibri", 11F);
            this.font_size_box.FormattingEnabled = true;
            this.font_size_box.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24,
            25,
            26,
            27,
            28,
            29,
            30});
            this.font_size_box.Location = new System.Drawing.Point(173, 21);
            this.font_size_box.Name = "font_size_box";
            this.font_size_box.Size = new System.Drawing.Size(88, 30);
            this.font_size_box.TabIndex = 1;
            this.font_size_box.Text = "14";
            this.font_size_box.SelectedIndexChanged += new System.EventHandler(this.Change_font_size);
            // 
            // font_familyName_box
            // 
            this.font_familyName_box.Font = new System.Drawing.Font("Calibri", 11F);
            this.font_familyName_box.FormattingEnabled = true;
            this.font_familyName_box.Items.AddRange(new object[] {
            "Roboto",
            "Calibri",
            "Arial",
            "Algerian"});
            this.font_familyName_box.Location = new System.Drawing.Point(6, 21);
            this.font_familyName_box.Name = "font_familyName_box";
            this.font_familyName_box.Size = new System.Drawing.Size(161, 30);
            this.font_familyName_box.TabIndex = 0;
            this.font_familyName_box.Text = "Calibri";
            this.font_familyName_box.SelectedIndexChanged += new System.EventHandler(this.Change_font_familyName);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.open);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.richTextBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem mainToolStripMenuItem;
        private ToolStripMenuItem fontsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private GroupBox groupBox1;
        private ComboBox font_familyName_box;
        private ComboBox font_size_box;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private Button italic_font_button;
        private Button bold_font_button;
        private Button underline_font_style;
        private Button strikeout_font_style;
        private TextBox searchBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private ToolStripMenuItem encryptToolStripMenuItem;
        private Button TextColorChangeButton;
        private Button BackColorChangeButton;
        private ToolStripMenuItem decryptToolStripMenuItem;
    }
}