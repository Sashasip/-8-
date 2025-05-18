using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Wisp.Comtrade;
using Wisp.Comtrade.Models;

namespace ComtradeAnalyzer
{
    public class ComtradeReader
    {
        private Wisp.Comtrade.RecordReader _comtradeData;
        private ConfigurationHandler configuration;
        private int _windowSizePeriods;
        private int _stepSizePeriods;
        public int _signalsCount;
        public double _nominalFrequency;
        public int dots;
        public double samplingFreq;
        public List<DateTime> TimeStampsOsc { get; private set; }

        public List<List<double>> Signals = new List<List<double>>();
        public List<string> OriginalCfgHeaderLines { get; private set; } = new List<string>();

        public List<string> channelNames = new List<string>();
        public List<string> VoltagesNames = new List<string>();
        public List<string> CurrentsNames = new List<string>();

        public List<string> Units = new List<string>();
        public List<List<double>> Currents = new List<List<double>>();
        public List<List<double>> Voltages = new List<List<double>>();
        public IReadOnlyList<double> TimeStamps;


        public ComtradeReader(string comtradeFilePath, int windowSizePeriods, int stepSizePeriods)
        {
            _windowSizePeriods = windowSizePeriods;
            _stepSizePeriods = stepSizePeriods;
            // Загрузка конфигурации из файла COMTRADE
            configuration = new ConfigurationHandler(comtradeFilePath);
            // Загрузка данных из файла COMTRADE
            _comtradeData = new RecordReader(comtradeFilePath);
            samplingFreq = _comtradeData.Configuration.SampleRates[0].SamplingFrequency;
            // Получение частоты дискретизации из файла
            _nominalFrequency = configuration.Frequency;
            _signalsCount = configuration.AnalogChannelsCount;
            OriginalCfgHeaderLines = File.ReadAllLines(comtradeFilePath).ToList();
            TimeStamps = _comtradeData.GetTimeLine();
            ClearResults();
            Data();
            Lists();
        }
        public void Data()
        {
            ClearResults();
            List<double>[] allData = new List<double>[_signalsCount];
            this.Units = configuration.AnalogChannelInformationList.Select(ch => ch.Units).ToList();
            this.channelNames = configuration.AnalogChannelInformationList.Select(ch => ch.Name).ToList();
            for (int i = 0; i < _signalsCount; i++)
            {
                allData[i] = _comtradeData.GetAnalogPrimaryChannel(i).ToList();
                dots = allData[i].Count;
                Signals.Add(allData[i]);
                
                
                
            }
            TimeStampsOsc = new List<DateTime>();
            for (int i = 0; i < dots; i++)
            {
                DateTime timeStamp = _comtradeData.Configuration.StartTime.AddSeconds(i / samplingFreq);
                TimeStampsOsc.Add(timeStamp);
            }
        }
        public void Lists()
        {
            Currents.Clear();
            Voltages.Clear();

           
            for (int i = 0; i < _signalsCount; i++)
            {
                if (Units[i].Contains("А") || Units[i].Contains("A"))
                {
                    Currents.Add(Signals[i]);
                    CurrentsNames.Add($"{channelNames[i]} ({Units[i]})");
                }
                if (Units[i].Contains("V") || Units[i].Contains("v"))
                {
                    Voltages.Add(Signals[i]);
                    VoltagesNames.Add($"{channelNames[i]} ({Units[i]})");
                }
            }
        }
        private void ClearResults()
        {
            Signals.Clear();
        }

    }
}


