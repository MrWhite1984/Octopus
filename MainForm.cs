using Octopus.Elements.Buttons.Behavior;
using Octopus.Elements.Tables;
using Octopus.Elements.ToolStrip.ToolStripMenuItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemsBehavior.ToolStripMenuItemTextChangeColorOnClick(fileToolStripMenuItem);
        }

        private void tabControl_bottomPanel_tableTabPage_Layout(object sender, LayoutEventArgs e)
        {
            tabControl_bottomPanel_tableTabPage.Controls.Add(DGVTable.CreateTable(new Dictionary<string, string>()));
        }
    }
}
