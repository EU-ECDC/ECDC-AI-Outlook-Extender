using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text.Json;

namespace ECDC.Service.Files
{
    public class LoggerDataManager: DataManagerBase<Exception>
    {
        private const string eventSource = "Outlook";
        public LoggerDataManager() : base(
            "logger.json",
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ECDC-AIOX"))
        {
        }

        public override void Save(Exception ex)
        {
            try
            {
                var json = ToJson(ex);
                File.AppendAllText(_filePath, json + "," + Environment.NewLine);
            }
            catch { /* Fail silently */ }

            try
            {
                var json = ToJson(ex);
                if (EventLog.SourceExists(eventSource))
                {
                    EventLog.WriteEntry(eventSource, json, EventLogEntryType.Error);
                }
            }
            catch { /* Fail silently */ }
        }

        public string Load(Exception ex)
        { 
            return ToJson(ex);
        }

        private string ToJson(Exception ex)
        {
            var error = new
            {
                Time = DateTime.Now,
                Type = ex.GetType().FullName,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source,
                InnerException = ex.InnerException != null ? ToJson(ex.InnerException) : null
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(error, options);
        }

    }
}
