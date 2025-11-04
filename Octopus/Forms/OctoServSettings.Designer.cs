namespace Octopus.Forms
{
    partial class OctoServSettings
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
            this.saveButton = new System.Windows.Forms.Button();
            this.viewDBPathButton = new System.Windows.Forms.Button();
            this.octoServDataPathTB = new System.Windows.Forms.TextBox();
            this.octoServAddressTB = new System.Windows.Forms.TextBox();
            this.octoServPortTB = new System.Windows.Forms.TextBox();
            this.octoServDataPathLabel = new System.Windows.Forms.Label();
            this.octoServAddressLabel = new System.Windows.Forms.Label();
            this.octoServPortLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(683, 98);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 24);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // viewDBPathButton
            // 
            this.viewDBPathButton.Location = new System.Drawing.Point(713, 66);
            this.viewDBPathButton.Name = "viewDBPathButton";
            this.viewDBPathButton.Size = new System.Drawing.Size(75, 24);
            this.viewDBPathButton.TabIndex = 16;
            this.viewDBPathButton.Text = "Обзор...";
            this.viewDBPathButton.UseVisualStyleBackColor = true;
            // 
            // octoServDataPathTB
            // 
            this.octoServDataPathTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServDataPathTB.Location = new System.Drawing.Point(193, 66);
            this.octoServDataPathTB.Name = "octoServDataPathTB";
            this.octoServDataPathTB.Size = new System.Drawing.Size(514, 24);
            this.octoServDataPathTB.TabIndex = 17;
            // 
            // octoServAddressTB
            // 
            this.octoServAddressTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServAddressTB.Location = new System.Drawing.Point(193, 36);
            this.octoServAddressTB.Name = "octoServAddressTB";
            this.octoServAddressTB.ReadOnly = true;
            this.octoServAddressTB.Size = new System.Drawing.Size(595, 24);
            this.octoServAddressTB.TabIndex = 18;
            this.octoServAddressTB.Text = "127.0.0.1";
            // 
            // octoServPortTB
            // 
            this.octoServPortTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServPortTB.Location = new System.Drawing.Point(193, 6);
            this.octoServPortTB.MaxLength = 4;
            this.octoServPortTB.Name = "octoServPortTB";
            this.octoServPortTB.Size = new System.Drawing.Size(595, 24);
            this.octoServPortTB.TabIndex = 19;
            // 
            // octoServDataPathLabel
            // 
            this.octoServDataPathLabel.AutoSize = true;
            this.octoServDataPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServDataPathLabel.Location = new System.Drawing.Point(12, 69);
            this.octoServDataPathLabel.Name = "octoServDataPathLabel";
            this.octoServDataPathLabel.Size = new System.Drawing.Size(179, 18);
            this.octoServDataPathLabel.TabIndex = 20;
            this.octoServDataPathLabel.Text = "Путь к данным OctoServ";
            // 
            // octoServAddressLabel
            // 
            this.octoServAddressLabel.AutoSize = true;
            this.octoServAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServAddressLabel.Location = new System.Drawing.Point(12, 39);
            this.octoServAddressLabel.Name = "octoServAddressLabel";
            this.octoServAddressLabel.Size = new System.Drawing.Size(117, 18);
            this.octoServAddressLabel.TabIndex = 21;
            this.octoServAddressLabel.Text = "Адрес OctoServ";
            // 
            // octoServPortLabel
            // 
            this.octoServPortLabel.AutoSize = true;
            this.octoServPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServPortLabel.Location = new System.Drawing.Point(12, 9);
            this.octoServPortLabel.Name = "octoServPortLabel";
            this.octoServPortLabel.Size = new System.Drawing.Size(110, 18);
            this.octoServPortLabel.TabIndex = 22;
            this.octoServPortLabel.Text = "Порт OctoServ";
            // 
            // OctoServSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 133);
            this.Controls.Add(this.octoServPortLabel);
            this.Controls.Add(this.octoServAddressLabel);
            this.Controls.Add(this.octoServDataPathLabel);
            this.Controls.Add(this.octoServPortTB);
            this.Controls.Add(this.octoServAddressTB);
            this.Controls.Add(this.octoServDataPathTB);
            this.Controls.Add(this.viewDBPathButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OctoServSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "OctoServ Настройки";
            this.Load += new System.EventHandler(this.OctoServSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button viewDBPathButton;
        private System.Windows.Forms.TextBox octoServDataPathTB;
        private System.Windows.Forms.TextBox octoServAddressTB;
        private System.Windows.Forms.TextBox octoServPortTB;
        private System.Windows.Forms.Label octoServDataPathLabel;
        private System.Windows.Forms.Label octoServAddressLabel;
        private System.Windows.Forms.Label octoServPortLabel;
    }
}