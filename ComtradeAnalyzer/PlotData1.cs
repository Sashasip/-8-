using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ComtradeAnalyzer
{
    public class PlotData1
    {
        
        public Form1 form1;

        
        public List<List<double>> SignalsOsc = new List<List<double>>();


        public void PlotData(ComtradeReader comtradeReader, TabControl tabcontrol1)
        {
           
            if (comtradeReader?.Signals == null || comtradeReader.TimeStampsOsc == null || comtradeReader._signalsCount == 0)
            {
                MessageBox.Show("Ошибка: данные не загружены или повреждены");
                return;
            }

            
            SignalsOsc = new List<List<double>>();
            for (int i = 0; i < comtradeReader._signalsCount; i++)
            {
                SignalsOsc.Add(new List<double>(comtradeReader.Signals[i])); 
            }

            
            double[] timeSeconds = new double[comtradeReader.dots];
            DateTime startTime = comtradeReader.TimeStampsOsc[0];
            for (int i = 0; i < comtradeReader.dots; i++)
            {
                timeSeconds[i] = (comtradeReader.TimeStampsOsc[i] - startTime).TotalSeconds;
            }

            
            for (int i = 0; i < comtradeReader._signalsCount / 3; i++)
            {
                var tabPage = new TabPage($"Объект {i + 1}");
                var formPlot = new FormsPlot()
                {
                    Dock = DockStyle.Fill,

                    MinimumSize = new Size(1000, 600)
                };

               
                var pha = formPlot.Plot.Add.SignalXY(timeSeconds, SignalsOsc[3 * i]);
                pha.LegendText = $"{comtradeReader.channelNames[3 * i]},({comtradeReader.Units[3 * i]})";

                var phb = formPlot.Plot.Add.SignalXY(timeSeconds, SignalsOsc[3 * i + 1]);
                phb.LegendText = $"{comtradeReader.channelNames[3 * i + 1]},({comtradeReader.Units[3 * i + 1]})";


                var phc = formPlot.Plot.Add.SignalXY(timeSeconds, SignalsOsc[3 * i + 2]);
                phc.LegendText = $"{comtradeReader.channelNames[3 * i + 2]},({comtradeReader.Units[3 * i + 2]})";


                tabPage.Controls.Add(formPlot);
                tabcontrol1.TabPages.Add(tabPage);


                formPlot.Plot.Axes.AutoScale();
                formPlot.Plot.ShowLegend(Edge.Right);
                formPlot.Plot.XLabel("Время, t (с)");
                formPlot.Plot.YLabel($"{comtradeReader.Units[3 * i]}");
                formPlot.Refresh();
            }
        }
            public void PlotSimSost(ComtradeReader comtradeReader, SimSost simSost  ,FormsPlot Forms0, FormsPlot Forms1, FormsPlot Forms2)
            {
            
            double[] timeSeconds = new double[comtradeReader.dots];
            DateTime startTime = comtradeReader.TimeStampsOsc[0];
            for (int i = 0; i < comtradeReader.dots; i++)
            {
                timeSeconds[i] = (comtradeReader.TimeStampsOsc[i] - startTime).TotalSeconds;
            }

          
            var IV1 = Forms1.Plot.Add.SignalXY(timeSeconds,  simSost.SignalSim[0]);
            IV1.LegendText = $"{simSost.name} прямой последовательности";
            var IV2 = Forms2.Plot.Add.SignalXY(timeSeconds, simSost.SignalSim[1]);
            IV2.LegendText = $"{simSost.name} обратной последовательности";
            var IV0 = Forms0.Plot.Add.SignalXY(timeSeconds, simSost.SignalSim[2]);
            IV0.LegendText = $"{simSost.name} нулевой последовательности";



            Forms1.Plot.Axes.AutoScale();
            Forms2.Plot.Axes.AutoScale();
            Forms0.Plot.Axes.AutoScale();
            Forms1.Refresh();
            Forms2.Refresh();
            Forms0.Refresh();
            }
        public void PlotChosen(ComtradeReader comtradeReader,string name, List<double> data, FormsPlot OscPlot)
        {

            double[] timeSeconds = new double[comtradeReader.dots];
            DateTime startTime = comtradeReader.TimeStampsOsc[0];
            for (int i = 0; i < comtradeReader.dots; i++)
            {
                timeSeconds[i] = (comtradeReader.TimeStampsOsc[i] - startTime).TotalSeconds;
            }


            var sp = OscPlot.Plot.Add.SignalXY(timeSeconds, data);
            sp.LegendText = $"{name}";

            OscPlot.Plot.Axes.AutoScale();
        }


    }




    
}