namespace FTP_Client_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectedServerInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReadRadio = new System.Windows.Forms.RadioButton();
            this.ModesGroupBox = new System.Windows.Forms.GroupBox();
            this.AppendRadio = new System.Windows.Forms.RadioButton();
            this.WriteRadio = new System.Windows.Forms.RadioButton();
            this.InformationsGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ReadContentTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ContentInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilenameInput = new System.Windows.Forms.TextBox();
            this.LogsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ActionsOutput = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ErrorsOutput = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ModesGroupBox.SuspendLayout();
            this.InformationsGroupBox.SuspendLayout();
            this.LogsGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectedServerInput
            // 
            this.ConnectedServerInput.Location = new System.Drawing.Point(878, 12);
            this.ConnectedServerInput.Name = "ConnectedServerInput";
            this.ConnectedServerInput.Size = new System.Drawing.Size(234, 22);
            this.ConnectedServerInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(744, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connected server :";
            // 
            // ReadRadio
            // 
            this.ReadRadio.AutoSize = true;
            this.ReadRadio.Location = new System.Drawing.Point(15, 21);
            this.ReadRadio.Name = "ReadRadio";
            this.ReadRadio.Size = new System.Drawing.Size(63, 21);
            this.ReadRadio.TabIndex = 2;
            this.ReadRadio.TabStop = true;
            this.ReadRadio.Text = "Read";
            this.ReadRadio.UseVisualStyleBackColor = true;
            // 
            // ModesGroupBox
            // 
            this.ModesGroupBox.Controls.Add(this.AppendRadio);
            this.ModesGroupBox.Controls.Add(this.WriteRadio);
            this.ModesGroupBox.Controls.Add(this.ReadRadio);
            this.ModesGroupBox.Location = new System.Drawing.Point(747, 69);
            this.ModesGroupBox.Name = "ModesGroupBox";
            this.ModesGroupBox.Size = new System.Drawing.Size(372, 148);
            this.ModesGroupBox.TabIndex = 3;
            this.ModesGroupBox.TabStop = false;
            this.ModesGroupBox.Text = "Modes";
            // 
            // AppendRadio
            // 
            this.AppendRadio.AutoSize = true;
            this.AppendRadio.Location = new System.Drawing.Point(15, 75);
            this.AppendRadio.Name = "AppendRadio";
            this.AppendRadio.Size = new System.Drawing.Size(78, 21);
            this.AppendRadio.TabIndex = 4;
            this.AppendRadio.TabStop = true;
            this.AppendRadio.Text = "Append";
            this.AppendRadio.UseVisualStyleBackColor = true;
            // 
            // WriteRadio
            // 
            this.WriteRadio.AutoSize = true;
            this.WriteRadio.Location = new System.Drawing.Point(15, 48);
            this.WriteRadio.Name = "WriteRadio";
            this.WriteRadio.Size = new System.Drawing.Size(62, 21);
            this.WriteRadio.TabIndex = 3;
            this.WriteRadio.TabStop = true;
            this.WriteRadio.Text = "Write";
            this.WriteRadio.UseVisualStyleBackColor = true;
            // 
            // InformationsGroupBox
            // 
            this.InformationsGroupBox.Controls.Add(this.label4);
            this.InformationsGroupBox.Controls.Add(this.ReadContentTextBox);
            this.InformationsGroupBox.Controls.Add(this.SendButton);
            this.InformationsGroupBox.Controls.Add(this.label3);
            this.InformationsGroupBox.Controls.Add(this.ContentInput);
            this.InformationsGroupBox.Controls.Add(this.label2);
            this.InformationsGroupBox.Controls.Add(this.FilenameInput);
            this.InformationsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InformationsGroupBox.Name = "InformationsGroupBox";
            this.InformationsGroupBox.Size = new System.Drawing.Size(726, 224);
            this.InformationsGroupBox.TabIndex = 4;
            this.InformationsGroupBox.TabStop = false;
            this.InformationsGroupBox.Text = "Informations";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Read content";
            // 
            // ReadContentTextBox
            // 
            this.ReadContentTextBox.Location = new System.Drawing.Point(440, 60);
            this.ReadContentTextBox.Multiline = true;
            this.ReadContentTextBox.Name = "ReadContentTextBox";
            this.ReadContentTextBox.ReadOnly = true;
            this.ReadContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReadContentTextBox.Size = new System.Drawing.Size(280, 130);
            this.ReadContentTextBox.TabIndex = 9;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(334, 196);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(80, 25);
            this.SendButton.TabIndex = 6;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Content :";
            // 
            // ContentInput
            // 
            this.ContentInput.AcceptsReturn = true;
            this.ContentInput.AcceptsTab = true;
            this.ContentInput.Location = new System.Drawing.Point(89, 60);
            this.ContentInput.Multiline = true;
            this.ContentInput.Name = "ContentInput";
            this.ContentInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContentInput.Size = new System.Drawing.Size(325, 130);
            this.ContentInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filename : ";
            // 
            // FilenameInput
            // 
            this.FilenameInput.Location = new System.Drawing.Point(89, 32);
            this.FilenameInput.Name = "FilenameInput";
            this.FilenameInput.Size = new System.Drawing.Size(325, 22);
            this.FilenameInput.TabIndex = 5;
            // 
            // LogsGroupBox
            // 
            this.LogsGroupBox.Controls.Add(this.groupBox4);
            this.LogsGroupBox.Controls.Add(this.groupBox3);
            this.LogsGroupBox.Location = new System.Drawing.Point(12, 276);
            this.LogsGroupBox.Name = "LogsGroupBox";
            this.LogsGroupBox.Size = new System.Drawing.Size(1107, 219);
            this.LogsGroupBox.TabIndex = 5;
            this.LogsGroupBox.TabStop = false;
            this.LogsGroupBox.Text = "Logs";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ActionsOutput);
            this.groupBox4.Location = new System.Drawing.Point(15, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1073, 97);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actions";
            // 
            // ActionsOutput
            // 
            this.ActionsOutput.Location = new System.Drawing.Point(6, 18);
            this.ActionsOutput.Multiline = true;
            this.ActionsOutput.Name = "ActionsOutput";
            this.ActionsOutput.ReadOnly = true;
            this.ActionsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ActionsOutput.Size = new System.Drawing.Size(1061, 71);
            this.ActionsOutput.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ErrorsOutput);
            this.groupBox3.Location = new System.Drawing.Point(9, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1080, 76);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Errors";
            // 
            // ErrorsOutput
            // 
            this.ErrorsOutput.Location = new System.Drawing.Point(6, 20);
            this.ErrorsOutput.Multiline = true;
            this.ErrorsOutput.Name = "ErrorsOutput";
            this.ErrorsOutput.ReadOnly = true;
            this.ErrorsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrorsOutput.Size = new System.Drawing.Size(1068, 46);
            this.ErrorsOutput.TabIndex = 0;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(1019, 42);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(92, 27);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 507);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.LogsGroupBox);
            this.Controls.Add(this.InformationsGroupBox);
            this.Controls.Add(this.ModesGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectedServerInput);
            this.Name = "Form1";
            this.Text = "FTP_Client (GUI)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ModesGroupBox.ResumeLayout(false);
            this.ModesGroupBox.PerformLayout();
            this.InformationsGroupBox.ResumeLayout(false);
            this.InformationsGroupBox.PerformLayout();
            this.LogsGroupBox.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConnectedServerInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ReadRadio;
        private System.Windows.Forms.GroupBox ModesGroupBox;
        private System.Windows.Forms.RadioButton AppendRadio;
        private System.Windows.Forms.RadioButton WriteRadio;
        private System.Windows.Forms.GroupBox InformationsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FilenameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ContentInput;
        private System.Windows.Forms.GroupBox LogsGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ErrorsOutput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox ActionsOutput;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReadContentTextBox;
    }
}

