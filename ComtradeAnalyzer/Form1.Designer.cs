namespace ComtradeAnalyzer
{
    public  partial class Form1:Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            statusStrip = new StatusStrip();
            infoToolStripStatusLabel = new ToolStripStatusLabel();
            statusLabel = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button4 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox10 = new TextBox();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            OscPlot1 = new ScottPlot.WinForms.FormsPlot();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            tabPage2 = new TabPage();
            label11 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button2 = new Button();
            comboBox6 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            Forms0 = new ScottPlot.WinForms.FormsPlot();
            Forms2 = new ScottPlot.WinForms.FormsPlot();
            Forms1 = new ScottPlot.WinForms.FormsPlot();
            tabPage3 = new TabPage();
            label12 = new Label();
            button5 = new Button();
            label9 = new Label();
            label10 = new Label();
            label8 = new Label();
            OscPlot2 = new ScottPlot.WinForms.FormsPlot();
            button3 = new Button();
            listBox4 = new ListBox();
            listBox3 = new ListBox();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1496, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(121, 22);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "COMTRADE files (*.cfg)|*.cfg|All files (*.*)|*.*";
            openFileDialog.Title = "Открыть файл COMTRADE";
            openFileDialog.FileOk += openFileDialog_FileOk;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { infoToolStripStatusLabel });
            statusStrip.Location = new Point(0, 736);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1496, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // infoToolStripStatusLabel
            // 
            infoToolStripStatusLabel.Name = "infoToolStripStatusLabel";
            infoToolStripStatusLabel.Size = new Size(39, 17);
            infoToolStripStatusLabel.Text = "Ready";
            // 
            // statusLabel
            // 
            statusLabel.Dock = DockStyle.Bottom;
            statusLabel.Location = new Point(0, 742);
            statusLabel.Margin = new Padding(2, 0, 2, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1664, 11);
            statusLabel.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(11, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1485, 705);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox10);
            tabPage1.Controls.Add(textBox9);
            tabPage1.Controls.Add(textBox8);
            tabPage1.Controls.Add(textBox7);
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(OscPlot1);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(listBox2);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1477, 677);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Данные";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(834, 628);
            button4.Name = "button4";
            button4.Size = new Size(368, 23);
            button4.TabIndex = 15;
            button4.Text = "Очистить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 619);
            label2.Name = "label2";
            label2.Size = new Size(206, 15);
            label2.TabIndex = 14;
            label2.Text = "2 Нажатия - отоброзить на графике ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 592);
            label1.Name = "label1";
            label1.Size = new Size(187, 15);
            label1.TabIndex = 13;
            label1.Text = "1 Нажатие - посмотреть данные ";
            // 
            // textBox10
            // 
            textBox10.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            textBox10.Location = new Point(947, 35);
            textBox10.Margin = new Padding(3, 2, 3, 2);
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(183, 70);
            textBox10.TabIndex = 12;
            textBox10.Text = "Амплитуда тока";
            textBox10.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            textBox9.Location = new Point(697, 47);
            textBox9.Margin = new Padding(3, 2, 3, 2);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(178, 34);
            textBox9.TabIndex = 11;
            textBox9.Text = "Ударный ток";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            textBox8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            textBox8.Location = new Point(1233, 10);
            textBox8.Margin = new Padding(3, 2, 3, 2);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(208, 36);
            textBox8.TabIndex = 10;
            textBox8.Text = "Тип замыкания";
            textBox8.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(1233, 47);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(206, 108);
            textBox7.TabIndex = 9;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(982, 112);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(110, 23);
            textBox6.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(726, 96);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(128, 59);
            textBox5.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(518, 74);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(144, 65);
            button1.TabIndex = 6;
            button1.Text = "Расчет КЗ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // OscPlot1
            // 
            OscPlot1.DisplayScale = 1.25F;
            OscPlot1.Location = new Point(614, 177);
            OscPlot1.Margin = new Padding(3, 2, 3, 2);
            OscPlot1.Name = "OscPlot1";
            OscPlot1.Size = new Size(801, 418);
            OscPlot1.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            textBox3.Location = new Point(304, 10);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(208, 36);
            textBox3.TabIndex = 3;
            textBox3.Text = "Значения";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(64, 177);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(184, 36);
            textBox2.TabIndex = 2;
            textBox2.Text = "Все сигналы";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(304, 47);
            listBox2.Margin = new Padding(3, 2, 3, 2);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(208, 604);
            listBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(64, 217);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(184, 364);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(comboBox6);
            tabPage2.Controls.Add(comboBox5);
            tabPage2.Controls.Add(comboBox4);
            tabPage2.Controls.Add(comboBox3);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(Forms0);
            tabPage2.Controls.Add(Forms2);
            tabPage2.Controls.Add(Forms1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1477, 677);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Анализ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.Location = new Point(104, 23);
            label11.Name = "label11";
            label11.Size = new Size(335, 25);
            label11.TabIndex = 17;
            label11.Text = "Выберите 3 тока или напряжения ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(843, 473);
            label7.Name = "label7";
            label7.Size = new Size(169, 15);
            label7.TabIndex = 15;
            label7.Text = "Нулевая последовательность";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(843, 232);
            label6.Name = "label6";
            label6.Size = new Size(176, 15);
            label6.TabIndex = 14;
            label6.Text = "Обратная последовательность";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(843, 5);
            label5.Name = "label5";
            label5.Size = new Size(166, 15);
            label5.TabIndex = 13;
            label5.Text = "Прямая последовательность";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(342, 102);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 12;
            label4.Text = "Напряжения";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 102);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 11;
            label3.Text = "Токи";
            // 
            // button2
            // 
            button2.Location = new Point(144, 385);
            button2.Name = "button2";
            button2.Size = new Size(155, 93);
            button2.TabIndex = 10;
            button2.Text = "Расчет симметричных состовляющих";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(318, 221);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(121, 23);
            comboBox6.TabIndex = 9;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(318, 175);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 23);
            comboBox5.TabIndex = 8;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(318, 129);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 7;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(29, 224);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 6;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(29, 175);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(29, 129);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Forms0
            // 
            Forms0.DisplayScale = 1F;
            Forms0.Location = new Point(599, 491);
            Forms0.Name = "Forms0";
            Forms0.Size = new Size(656, 183);
            Forms0.TabIndex = 2;
            // 
            // Forms2
            // 
            Forms2.DisplayScale = 1F;
            Forms2.Location = new Point(599, 250);
            Forms2.Name = "Forms2";
            Forms2.Size = new Size(656, 195);
            Forms2.TabIndex = 1;
            // 
            // Forms1
            // 
            Forms1.DisplayScale = 1F;
            Forms1.Location = new Point(599, 23);
            Forms1.Name = "Forms1";
            Forms1.Size = new Size(656, 198);
            Forms1.TabIndex = 0;
            Forms1.Load += formsPlot1_Load;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(OscPlot2);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(listBox4);
            tabPage3.Controls.Add(listBox3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1477, 677);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Итог";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label12.Location = new Point(48, 17);
            label12.Name = "label12";
            label12.Size = new Size(514, 25);
            label12.TabIndex = 18;
            label12.Text = "Выберите сигналы для сохранения или отображения";
            // 
            // button5
            // 
            button5.Location = new Point(818, 629);
            button5.Name = "button5";
            button5.Size = new Size(422, 23);
            button5.TabIndex = 17;
            button5.Text = "Очистить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(261, 547);
            label9.Name = "label9";
            label9.Size = new Size(206, 15);
            label9.TabIndex = 16;
            label9.Text = "2 Нажатия - отоброзить на графике ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 547);
            label10.Name = "label10";
            label10.Size = new Size(165, 15);
            label10.TabIndex = 15;
            label10.Text = "2 Нажатия - выбрать сигнал ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(76, 127);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 4;
            label8.Text = "Все сигналы";
            // 
            // OscPlot2
            // 
            OscPlot2.DisplayScale = 1F;
            OscPlot2.Location = new Point(642, 136);
            OscPlot2.Name = "OscPlot2";
            OscPlot2.Size = new Size(785, 472);
            OscPlot2.TabIndex = 3;
            OscPlot2.Load += formsPlot1_Load_1;
            // 
            // button3
            // 
            button3.Location = new Point(322, 69);
            button3.Name = "button3";
            button3.Size = new Size(102, 73);
            button3.TabIndex = 2;
            button3.Text = "Сохранить выбранные сигналы";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 15;
            listBox4.Location = new Point(261, 159);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(222, 364);
            listBox4.TabIndex = 1;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(16, 159);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(222, 364);
            listBox3.TabIndex = 0;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 758);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel infoToolStripStatusLabel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox listBox1;
        private ListBox listBox2;
        private TextBox textBox2;
        private TextBox textBox3;
        private ScottPlot.WinForms.FormsPlot OscPlot1;
        private Button button1;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private ScottPlot.WinForms.FormsPlot Forms0;
        private ScottPlot.WinForms.FormsPlot Forms2;
        private ScottPlot.WinForms.FormsPlot Forms1;
        private ComboBox comboBox1;
        private ComboBox comboBox6;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private Button button2;
        private TabPage tabPage3;
        private ListBox listBox4;
        private ListBox listBox3;
        private Button button3;
        private ScottPlot.WinForms.FormsPlot OscPlot2;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label label8;
        private Button button4;
        private Button button5;
        private Label label11;
        private Label label12;
    }
}