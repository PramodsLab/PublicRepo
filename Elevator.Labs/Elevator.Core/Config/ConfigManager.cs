using System.IO;
using System.Xml.Serialization;

namespace Elevator.Core.Config
{
    /// <summary></summary>
    public static class ConfigManager
    {
        private static readonly object ElevatorsSyncRoot = new object();
        private static volatile ElevatorConfig _elevatorConfig;

        /// <summary>Gets the elevator configuration.</summary>
        /// <value>The elevator configuration.</value>
        public static ElevatorConfig ElevatorConfig
        {
            get
            {
                if (_elevatorConfig == null)
                {
                    lock (ElevatorsSyncRoot)
                    {
                        if (_elevatorConfig == null)
                        {
                            var configPath = "//Config//ElevatorConfig.xml";

                            if (!string.IsNullOrEmpty(configPath))
                            {
                                _elevatorConfig = GetConfig<ElevatorConfig>(configPath);
                            }
                        }
                    }
                }
                return _elevatorConfig;
            }
        }

        public static T GetConfig<T>(string configPath)
        {
            var serializer = new XmlSerializer(typeof(T));

            var path = GetPath(configPath);

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var config = serializer.Deserialize(fs);
                fs.Close();
                return (T)config;
            }
        }

        private static string GetPath(string configPath)
        {
            var filename = configPath;

            int indexOfTilt = configPath.IndexOf("~");
            if (indexOfTilt > -1)
            {
                filename = configPath.Remove(indexOfTilt, 1);
            }

            return System.AppDomain.CurrentDomain.BaseDirectory + "\\" + filename;
        }
    }
}