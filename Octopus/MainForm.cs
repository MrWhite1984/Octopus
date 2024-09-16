using OctoLib;
using OctoLib.DataTypes;
using Octopus.Elements.Buttons.Behavior;
using Octopus.Elements.Tables;
using Octopus.Elements.ToolStrip.ToolStripMenuItems;
using Octopus.Forms;
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
        }

        private void startOctoServButton_Click(object sender, EventArgs e)
        {
            if (Program.configuration.octoServPath == null)
            {
                var octoSettings = new OctopusSettings();
                octoSettings.ShowDialog();
            }
            else
            {
                var reply = NetHandler.StartServer();
                consoleTabPage_console.Text = reply.replyMessage;
                reply = NetHandler.Send("51");
                foreach (var chunk in reply.replyMessage.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dbSelector.Items.Add(chunk);
                }
                workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                startOctoServButton.Enabled = false;
                stopOctoServButton.Enabled = true;
            }
        }

        private void stopOctoServButton_Click(object sender, EventArgs e)
        {
            var reply = NetHandler.StopServer();
            dbSelector.Items.Clear();
            dbSelector.Text = "Выберите базу данных";
            workSpaceTabControl_bottomPanel.SelectedIndex = 1;
            consoleTabPage_console.Text = reply.replyMessage;
            startOctoServButton.Enabled = true;
            stopOctoServButton.Enabled = false;
        }

        private void sendRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (inputConsole_TextBox.Text != "" && NetHandler.octoServWork)
                {
                    int lineNumber = inputConsole_TextBox.GetLineFromCharIndex(inputConsole_TextBox.SelectionStart);
                    var chunks = inputConsole_TextBox.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lineNumber; i++)
                        lineNumber -= chunks[i].Length / 186;
                    string request = chunks[lineNumber];
                    var reply = NetHandler.Send(RequestCodeFormatter.FormatRequest(request));
                    if (reply.replyType == ReplyType.Success || reply.replyType == ReplyType.Information)
                    {
                        workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                        consoleTabPage_console.Text = TextHandler.FormatToTextBox(reply.replyMessage);
                    }
                    else if (reply.replyType == ReplyType.Error)
                    {
                        workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                        consoleTabPage_console.Text = TextHandler.FormatToTextBox(reply.replyMessage);
                    }
                    else if (reply.replyType == ReplyType.Data)
                    {
                        workSpaceTabControl_bottomPanel.SelectedIndex = 0;
                        tabControl_bottomPanel_tableTabPage.Controls.Clear();
                        tabControl_bottomPanel_tableTabPage.Controls.Add(DGVTable.CreateTable(reply.data));
                    }
                }
            }
            catch
            {
                workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                consoleTabPage_console.Text = "Ошибка выплнения запроса";
            }
        }

        private void dbSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            var reply = NetHandler.Send("3 " + dbSelector.Text.Remove(dbSelector.Text.Length - 5));
            if (reply.replyType == ReplyType.Success || reply.replyType == ReplyType.Information)
            {
                workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                consoleTabPage_console.Text = TextHandler.FormatToTextBox(reply.replyMessage);
            }
            else if (reply.replyType == ReplyType.Error)
            {
                workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                consoleTabPage_console.ForeColor = Color.Red;
                consoleTabPage_console.Text = TextHandler.FormatToTextBox(reply.replyMessage);
                consoleTabPage_console.ForeColor = Color.Black;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (NetHandler.octoServWork)
            {
                NetHandler.StopServer();
            }
        }

        private void octopusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form octoSettingsForm = new OctopusSettings();
            octoSettingsForm.ShowDialog();
        }

        private void workSpaceTabControl_bottomPanel_Layout(object sender, LayoutEventArgs e)
        {
            tabControl_bottomPanel_tableTabPage.Controls.Add(DGVTable.CreateTable(new Dictionary<string, string>()));
        }
    }
}
