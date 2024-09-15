using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OctoServ
{
    class Configuration
    {
        public int port {  get; set; }
        public string address { get; set; }
        public string octopusFilesPath { get; set; }

        public static Configuration GetConfiguration()
        {
            CheckConfigurationFile();
            return JsonSerializer.Deserialize<Configuration>(File.ReadAllText("OctoServConfig.json"));
        }
        public static string SetConfiguration(Configuration configuration)
        {
            return JsonSerializer.Serialize(configuration);
        }
        static void CheckConfigurationFile()
        {
            if (!File.Exists("OctoServConfig.json"))
            {
                Configuration configuration = new Configuration();
                configuration.port = 1111;
                configuration.address = "127.0.0.1";
                configuration.octopusFilesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Octopus");
                File.Create("OctoServConfig.json").Close();
                File.WriteAllText("OctoServConfig.json", SetConfiguration(configuration));
            }
        }

        public override string ToString()
        {
            return $"Порт: {port}\nАдрес: {address}\nРасположение баз данных: {octopusFilesPath}";
        }
    }
}
