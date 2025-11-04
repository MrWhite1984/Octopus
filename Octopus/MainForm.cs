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
                if(reply.replyType == ReplyType.Success)
                {
                    consoleTabPage_console.Text = reply.replyMessage;
                    reply = NetHandler.Send("51");
                    foreach (var chunk in reply.replyMessage.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        dbSelector.Items.Add(chunk);
                    }
                    workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                    startOctoServButton.Visible = false;
                    stopOctoServButton.Visible = true;
                    sendRequestButton.Enabled = true;
                    workSpace_dataBasesListPanel_header_refreshButton.Enabled = true;
                    octoServToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void stopOctoServButton_Click(object sender, EventArgs e)
        {
            var reply = NetHandler.StopServer();
            if(reply.replyType == ReplyType.Success)
            {
                dbSelector.Items.Clear();
                dbSelector.Text = "Выберите базу данных";
                workSpaceTabControl_bottomPanel.SelectedIndex = 1;
                consoleTabPage_console.Text = reply.replyMessage;
                startOctoServButton.Visible = true;
                stopOctoServButton.Visible = false;
                sendRequestButton.Enabled = false;
                workSpace_dataBasesListPanel_header_refreshButton.Enabled = false;
                octoServToolStripMenuItem.Enabled = false;
            }
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
                    request = RequestCodeFormatter.FormatRequest(request);
                    if(request != "")
                    {
                        var reply = NetHandler.Send(request);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Prompter.SetToolTip(startOctoServButton, Properties.Resources.PrompterStartBtnText);
            Prompter.SetToolTip(stopOctoServButton, Properties.Resources.PrompterStopBtnText);
            Prompter.SetToolTip(sendRequestButton, Properties.Resources.PrompterExecBtnText);
            Prompter.SetToolTip(workSpace_dataBasesListPanel_header_refreshButton, Properties.Resources.PrompterRefreshDBBtnText);
        }

        private void octoServToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form octoServSettingsForm = new OctoServSettings();
            octoServSettingsForm.ShowDialog();
        }
    }
}
