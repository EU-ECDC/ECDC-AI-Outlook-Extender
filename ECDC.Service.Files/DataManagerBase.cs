using System.IO;
using System.Text.Json;

namespace ECDC.Service.Files
{
    public class DataManagerBase<T> where T : class
    {

        private static T _data = null;
        internal readonly string _appDataPath;
        internal readonly string _filePath;

        public DataManagerBase(string file, string folder)
        {
            // Set up the application-specific directory within AppData
            // EXAMPLE: C:\Users\user\AppData\Roaming\ECDC-AIOX
            _appDataPath = folder;

            // Ensure the directory exists
            if (!Directory.Exists(_appDataPath))
            {
                Directory.CreateDirectory(_appDataPath);
            }

            // Set the full path for the metadata the file
            _filePath = Path.Combine(_appDataPath, file);
        }

        public virtual T Load()
        {
            try
            {
                if (_data == null)
                {
                    if (!File.Exists(_filePath))
                        return default;

                    //var file = new FileInfo(_filePath);
                    string json = File.ReadAllText(_filePath);
                    _data = JsonSerializer.Deserialize<T>(json);
                }
                return _data;
            }
            catch (System.Exception ex)
            {
                //todo: log
                throw ex;
            }

        }

        public virtual void Save(T data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
                _data = null;
            }
            catch (System.Exception ex)
            {
                //todo: log
                throw ex;
            }
        }
        
        public virtual string FilePath()
        { 
            return _filePath; 
        }
    }
}
