namespace Octopus.Forms
{
    partial class OctopusSettings
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
            this.octoPortLabel = new System.Windows.Forms.Label();
            this.octoAddressLabel = new System.Windows.Forms.Label();
            this.octoServPathLabel = new System.Windows.Forms.Label();
            this.octoPortTB = new System.Windows.Forms.TextBox();
            this.octoAddressTB = new System.Windows.Forms.TextBox();
            this.octoServPathTB = new System.Windows.Forms.TextBox();
            this.viewDBPathButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.octoServPathFD = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // octoPortLabel
            // 
            this.octoPortLabel.AutoSize = true;
            this.octoPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoPortLabel.Location = new System.Drawing.Point(12, 9);
            this.octoPortLabel.Name = "octoPortLabel";
            this.octoPortLabel.Size = new System.Drawing.Size(104, 18);
            this.octoPortLabel.TabIndex = 0;
            this.octoPortLabel.Text = "Порт Octopus";
            // 
            // octoAddressLabel
            // 
            this.octoAddressLabel.AutoSize = true;
            this.octoAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoAddressLabel.Location = new System.Drawing.Point(12, 39);
            this.octoAddressLabel.Name = "octoAddressLabel";
            this.octoAddressLabel.Size = new System.Drawing.Size(111, 18);
            this.octoAddressLabel.TabIndex = 2;
            this.octoAddressLabel.Text = "Адрес Octopus";
            // 
            // octoServPathLabel
            // 
            this.octoServPathLabel.AutoSize = true;
            this.octoServPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServPathLabel.Location = new System.Drawing.Point(12, 69);
            this.octoServPathLabel.Name = "octoServPathLabel";
            this.octoServPathLabel.Size = new System.Drawing.Size(120, 18);
            this.octoServPathLabel.TabIndex = 4;
            this.octoServPathLabel.Text = "Путь к OctoServ";
            // 
            // octoPortTB
            // 
            this.octoPortTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoPortTB.Location = new System.Drawing.Point(193, 6);
            this.octoPortTB.MaxLength = 4;
            this.octoPortTB.Name = "octoPortTB";
            this.octoPortTB.Size = new System.Drawing.Size(595, 24);
            this.octoPortTB.TabIndex = 6;
            this.octoPortTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.octoPortTB_KeyPress);
            // 
            // octoAddressTB
            // 
            this.octoAddressTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoAddressTB.Location = new System.Drawing.Point(193, 36);
            this.octoAddressTB.Name = "octoAddressTB";
            this.octoAddressTB.ReadOnly = true;
            this.octoAddressTB.Size = new System.Drawing.Size(595, 24);
            this.octoAddressTB.TabIndex = 8;
            this.octoAddressTB.Text = "127.0.0.1";
            // 
            // octoServPathTB
            // 
            this.octoServPathTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.octoServPathTB.Location = new System.Drawing.Point(193, 66);
            this.octoServPathTB.Name = "octoServPathTB";
            this.octoServPathTB.Size = new System.Drawing.Size(514, 24);
            this.octoServPathTB.TabIndex = 10;
            // 
            // viewDBPathButton
            // 
            this.viewDBPathButton.Location = new System.Drawing.Point(713, 66);
            this.viewDBPathButton.Name = "viewDBPathButton";
            this.viewDBPathButton.Size = new System.Drawing.Size(75, 24);
            this.viewDBPathButton.TabIndex = 12;
            this.viewDBPathButton.Text = "Обзор...";
            this.viewDBPathButton.UseVisualStyleBackColor = true;
            this.viewDBPathButton.Click += new System.EventHandler(this.viewDBPathButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(683, 98);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 24);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // octoServPathFD
            // 
            this.octoServPathFD.FileName = "openFileDialog1";
            // 
            // OctopusSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 133);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.viewDBPathButton);
            this.Controls.Add(this.octoServPathTB);
            this.Controls.Add(this.octoAddressTB);
            this.Controls.Add(this.octoPortTB);
            this.Controls.Add(this.octoServPathLabel);
            this.Controls.Add(this.octoAddressLabel);
            this.Controls.Add(this.octoPortLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OctopusSettings";
            this.ShowIcon = false;
            this.Text = "Octopus Настройки";
            this.Load += new System.EventHandler(this.OctopusSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label octoPortLabel;
        private System.Windows.Forms.Label octoAddressLabel;
        private System.Windows.Forms.Label octoServPathLabel;
        private System.Windows.Forms.TextBox octoPortTB;
        private System.Windows.Forms.TextBox octoAddressTB;
        private System.Windows.Forms.TextBox octoServPathTB;
        private System.Windows.Forms.Button viewDBPathButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog octoServPathFD;
    }
}