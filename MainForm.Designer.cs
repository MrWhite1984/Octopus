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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.workSpace.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.workSpace_dataBasesListPanel.SuspendLayout();
            this.workSpace_dataBasesListPanel_header.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.topBarMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // designPanel1
            // 
            this.designPanel1.BackColor = System.Drawing.Color.Aqua;
            this.designPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.designPanel1.Location = new System.Drawing.Point(0, 28);
            this.designPanel1.Name = "designPanel1";
            this.designPanel1.Size = new System.Drawing.Size(1664, 1);
            this.designPanel1.TabIndex = 1;
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.workSpace.Controls.Add(this.tabControl1);
            this.workSpace.Controls.Add(this.workSpace_dataBasesListPanel);
            this.workSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workSpace.Location = new System.Drawing.Point(0, 29);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(1664, 939);
            this.workSpace.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(290, 581);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1374, 358);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1366, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Controls.Add(DGVTable.CreateTable(new Dictionary<string, string>() { { "s", "d"}, { "q", "as"} }));
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1366, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1360, 324);
            this.textBox1.TabIndex = 0;
            // 
            // workSpace_dataBasesListPanel
            // 
            this.workSpace_dataBasesListPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.workSpace_dataBasesListPanel.Controls.Add(this.workSpace_dataBasesListPanel_designPanel);
            this.workSpace_dataBasesListPanel.Controls.Add(this.workSpace_dataBasesListPanel_header);
            this.workSpace_dataBasesListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.workSpace_dataBasesListPanel.Location = new System.Drawing.Point(0, 0);
            this.workSpace_dataBasesListPanel.Margin = new System.Windows.Forms.Padding(0);
            this.workSpace_dataBasesListPanel.Name = "workSpace_dataBasesListPanel";
            this.workSpace_dataBasesListPanel.Size = new System.Drawing.Size(290, 939);
            this.workSpace_dataBasesListPanel.TabIndex = 0;
            // 
            // workSpace_dataBasesListPanel_designPanel
            // 
            this.workSpace_dataBasesListPanel_designPanel.BackColor = System.Drawing.Color.Aqua;
            this.workSpace_dataBasesListPanel_designPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.workSpace_dataBasesListPanel_designPanel.Location = new System.Drawing.Point(0, 30);
            this.workSpace_dataBasesListPanel_designPanel.Name = "workSpace_dataBasesListPanel_designPanel";
            this.workSpace_dataBasesListPanel_designPanel.Size = new System.Drawing.Size(290, 1);
            this.workSpace_dataBasesListPanel_designPanel.TabIndex = 1;
            // 
            // workSpace_dataBasesListPanel_header
            // 
            this.workSpace_dataBasesListPanel_header.Controls.Add(this.comboBox1);
            this.workSpace_dataBasesListPanel_header.Controls.Add(this.workSpace_dataBasesListPanel_header_refreshButton);
            this.workSpace_dataBasesListPanel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.workSpace_dataBasesListPanel_header.Location = new System.Drawing.Point(0, 0);
            this.workSpace_dataBasesListPanel_header.Name = "workSpace_dataBasesListPanel_header";
            this.workSpace_dataBasesListPanel_header.Size = new System.Drawing.Size(290, 30);
            this.workSpace_dataBasesListPanel_header.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 9F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Выберите базу данных";
            // 
            // workSpace_dataBasesListPanel_header_refreshButton
            // 
            this.workSpace_dataBasesListPanel_header_refreshButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.workSpace_dataBasesListPanel_header_refreshButton.Location = new System.Drawing.Point(260, 0);
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
            this.fileToolStripMenuItem});
            this.topBarMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topBarMenuStrip.Name = "topBarMenuStrip";
            this.topBarMenuStrip.Size = new System.Drawing.Size(1664, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.createToolStripMenuItem.Text = "Создать...";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.openToolStripMenuItem.Text = "Открыть...";
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.workSpace_dataBasesListPanel.ResumeLayout(false);
            this.workSpace_dataBasesListPanel_header.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.topBarMenuStrip.ResumeLayout(false);
            this.topBarMenuStrip.PerformLayout();
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox1;
    }
}