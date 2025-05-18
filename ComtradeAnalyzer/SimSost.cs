using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComtradeAnalyzer
{
    public class SimSost
    {
        
        public List<List<double>> SignalSim = new List<List<double>>();
        public List<List<double>> SimData = new List<List<double>>(); 
        private List<List<double>> Signal = new List<List<double>>();
        public string name;
        public List<string> Names = new List<string>();

        public void SimS0st(ComtradeReader comtradeReader,ComboBox comboBox1,ComboBox comboBox2,ComboBox comboBox3,ComboBox comboBox4, ComboBox comboBox5, ComboBox comboBox6)
        {
            int selectedCurrentIndex1 = comboBox1.SelectedIndex-1;
            int selectedCurrentIndex2 = comboBox2.SelectedIndex-1;
            int selectedCurrentIndex3 = comboBox3.SelectedIndex - 1;

            int selectedVoltageIndex1 = comboBox4.SelectedIndex - 1;
            int selectedVoltageIndex2 = comboBox5.SelectedIndex - 1;
            int selectedVoltageIndex3 = comboBox6.SelectedIndex - 1;
            int Index1;
            int Index2;
            int Index3;
            string Unit;

            if ((selectedCurrentIndex1 != -1 & selectedCurrentIndex2 != -1 & selectedCurrentIndex3 != -1) ||(selectedVoltageIndex1 != -1 & selectedVoltageIndex2 != -1 & selectedVoltageIndex3 != -1))
          {
                if (selectedVoltageIndex1 != -1 & selectedVoltageIndex2 != -1 & selectedVoltageIndex3 != -1)
                {
                    Signal = comtradeReader.Voltages;
                    Index1 = selectedVoltageIndex1;
                    Index2 = selectedVoltageIndex2;
                    Index3 = selectedVoltageIndex3;
                    name = "Напряжение";
                    Names.Add($"U1 ({comtradeReader.VoltagesNames[Index1]};{comtradeReader.VoltagesNames[Index2]};{comtradeReader.VoltagesNames[Index3]})");
                    Names.Add($"U2 ({comtradeReader.VoltagesNames[Index1]};{comtradeReader.VoltagesNames[Index2]};{comtradeReader.VoltagesNames[Index3]})");
                    Names.Add($"U0 ({comtradeReader.VoltagesNames[Index1]};{comtradeReader.VoltagesNames[Index2]};{comtradeReader.VoltagesNames[Index3]})");
                    Unit = "V";
                }
                else
                {
                    Signal = comtradeReader.Currents;
                    Index1 = selectedCurrentIndex1;
                    Index2 = selectedCurrentIndex2;
                    Index3 = selectedCurrentIndex3;
                    name = "Ток";
                    Names.Add($"I1 ({comtradeReader.CurrentsNames[Index1]};{comtradeReader.CurrentsNames[Index2]};{comtradeReader.CurrentsNames[Index3]})");
                    Names.Add($"I2 ({comtradeReader.CurrentsNames[Index1]};{comtradeReader.CurrentsNames[Index2]};{comtradeReader.CurrentsNames[Index3]})");
                    Names.Add($"I0 ({comtradeReader.CurrentsNames[Index1]};{comtradeReader.CurrentsNames[Index2]};{comtradeReader.CurrentsNames[Index3]})");
                    Unit = "A";
                }
            
            if (SignalSim.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    SignalSim.Add(new List<double>(comtradeReader.dots));
                    
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (SignalSim[i].Count != comtradeReader.dots)
                {
                        SignalSim[i] = new List<double>(new double[comtradeReader.dots]);
                }
                if (SignalSim[i].Count != comtradeReader.dots)
                {
                        SignalSim[i] = new List<double>(new double[comtradeReader.dots]);
                }
            }
            Complex a = Complex.Exp(new Complex(0, 120 * Math.PI / 180));
            Complex a2 = a * a;
            
            
                for (int j = 0; j < comtradeReader.dots; j++)
                {
                        SignalSim[0][j] = Complex.Abs((1.0 / 3) * (Signal[Index1][j] + a * Signal[Index2][j] + a2 * Signal[Index3][j]));
                    
                        SignalSim[1][j] = Complex.Abs((1.0 / 3) * (Signal[Index1][j] + a2 * Signal[Index2][j] + a * Signal[Index3][j]));
                    
                        SignalSim[2][j] = Complex.Abs((1.0 / 3) * (Signal[Index1][j] + Signal[Index2][j] + Signal[Index3][j]));
                    
                }
                for (int j = 0; j < 3; j++)
                {
                    comtradeReader.Signals.Add(SignalSim[j]);
                    comtradeReader.channelNames.Add(Names[j]);
                    comtradeReader.Units.Add(Unit);

                }
                
            
          }
          else
          {
           MessageBox.Show("Выберите все необходимые сигналы в ComboBox (нельзя оставлять пустые значения)");
                return;
          }

        }
    }
}
