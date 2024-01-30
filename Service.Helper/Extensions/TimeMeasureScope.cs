
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace PIS.Data.DataLink.Generic
{
    /// <inheritdoc />
    /// <summary>
    /// 執行時間測量範圍(自動使用Stopwatch計時並寫Log)
    /// </summary>
    public class TimeMeasureScope : IDisposable
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly string _title;
        private readonly ILogger _logger;
        public static bool Disabled = false;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="title">範圍標題</param>
        public TimeMeasureScope(string title, ILogger logger)
        {
            if (Disabled) return;
            _logger = logger;
            _title = title;
            stopwatch.Start();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (Disabled) return;
            stopwatch.Stop();
            //TODO: 實務上可將效能數據寫入Log檔

            if (_logger == null)
            {
                //Task.Run(() => WriteToFile.Wrire($"{_title}|{stopwatch.ElapsedMilliseconds:n0}ms"));
                System.Diagnostics.Debug.WriteLine($"{_title} => {stopwatch.ElapsedMilliseconds:n0}ms");
            }
            else
            {
                //_logger.LogInformation($"{_title}||||{stopwatch.ElapsedMilliseconds:n0}ms");
                System.Diagnostics.Debug.WriteLine($"{_title}||||{stopwatch.ElapsedMilliseconds:n0}ms");
            }



        }
    }



    public static class WriteToFile
    {
        public static void WrireForTest(string value, string path = @"C:\Users\2970696\Desktop\loadTests\test.txt")
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(value);

                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(value);
                }
            }


        }
    }
}