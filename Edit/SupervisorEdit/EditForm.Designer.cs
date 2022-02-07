namespace SupervisorEdit
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MonitorsTab = new System.Windows.Forms.TabPage();
            this.listMonitors = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SettingsTab = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.MonitorsTab.SuspendLayout();
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
            this.columnPath});
            this.listMonitors.Dock = System.Windows.Forms.DockStyle.Top;
            this.listMonitors.FullRowSelect = true;
            this.listMonitors.HideSelection = false;
            this.listMonitors.Location = new System.Drawing.Point(3, 3);
            this.listMonitors.Name = "listMonitors";
            this.listMonitors.Size = new System.Drawing.Size(612, 302);
            this.listMonitors.TabIndex = 0;
            this.listMonitors.UseCompatibleStateImageBehavior = false;
            this.listMonitors.View = System.Windows.Forms.View.Details;
            this.listMonitors.SelectedIndexChanged += new System.EventHandler(this.listMonitors_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 150;
            // 
            // columnPath
            // 
            this.columnPath.Text = "Path";
            this.columnPath.Width = 450;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(618, 368);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "General";
            this.SettingsTab.UseVisualStyleBackColor = true;
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
            this.textEditPath.Size = new System.Drawing.Size(425, 20);
            this.textEditPath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(598, 410);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(33, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
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
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(550, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(463, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(376, 439);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(550, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblValidation
            // 
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(106, 438);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(264, 23);
            this.lblValidation.TabIndex = 8;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 509);
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
            this.Name = "EditForm";
            this.Text = "Edit Supervisor Settings";
            this.Load += new System.EventHandler(this.frmMonitorList_Load);
            this.tabControl1.ResumeLayout(false);
            this.MonitorsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MonitorsTab;
        private System.Windows.Forms.TabPage SettingsTab;
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
    }
}

