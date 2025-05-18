using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisp.Comtrade.Models;
using Wisp.Comtrade;

namespace ComtradeAnalyzer
{
    public class ShortCircuit
    {
        private List<List<double>> Currents = new List<List<double>>();
        public double MaxCurrent { get; private set; }
        public DateTime tkz { get; private set; }
        public int t { get; private set; }
        public int KZphaseA { get; private set; }
        public int KZphaseB { get; private set; }
        public int KZphaseC { get; private set; }
        public double Amplitude { get; private set; }
        public string MaxCurrentPhase;
        private int phase;

        public void Analyze(ComtradeReader comtradeReader)
        {
            Currents.Clear();

            for (int i = 0; i < comtradeReader._signalsCount; i++)
            {
                if (comtradeReader.Units[i].Contains("А") || comtradeReader.Units[i].Contains("A"))
                {
                    Currents.Add(comtradeReader.Signals[i]);
                }
            }

            
            MaxCurrent = 0;
            t = 0;
            phase = 0;

            for (int i = 0; i < Currents.Count; i++)
            {
                for (int j = 0; j < comtradeReader.dots; j++)
                {
                    if (Currents[i][j] > MaxCurrent)
                    {
                        MaxCurrent = Currents[i][j];
                        t++;
                        phase = i;
                    }
                }
            }
            MaxCurrent = Math.Round(MaxCurrent);
            for (int i = 0; i < Currents.Count; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    if (Math.Abs(Currents[i][j]) < Math.Abs(Currents[i][j + 1]) & Math.Abs(Currents[i][j + 1]) > Math.Abs(Currents[i][j + 2]))
                    {
                        Amplitude = Math.Abs(Currents[i][j + 1]);
                    }
                }
            }
            Amplitude = Math.Round(Amplitude);
            MaxCurrentPhase = comtradeReader.CurrentsNames[phase];
            for (int i = 0; i < Currents.Count; i++)
            {
                for (int j = 0; j < comtradeReader.dots; j++)
                {

                    if (Math.Abs(Currents[i][j]) > Amplitude * 1.3)
                    {
                        if (i == 0 || i == 3)
                            KZphaseA = 1;
                        if (i == 1 || i == 4)
                            KZphaseB = 1;
                        if (i == 2 || i == 5)
                            KZphaseC = 1;

                    }

                }

            }

        }
    }
}

