using ScottPlot.WinForms;
using ScottPlot;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ScottPlot.Hatches;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using ScottPlot.Plottables;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Reflection.PortableExecutable;

namespace ComtradeAnalyzer
{
    public partial class Form1 : Form
    {
        public ComtradeReader comtradeReader;
        public PlotData1 plotData1;

        public List<List<double>> SignalsOsc = new List<List<double>>();
        private List<List<double>> channelData = new List<List<double>>();
        public List<string> plottedSignals = new List<string>();
        public double timeSeconds;

        public string FileName;
        public Form1()
        {
            InitializeComponent();
            
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.DoubleClick += ListBox1_DoubleClick;
            listBox3.DoubleClick += ListBox3_DoubleClick;
            listBox4.DoubleClick += ListBox4_DoubleClick;
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "COMTRADE files (*.cfg)|*.cfg|All files (*.*)|*.*";
                openFileDialog.Title = "Открыть файл COMTRADE";
                string FileName = openFileDialog.FileName;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadComtradeFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadComtradeFile(string filePath)
        {
            statusLabel.Text = $"Загрузка файла: {Path.GetFileName(filePath)}";
            Application.DoEvents();

            try
            {
                comtradeReader = new ComtradeReader(filePath, 10, 10);
                this.Text = $"Осциллограф: {Path.GetFileName(filePath)}";
                PlotData1 PlotData1 = new PlotData1();
                PlotData1.PlotData(comtradeReader, tabControl1); 
                PrintData();
                ComboFill(comtradeReader);
            }
            catch (Exception ex)
            {
                infoToolStripStatusLabel.Text = "Ошибка загрузки файла.";
                MessageBox.Show($"Ошибка обработки файла COMTRADE: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


       
        public void PrintData()
        {
            channelData.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            for (int i = 0; i < comtradeReader._signalsCount; i++)
            {

                var points = new List<double>();

                for (int j = 0; j < comtradeReader.dots; j++)
                {
                    if (j < comtradeReader.Signals[i].Count)
                    {
                        points.Add(comtradeReader.Signals[i][j]);
                    }
                }

                
                channelData.Add(points);
                listBox1.Items.Add(comtradeReader.channelNames[i]);
                listBox3.Items.Add(comtradeReader.channelNames[i]);
            }

            
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                listBox3.SelectedIndex = 0;
            }
        }



        public TabControl GetTabControl()
        {
            return this.tabControl1;
        }


        private void SignalCount(object sender, EventArgs e)
        {
            {
             
                try
                {
                    
                    if (comtradeReader?.channelNames != null && comtradeReader.channelNames.Count > 0)
                    {
                        
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < comtradeReader.Units.Count; i++)
                        {
                            sb.AppendLine($"{i + 1}. {comtradeReader.Units[i]}");
                        }
                        MessageBox.Show(sb.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Список сигналов пуст");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                
            }

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= channelData.Count)
                return;

            
            var selectedChannel = channelData[listBox1.SelectedIndex];

            
            listBox2.Items.Clear();

            
            for (int i = 0; i < selectedChannel.Count; i++)
            {
                listBox2.Items.Add($"{i + 1}: {selectedChannel[i]:F6}");
            }
        }



        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= channelData.Count)
                return;

            string signalName = listBox1.Items[listBox1.SelectedIndex].ToString();
            var signalData = channelData[listBox1.SelectedIndex];

            
            if (plottedSignals.Contains(signalName))
            {
                MessageBox.Show($"Сигнал '{signalName}' уже добавлен на график");
                return;
            }
            PlotData1 PlotData1 = new PlotData1();
            PlotData1.PlotChosen(comtradeReader, signalName, signalData, OscPlot1);
            
            OscPlot1.Refresh();

            
            plottedSignals.Add(signalName);

            
            listBox2.Items.Add($"Добавлен: {signalName}");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comtradeReader == null)
            {
                MessageBox.Show("Сначала загрузите COMTRADE файл");
                return;
            }

            ShortCircuit KZ = new ShortCircuit();
            KZ.Analyze(comtradeReader);
            int phasesCount = KZ.KZphaseA + KZ.KZphaseB + KZ.KZphaseC;

            string kzType = phasesCount switch
            {
                1 => "Однофазное КЗ" + Environment.NewLine,
                2 => "Двухфазное КЗ" + Environment.NewLine,
                3 => "Трехфазное КЗ" + Environment.NewLine,
                _ => "Нет КЗ" + Environment.NewLine
            };
            textBox7.Text = kzType;
            textBox5.AppendText($"Ударный ток в сигнале:{KZ.MaxCurrentPhase}");
            textBox5.AppendText($"{KZ.MaxCurrent},А");
            textBox6.AppendText($"{KZ.Amplitude},А");
            if (KZ.KZphaseA == 1)
                textBox7.Text = " Кз фазы А" + Environment.NewLine;
            if (KZ.KZphaseB == 1)
                textBox7.AppendText(" Кз фазы B" + Environment.NewLine);
            if (KZ.KZphaseC == 1)
                textBox7.AppendText(" Кз фазы C" + Environment.NewLine);
        }

        public void ComboFill(ComtradeReader comtradeReader)
        {


            var currentsDisplay1 = new List<string> { "" }; 
            currentsDisplay1.AddRange(comtradeReader.CurrentsNames.Select(name => $"{name}"));

            var currentsDisplay2 = new List<string>(currentsDisplay1); 
            var currentsDisplay3 = new List<string>(currentsDisplay1);

            var voltagesDisplay4 = new List<string> { "" }; 
            voltagesDisplay4.AddRange(comtradeReader.VoltagesNames.Select(name => $"{name}"));

            var voltagesDisplay5 = new List<string>(voltagesDisplay4); 
            var voltagesDisplay6 = new List<string>(voltagesDisplay4);

            
            comboBox1.DataSource = currentsDisplay1;
            comboBox2.DataSource = currentsDisplay2;
            comboBox3.DataSource = currentsDisplay3;

            comboBox4.DataSource = voltagesDisplay4;
            comboBox5.DataSource = voltagesDisplay5;
            comboBox6.DataSource = voltagesDisplay6;

            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

            
            comboBox1.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox1.SelectedIndex > 0) 
                    MessageBox.Show($"Выбран ток: {comboBox1.SelectedItem}");
            };

