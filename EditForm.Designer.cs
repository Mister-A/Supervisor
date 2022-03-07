namespace Supervisor
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MonitorsTab = new System.Windows.Forms.TabPage();
            this.listMonitors = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textEditName = new System.Windows.Forms.TextBox();
            this.textEditPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.browseExe = new System.Windows.Forms.OpenFileDialog();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblValidation = new System.Windows.Forms.Label();
            this.checkAlert = new System.Windows.Forms.CheckBox();
            this.columnAlert = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SMTPSettingsGroup = new System.Windows.Forms.GroupBox();
            this.textCheckInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkSendAlerts = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textSMTPServer = new System.Windows.Forms.TextBox();
            this.textSMTPUser = new System.Windows.Forms.TextBox();
            this.textSMTPPassword = new System.Windows.Forms.TextBox();
            this.textSMTPPort = new System.Windows.Forms.TextBox();
            this.textEmailTo = new System.Windows.Forms.TextBox();
            this.LabelEmailTo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.MonitorsTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SMTPSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MonitorsTab);
            this.tabControl1.Controls.Add(this.SettingsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 394);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // MonitorsTab
            // 
            this.MonitorsTab.Controls.Add(this.listMonitors);
            this.MonitorsTab.Location = new System.Drawing.Point(4, 22);
            this.MonitorsTab.Name = "MonitorsTab";
            this.MonitorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.MonitorsTab.Size = new System.Drawing.Size(618, 368);
            this.MonitorsTab.TabIndex = 0;
            this.MonitorsTab.Text = "Monitors";
            this.MonitorsTab.UseVisualStyleBackColor = true;
            // 
            // listMonitors
            // 
            this.listMonitors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnPath,
            this.columnAlert});
            this.listMonitors.Dock = System.Windows.Forms.DockStyle.Top;
            this.listMonitors.FullRowSelect = true;
            this.listMonitors.HideSelection = false;
            this.listMonitors.Location = new System.Drawing.Point(3, 3);
            this.listMonitors.Name = "listMonitors";
            this.listMonitors.Size = new System.Drawing.Size(612, 302);
            this.listMonitors.TabIndex = 0;
            this.listMonitors.UseCompatibleStateImageBehavior = false;
            this.listMonitors.View = System.Windows.Forms.View.Details;
            this.listMonitors.SelectedIndexChanged += new System.EventHandler(this.ListMonitors_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 150;
            // 
            // columnPath
            // 
            this.columnPath.Text = "Path";
            this.columnPath.Width = 400;
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(19, 412);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(145, 20);
            this.textEditName.TabIndex = 1;
            // 
            // textEditPath
            // 
            this.textEditPath.Location = new System.Drawing.Point(170, 412);
            this.textEditPath.Name = "textEditPath";
            this.textEditPath.Size = new System.Drawing.Size(374, 20);
            this.textEditPath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(550, 410);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(33, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // browseExe
            // 
            this.browseExe.Filter = "Applications (*.exe) | *.exe";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(19, 438);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(550, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(463, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(376, 439);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(550, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblValidation
            // 
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(106, 438);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(264, 23);
            this.lblValidation.TabIndex = 8;
            // 
            // checkAlert
            // 
            this.checkAlert.AutoSize = true;
            this.checkAlert.Location = new System.Drawing.Point(600, 414);
            this.checkAlert.Name = "checkAlert";
            this.checkAlert.Size = new System.Drawing.Size(15, 14);
            this.checkAlert.TabIndex = 9;
            this.checkAlert.UseVisualStyleBackColor = true;
            // 
            // columnAlert
            // 
            this.columnAlert.Text = "Alert";
            this.columnAlert.Width = 50;
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.SystemColors.Window;
            this.SettingsTab.Controls.Add(this.SMTPSettingsGroup);
            this.SettingsTab.Controls.Add(this.groupBox1);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(618, 368);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "General";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelEmailTo);
            this.groupBox1.Controls.Add(this.textEmailTo);
            this.groupBox1.Controls.Add(this.checkSendAlerts);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textCheckInterval);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitoring";
            // 
            // SMTPSettingsGroup
            // 
            this.SMTPSettingsGroup.Controls.Add(this.textSMTPPort);
            this.SMTPSettingsGroup.Controls.Add(this.textSMTPPassword);
            this.SMTPSettingsGroup.Controls.Add(this.textSMTPUser);
            this.SMTPSettingsGroup.Controls.Add(this.textSMTPServer);
            this.SMTPSettingsGroup.Controls.Add(this.label5);
            this.SMTPSettingsGroup.Controls.Add(this.label4);
            this.SMTPSettingsGroup.Controls.Add(this.label3);
            this.SMTPSettingsGroup.Controls.Add(this.label2);
            this.SMTPSettingsGroup.Enabled = false;
            this.SMTPSettingsGroup.Location = new System.Drawing.Point(6, 92);
            this.SMTPSettingsGroup.Name = "SMTPSettingsGroup";
            this.SMTPSettingsGroup.Size = new System.Drawing.Size(606, 108);
            this.SMTPSettingsGroup.TabIndex = 1;
            this.SMTPSettingsGroup.TabStop = false;
            this.SMTPSettingsGroup.Text = "Email";
            // 
            // textCheckInterval
            // 
            this.textCheckInterval.Location = new System.Drawing.Point(135, 19);
            this.textCheckInterval.Name = "textCheckInterval";
            this.textCheckInterval.Size = new System.Drawing.Size(100, 20);
            this.textCheckInterval.TabIndex = 0;
            this.textCheckInterval.TextChanged += new System.EventHandler(this.edited);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check every \'n\' seconds";
            // 
            // checkSendAlerts
            // 
            this.checkSendAlerts.AutoSize = true;
            this.checkSendAlerts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSendAlerts.Location = new System.Drawing.Point(6, 51);
            this.checkSendAlerts.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.checkSendAlerts.Name = "checkSendAlerts";
            this.checkSendAlerts.Size = new System.Drawing.Size(168, 17);
            this.checkSendAlerts.TabIndex = 1;
            this.checkSendAlerts.Text = "Send alerts if monitor restarted";
            this.checkSendAlerts.UseVisualStyleBackColor = true;
            this.checkSendAlerts.CheckedChanged += new System.EventHandler(this.checkSendAlerts_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SMTP Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SMTP User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "SMTP Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "SMTP Port";
            // 
            // textSMTPServer
            // 
            this.textSMTPServer.Location = new System.Drawing.Point(98, 22);
            this.textSMTPServer.Name = "textSMTPServer";
            this.textSMTPServer.Size = new System.Drawing.Size(192, 20);
            this.textSMTPServer.TabIndex = 3;
            this.textSMTPServer.TextChanged += new System.EventHandler(this.edited);
            // 
            // textSMTPUser
            // 
            this.textSMTPUser.Location = new System.Drawing.Point(98, 48);
            this.textSMTPUser.Name = "textSMTPUser";
            this.textSMTPUser.Size = new System.Drawing.Size(192, 20);
            this.textSMTPUser.TabIndex = 5;
            this.textSMTPUser.TextChanged += new System.EventHandler(this.edited);
            // 
            // textSMTPPassword
            // 
            this.textSMTPPassword.Location = new System.Drawing.Point(98, 74);
            this.textSMTPPassword.Name = "textSMTPPassword";
            this.textSMTPPassword.PasswordChar = '*';
            this.textSMTPPassword.Size = new System.Drawing.Size(192, 20);
            this.textSMTPPassword.TabIndex = 6;
            this.textSMTPPassword.TextChanged += new System.EventHandler(this.edited);
            // 
            // textSMTPPort
            // 
            this.textSMTPPort.Location = new System.Drawing.Point(379, 22);
            this.textSMTPPort.Name = "textSMTPPort";
            this.textSMTPPort.Size = new System.Drawing.Size(73, 20);
            this.textSMTPPort.TabIndex = 4;
            this.textSMTPPort.TextChanged += new System.EventHandler(this.edited);
            // 
            // textEmailTo
            // 
            this.textEmailTo.Enabled = false;
            this.textEmailTo.Location = new System.Drawing.Point(315, 49);
            this.textEmailTo.Name = "textEmailTo";
            this.textEmailTo.Size = new System.Drawing.Size(278, 20);
            this.textEmailTo.TabIndex = 2;
            this.textEmailTo.TextChanged += new System.EventHandler(this.edited);
            // 
            // LabelEmailTo
            // 
            this.LabelEmailTo.AutoSize = true;
            this.LabelEmailTo.Enabled = false;
            this.LabelEmailTo.Location = new System.Drawing.Point(215, 52);
            this.LabelEmailTo.Name = "LabelEmailTo";
            this.LabelEmailTo.Size = new System.Drawing.Size(95, 13);
            this.LabelEmailTo.TabIndex = 3;
            this.LabelEmailTo.Text = "Alert email address";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 509);
            this.Controls.Add(this.checkAlert);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textEditPath);
            this.Controls.Add(this.textEditName);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditForm";
            this.Text = "Edit Supervisor Settings";
            this.Load += new System.EventHandler(this.FrmMonitorList_Load);
            this.tabControl1.ResumeLayout(false);
            this.MonitorsTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SMTPSettingsGroup.ResumeLayout(false);
            this.SMTPSettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MonitorsTab;
        private System.Windows.Forms.ListView listMonitors;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.TextBox textEditName;
        private System.Windows.Forms.TextBox textEditPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog browseExe;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.CheckBox checkAlert;
        private System.Windows.Forms.ColumnHeader columnAlert;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.GroupBox SMTPSettingsGroup;
        private System.Windows.Forms.TextBox textSMTPPort;
        private System.Windows.Forms.TextBox textSMTPPassword;
        private System.Windows.Forms.TextBox textSMTPUser;
        private System.Windows.Forms.TextBox textSMTPServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSendAlerts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCheckInterval;
        private System.Windows.Forms.Label LabelEmailTo;
        private System.Windows.Forms.TextBox textEmailTo;
    }
}

