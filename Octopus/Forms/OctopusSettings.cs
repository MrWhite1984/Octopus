using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus.Forms
{
    public partial class OctopusSettings : Form
    {
        public OctopusSettings()
        {
            InitializeComponent();
        }

        private void OctopusSettings_Load(object sender, EventArgs e)
        {
            octoPortTB.Text = Program.configuration.port.ToString();
            octoServPathTB.Text = Program.configuration.octoServPath;
        }

        private void viewDBPathButton_Click(object sender, EventArgs e)
        {
            octoServPathFD.ShowDialog();
            if (octoServPathFD.FileName.Split('\\').Last() == "OctopusServ.exe")
                octoServPathTB.Text = octoServPathFD.FileName;
            else
                MessageBox.Show(octoServPathFD.FileName);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string configJson = "";
            if (octoPortTB.Text != "" && octoAddressTB.Text != "" && octoServPathTB.Text != "")
            {
                Program.configuration.port = Convert.ToInt32(octoPortTB.Text);
                Program.configuration.octoServPath = octoServPathTB.Text;
                configJson = Configuration.SetConfiguration(Program.configuration);
                File.WriteAllText("OctoConfig.json", configJson);
                Program.configuration = Configuration.GetConfiguration();
                this.Close();
            }
        }

        private void octoPortTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            var keyChar = e.KeyChar;
            if(!Char.IsDigit(keyChar))
                e.Handled = true;
        }
    }
}
