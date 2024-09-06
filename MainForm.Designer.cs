using Octopus.Elements.Tables;
using Octopus.Tables.Elements;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Octopus
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.designPanel1 = new System.Windows.Forms.Panel();
            this.workSpace = new System.Windows.Forms.Panel();
            this.workSpaceTabControl_bottomPanel = new System.Windows.Forms.TabControl();
            this.tabControl_bottomPanel_tableTabPage = new System.Windows.Forms.TabPage();
            this.tabControl_bottomPanel_consoleTabPage = new System.Windows.Forms.TabPage();
            this.consoleTabPage_console = new System.Windows.Forms.TextBox();
            this.workSpace_dataBasesListPanel = new System.Windows.Forms.Panel();
            this.workSpace_dataBasesListPanel_designPanel = new System.Windows.Forms.Panel();
            this.workSpace_dataBasesListPanel_header = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.workSpace_dataBasesListPanel_header_refreshButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.topBarMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.Panel();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designPanel2 = new System.Windows.Forms.Panel();
            this.designPanel3 = new System.Windows.Forms.Panel();
            this.designPanel4 = new System.Windows.Forms.Panel();
            this.designPanel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.workSpace.SuspendLayout();
            this.workSpaceTabControl_bottomPanel.SuspendLayout();
            this.tabControl_bottomPanel_consoleTabPage.SuspendLayout();
            this.workSpace_dataBasesListPanel.SuspendLayout();
            this.workSpace_dataBasesListPanel_header.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.topBarMenuStrip.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // designPanel1
            // 
            this.designPanel1.BackColor = System.Drawing.Color.Aqua;
            this.designPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.designPanel1.Location = new System.Drawing.Point(0, 30);
            this.designPanel1.Name = "designPanel1";
            this.designPanel1.Size = new System.Drawing.Size(1664, 1);
            this.designPanel1.TabIndex = 1;
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.workSpace.Controls.Add(this.textBox1);
            this.workSpace.Controls.Add(this.designPanel5);
            this.workSpace.Controls.Add(this.toolBar);
            this.workSpace.Controls.Add(this.workSpaceTabControl_bottomPanel);
            this.workSpace.Controls.Add(this.workSpace_dataBasesListPanel);
            this.workSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpace.Location = new System.Drawing.Point(0, 31);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(1664, 937);
            this.workSpace.TabIndex = 2;
            // 
            // workSpaceTabControl_bottomPanel
            // 
            this.workSpaceTabControl_bottomPanel.Controls.Add(this.tabControl_bottomPanel_tableTabPage);
            this.workSpaceTabControl_bottomPanel.Controls.Add(this.tabControl_bottomPanel_consoleTabPage);
            this.workSpaceTabControl_bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.workSpaceTabControl_bottomPanel.Location = new System.Drawing.Point(220, 579);
            this.workSpaceTabControl_bottomPanel.Name = "workSpaceTabControl_bottomPanel";
            this.workSpaceTabControl_bottomPanel.SelectedIndex = 0;
            this.workSpaceTabControl_bottomPanel.Size = new System.Drawing.Size(1444, 358);
            this.workSpaceTabControl_bottomPanel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.workSpaceTabControl_bottomPanel.TabIndex = 1;
            // 
            // tabControl_bottomPanel_tableTabPage
            // 
            this.tabControl_bottomPanel_tableTabPage.Location = new System.Drawing.Point(4, 24);
            this.tabControl_bottomPanel_tableTabPage.Name = "tabControl_bottomPanel_tableTabPage";
            this.tabControl_bottomPanel_tableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl_bottomPanel_tableTabPage.Size = new System.Drawing.Size(1436, 330);
            this.tabControl_bottomPanel_tableTabPage.TabIndex = 0;
            this.tabControl_bottomPanel_tableTabPage.Text = "Таблица";
            this.tabControl_bottomPanel_tableTabPage.UseVisualStyleBackColor = true;
            this.tabControl_bottomPanel_tableTabPage.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabControl_bottomPanel_tableTabPage_Layout);
            // 
            // tabControl_bottomPanel_consoleTabPage
            // 
            this.tabControl_bottomPanel_consoleTabPage.Controls.Add(this.consoleTabPage_console);
            this.tabControl_bottomPanel_consoleTabPage.Location = new System.Drawing.Point(4, 24);
            this.tabControl_bottomPanel_consoleTabPage.Name = "tabControl_bottomPanel_consoleTabPage";
            this.tabControl_bottomPanel_consoleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl_bottomPanel_consoleTabPage.Size = new System.Drawing.Size(1366, 330);
            this.tabControl_bottomPanel_consoleTabPage.TabIndex = 1;
            this.tabControl_bottomPanel_consoleTabPage.Text = "Консоль";
            this.tabControl_bottomPanel_consoleTabPage.UseVisualStyleBackColor = true;
            // 
            // consoleTabPage_console
            // 
            this.consoleTabPage_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleTabPage_console.Location = new System.Drawing.Point(3, 3);
            this.consoleTabPage_console.Multiline = true;
            this.consoleTabPage_console.Name = "consoleTabPage_console";
            this.consoleTabPage_console.ReadOnly = true;
            this.consoleTabPage_console.Size = new System.Drawing.Size(1360, 324);
            this.consoleTabPage_console.TabIndex = 0;
            // 
            // workSpace_dataBasesListPanel
            // 
            this.workSpace_dataBasesListPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.workSpace_dataBasesListPanel.Controls.Add(this.designPanel2);
            this.workSpace_dataBasesListPanel.Controls.Add(this.workSpace_dataBasesListPanel_designPanel);
            this.workSpace_dataBasesListPanel.Controls.Add(this.workSpace_dataBasesListPanel_header);
            this.workSpace_dataBasesListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.workSpace_dataBasesListPanel.Location = new System.Drawing.Point(0, 0);
            this.workSpace_dataBasesListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.workSpace_dataBasesListPanel.Name = "workSpace_dataBasesListPanel";
            this.workSpace_dataBasesListPanel.Size = new System.Drawing.Size(220, 937);
            this.workSpace_dataBasesListPanel.TabIndex = 0;
            // 
            // workSpace_dataBasesListPanel_designPanel
            // 
            this.workSpace_dataBasesListPanel_designPanel.BackColor = System.Drawing.Color.Aqua;
            this.workSpace_dataBasesListPanel_designPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.workSpace_dataBasesListPanel_designPanel.Location = new System.Drawing.Point(0, 30);
            this.workSpace_dataBasesListPanel_designPanel.Name = "workSpace_dataBasesListPanel_designPanel";
            this.workSpace_dataBasesListPanel_designPanel.Size = new System.Drawing.Size(220, 1);
            this.workSpace_dataBasesListPanel_designPanel.TabIndex = 1;
            // 
            // workSpace_dataBasesListPanel_header
            // 
            this.workSpace_dataBasesListPanel_header.Controls.Add(this.comboBox1);
            this.workSpace_dataBasesListPanel_header.Controls.Add(this.workSpace_dataBasesListPanel_header_refreshButton);
            this.workSpace_dataBasesListPanel_header.Controls.Add(this.designPanel3);
            this.workSpace_dataBasesListPanel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.workSpace_dataBasesListPanel_header.Location = new System.Drawing.Point(0, 0);
            this.workSpace_dataBasesListPanel_header.Name = "workSpace_dataBasesListPanel_header";
            this.workSpace_dataBasesListPanel_header.Size = new System.Drawing.Size(220, 30);
            this.workSpace_dataBasesListPanel_header.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 9F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Выберите базу данных";
            // 
            // workSpace_dataBasesListPanel_header_refreshButton
            // 
            this.workSpace_dataBasesListPanel_header_refreshButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.workSpace_dataBasesListPanel_header_refreshButton.Location = new System.Drawing.Point(189, 0);
            this.workSpace_dataBasesListPanel_header_refreshButton.Name = "workSpace_dataBasesListPanel_header_refreshButton";
            this.workSpace_dataBasesListPanel_header_refreshButton.Size = new System.Drawing.Size(30, 30);
            this.workSpace_dataBasesListPanel_header_refreshButton.TabIndex = 1;
            this.workSpace_dataBasesListPanel_header_refreshButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.workSpace);
            this.mainPanel.Controls.Add(this.designPanel1);
            this.mainPanel.Controls.Add(this.topBarMenuStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1664, 968);
            this.mainPanel.TabIndex = 0;
            // 
            // topBarMenuStrip
            // 
            this.topBarMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.topBarMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topBarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.topBarMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topBarMenuStrip.Name = "topBarMenuStrip";
            this.topBarMenuStrip.Size = new System.Drawing.Size(1664, 30);
            this.topBarMenuStrip.TabIndex = 0;
            this.topBarMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.fileToolStripMenuItem.Text = "Файл";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createToolStripMenuItem.Text = "Создать...";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Открыть...";
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolBar.Controls.Add(this.designPanel4);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(220, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1444, 31);
            this.toolBar.TabIndex = 2;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(98, 26);
            this.settingsToolStripMenuItem.Text = "Настройки";
            // 
            // designPanel2
            // 
            this.designPanel2.BackColor = System.Drawing.Color.Aqua;
            this.designPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.designPanel2.Location = new System.Drawing.Point(219, 31);
            this.designPanel2.Name = "designPanel2";
            this.designPanel2.Size = new System.Drawing.Size(1, 906);
            this.designPanel2.TabIndex = 2;
            // 
            // designPanel3
            // 
            this.designPanel3.BackColor = System.Drawing.Color.Aqua;
            this.designPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.designPanel3.Location = new System.Drawing.Point(219, 0);
            this.designPanel3.Name = "designPanel3";
            this.designPanel3.Size = new System.Drawing.Size(1, 30);
            this.designPanel3.TabIndex = 3;
            // 
            // designPanel4
            // 
            this.designPanel4.BackColor = System.Drawing.Color.Aqua;
            this.designPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.designPanel4.Location = new System.Drawing.Point(0, 30);
            this.designPanel4.Name = "designPanel4";
            this.designPanel4.Size = new System.Drawing.Size(1444, 1);
            this.designPanel4.TabIndex = 3;
            // 
            // designPanel5
            // 
            this.designPanel5.BackColor = System.Drawing.Color.Aqua;
            this.designPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.designPanel5.Location = new System.Drawing.Point(220, 578);
            this.designPanel5.Name = "designPanel5";
            this.designPanel5.Size = new System.Drawing.Size(1444, 1);
            this.designPanel5.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(220, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1444, 547);
            this.textBox1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1664, 968);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Octopus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.workSpace.ResumeLayout(false);
            this.workSpace.PerformLayout();
            this.workSpaceTabControl_bottomPanel.ResumeLayout(false);
            this.tabControl_bottomPanel_consoleTabPage.ResumeLayout(false);
            this.tabControl_bottomPanel_consoleTabPage.PerformLayout();
            this.workSpace_dataBasesListPanel.ResumeLayout(false);
            this.workSpace_dataBasesListPanel_header.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.topBarMenuStrip.ResumeLayout(false);
            this.topBarMenuStrip.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel designPanel1;
        private System.Windows.Forms.Panel workSpace;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip topBarMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel workSpace_dataBasesListPanel;
        private System.Windows.Forms.Panel workSpace_dataBasesListPanel_header;
        private System.Windows.Forms.Button workSpace_dataBasesListPanel_header_refreshButton;
        private System.Windows.Forms.Panel workSpace_dataBasesListPanel_designPanel;
        private ComboBox comboBox1;
        private TabControl workSpaceTabControl_bottomPanel;
        private TabPage tabControl_bottomPanel_tableTabPage;
        private TabPage tabControl_bottomPanel_consoleTabPage;
        private TextBox consoleTabPage_console;
        private Panel toolBar;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Panel designPanel2;
        private Panel designPanel3;
        private Panel designPanel4;
        private Panel designPanel5;
        private TextBox textBox1;
    }
}