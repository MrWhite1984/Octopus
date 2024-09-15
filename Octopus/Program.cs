using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus
{
    internal static class Program
    {
        public static Configuration configuration;

        [STAThread]
        static void Main()
        {
            configuration = Configuration.GetConfiguration();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
