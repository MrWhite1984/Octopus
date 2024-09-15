
namespace OctoServ
{
    class Program
    {
        public static Configuration configuration;

        static void Main(string[] args)
        {
            configuration = Configuration.GetConfiguration();
            CheckAndCreateOctopusFolder();
            Listener listener = new Listener();
            listener.StartListener();
            TextFormatter.WriteLineGreen(TextFormatter.FormatTextAsLog("OctoServ запущен"));
            ConsoleWorker.octoServWork = true;
            ConsoleWorker.Work();
        }

        static void CheckAndCreateOctopusFolder()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (!Directory.Exists(path + "\\Octopus"))
            {
                Directory.CreateDirectory(Path.Combine(path, "Octopus"));
            }
        }

        public static void Restart()
        {
            Main(null);
        }
    }
}