            comboBox2.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox2.SelectedIndex > 0)
                    MessageBox.Show($"Выбран ток: {comboBox2.SelectedItem}");
            };

            comboBox3.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox3.SelectedIndex > 0)
                    MessageBox.Show($"Выбран ток: {comboBox3.SelectedItem}");
            };

            comboBox4.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox4.SelectedIndex > 0)
                    MessageBox.Show($"Выбрано напряжение: {comboBox4.SelectedItem}");
            };

            comboBox5.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox5.SelectedIndex > 0)
                    MessageBox.Show($"Выбрано напряжение: {comboBox5.SelectedItem}");
            };

            comboBox6.SelectedIndexChanged += (s, e) =>
            {
                if (comboBox6.SelectedIndex > 0)
                    MessageBox.Show($"Выбрано напряжение: {comboBox6.SelectedItem}");
            };
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            PlotData1 PlotData1 = new PlotData1();
            SimSost SimSost = new SimSost();
            SimSost.SimS0st(comtradeReader, comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6);
            PlotData1.PlotSimSost(comtradeReader, SimSost, Forms0, Forms1, Forms2);
            foreach (string name in SimSost.Names)
            {
                listBox3.Items.Add(name);
            }


        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ListBox3_DoubleClick(object sender, EventArgs e)
        {
            
            if (listBox3.SelectedItem != null)
            {
                string selectedItem = listBox3.SelectedItem.ToString();

               
                if (!listBox4.Items.Contains(selectedItem))
                {
                    
                    listBox4.Items.Add(selectedItem);

                }
                else
                {
                    MessageBox.Show("Этот элемент уже есть в списке!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveData Save = new SaveData();
            Save.WriteComtrade(comtradeReader, listBox4);

        }

        
        private void ListBox4_DoubleClick(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex < 0 || listBox4.SelectedIndex >= channelData.Count)
                return;

            string signalName = listBox4.Items[listBox4.SelectedIndex].ToString();
            var signalI = comtradeReader.channelNames.IndexOf(signalName);
            var signalData = comtradeReader.Signals[signalI];

            
            if (plottedSignals.Contains(signalName))
            {
                MessageBox.Show($"Сигнал '{signalName}' уже добавлен на график");
                return;
            }

            
            PlotData1 PlotData1 = new PlotData1();
            PlotData1.PlotChosen(comtradeReader,signalName, signalData, OscPlot2);
            
            OscPlot2.Refresh();

            
            plottedSignals.Add(signalName);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            OscPlot1.Plot.Clear();
            OscPlot1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OscPlot2.Plot.Clear();
            OscPlot2.Refresh();
        }
        private void formsPlot1_Load_1(object sender, EventArgs e)
        {

        }
        private void openFileDialog_FileOk(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
