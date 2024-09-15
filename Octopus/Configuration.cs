using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Octopus
{
    class Configuration
    {
        public int port { get; set; }
        public int servPort { get; set; }
        public string address { get; set; }
        public string octoServPath { get; set; }
        public string octopusFilesPath { get; set; }

        public static Configuration GetConfiguration()
        {
            CheckConfigurationFile();
            return JsonSerializer.Deserialize<Configuration>(File.ReadAllText("OctoConfig.json"));
        }
        public static string SetConfiguration(Configuration configuration)
        {
            return JsonSerializer.Serialize(configuration);
        }
        static void CheckConfigurationFile()
        {
            if (!File.Exists("OctoConfig.json"))
            {
                Configuration configuration = new Configuration();
                configuration.port = 1111;
                configuration.servPort = 1111;
                configuration.address = "127.0.0.1";
                configuration.octopusFilesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Octopus");
                File.Create("OctoConfig.json").Close();
                File.WriteAllText("OctoConfig.json", SetConfiguration(configuration));
            }
        }
    }
}
