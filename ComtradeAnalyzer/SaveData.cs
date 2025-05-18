using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wisp.Comtrade.Models;

namespace ComtradeAnalyzer
{
    public class SaveData
    {
        public void WriteComtrade(ComtradeReader comtradeReader, ListBox listBox4)
        {
            if (listBox4.Items.Count == 0)
            {
                MessageBox.Show("Нет выбранных сигналов для сохранения");
                return;
            }


            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "COMTRADE файлы (*.cfg)|*.cfg|Все файлы (*.*)|*.*",
                Title = "Сохранить сигналы в формате COMTRADE",
                DefaultExt = "cfg",
                FileName = "SavedSignals.cfg"
            };


            if (saveDialog.ShowDialog() == DialogResult.OK)
            {

                // Создаем заголовочный файл COMTRADE (.cfg)
                string cfgFilePath = saveDialog.FileName;
                string datFilePath = Path.ChangeExtension(cfgFilePath, "dat");
                // 1. Создаем CFG файл (конфигурация)
                var cfg = new StringBuilder();

                // Заголовок
                cfg.AppendLine($"Расчетный файл,RECORDER_01");


                // Количество каналов
                cfg.AppendLine($"{listBox4.Items.Count},{listBox4.Items.Count}A,0D");

                // Описание аналоговых каналов
                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    string signalName = listBox4.Items[i].ToString();
                    int Index = comtradeReader.channelNames.IndexOf(signalName);
                    var s = comtradeReader.Signals[Index];
                    cfg.AppendLine($"{i + 1},{comtradeReader.channelNames[Index]} , , ,{comtradeReader.Units[Index]}," +
             $"1.0,0.0,0.0,0,32767,1.0,1.0,p");
                }


                cfg.AppendLine($"{comtradeReader._nominalFrequency}");
                // Настройки дискретизации
                cfg.AppendLine("1");
                cfg.AppendLine($"{comtradeReader.samplingFreq:0.#####},{comtradeReader.dots}");

                // Временная метка начала записи

                cfg.AppendLine($"{DateTime.Now:dd/MM/yyyy,HH:mm:ss.ffffff}");
                cfg.AppendLine($"{DateTime.Now:dd/MM/yyyy,HH:mm:ss.ffffff}");
                cfg.AppendLine("ASCII"); // Используем стандарт COMTRADE 2013
                cfg.AppendLine("1.396984e-10"); // Используем стандарт COMTRADE 2013


                File.WriteAllText(cfgFilePath, cfg.ToString());

                // 2. Создаем DAT файл (данные)

                using (var writer = new StreamWriter(datFilePath))
                {
                    var signalIndexes = new List<int>();
                    foreach (var item in listBox4.Items)
                    {
                        string signalName = item.ToString();
                        int index = comtradeReader.channelNames.IndexOf(signalName);
                        if (index >= 0) signalIndexes.Add(index);
                    }

                    // Запись данных
                    for (int i = 0; i < comtradeReader.dots; i++)
                    {
                        DateTime startTime = comtradeReader.TimeStampsOsc[0];

                        // 2. Запись данных с временными метками

                        // Вычисляем разницу в микросекундах относительно начала
                        TimeSpan timeDiff = comtradeReader.TimeStampsOsc[i] - startTime;
                        double microseconds = timeDiff.TotalMilliseconds * 1000;

                        // Записываем номер точки и время в микросекундах
                        writer.Write($"{i + 1},{comtradeReader.TimeStamps[i]},");
                        for (int ch = 0; ch < signalIndexes.Count; ch++)
                        {
                            int dataIndex = signalIndexes[ch];
                            writer.Write(Math.Round(comtradeReader.Signals[dataIndex][i]));

                            if (ch < signalIndexes.Count - 1)
                                writer.Write(",");

                            
                        }
                        writer.WriteLine();
                    }
                }





            }
        }




    }
}


