using OctoLib.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus.Forms
{
    public partial class OctoServSettings : Form
    {
        public OctoServSettings()
        {
            InitializeComponent();
        }

        private void OctoServSettings_Load(object sender, EventArgs e)
        {
            var reply = NetHandler.Send("1");
            if(reply.replyType == ReplyType.Information)
            {
                var chunks = reply.replyMessage.Split('\n');
                if(chunks.Length == 3)
                {
                    octoServPortTB.Text = chunks[0].Split(' ')[1];
                    octoServDataPathTB.Text = chunks[2].Split(' ')[3];
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            NetHandler.Send("11 " + octoServPortTB.Text);
            NetHandler.Send("12 " + octoServDataPathTB.Text);
        }
    }
}
