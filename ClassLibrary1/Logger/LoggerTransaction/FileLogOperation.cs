using System;
using System.IO;

namespace Project.Business.Logger.LoggerTransaction {
    public class FileLogOperation : ILogger {
        public void WriteLog(string LogMessage) {
            var folder = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\LogData";
            var file = folder + "\\Log-" + DateTime.Now.ToShortDateString();
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(file)) {
                FileStream fs = File.Create(file);
                fs.Close();
            }
            using (var streamWriter = new StreamWriter(file, true)) {
                streamWriter.WriteLine(LogMessage);
                streamWriter.Close();
            }
        }
    }
}
