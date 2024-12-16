using System;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Supervisor;

namespace Supervisor
{
    /// <summary>
    /// View, edit and add application monitors and set general preferences
    /// </summary>
    public partial class EditForm : Form
    {
        private MonitorSettings settings = new MonitorSettings();
        private DialogResult result;
        private int editIndex = new int();
        private string originalName = "";
        private bool changed = false;

        public EditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Init the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMonitorList_Load(object sender, EventArgs e)
        {
            //Init default UI state
            Edit(false);
            UpdateList();
            LoadSettings();
        }

        /// <summary>
        /// Load general settings for UI
        /// </summary>
        private void LoadSettings()
        {
            textCheckInterval.Text = settings.FindSettingFromName("CheckPeriod").Value;
            checkSendAlerts.Checked = (settings.FindSettingFromName("AlertEnabled").Value == "1") ? true : false;
            textSMTPServer.Text = settings.FindSettingFromName("SMTPServer").Value;
            textSMTPPort.Text = settings.FindSettingFromName("SMTPPort").Value;
            textSMTPUser.Text = settings.FindSettingFromName("SMTPUser").Value;
            textEmailTo.Text = settings.FindSettingFromName("EmailTo").Value;
            textSMTPPassword.Text = "**********";
            //reset the changed flag so populating UI isn't seen as an edit event
            changed = false;
        }

        /// <summary>
        /// Check for valid edit fields, return true if all ok, false if one or more empty or fail regex
        /// </summary>
        /// <returns></returns>
        private bool FieldsAreValid()
        {
            //Clear previous validation warnings
            lblValidation.Text = "";
            textEditName.BackColor = System.Drawing.SystemColors.Window;
            textEditPath.BackColor = System.Drawing.SystemColors.Window;

            //Check for emtpy
            if (textEditName.Text == "" || textEditPath.Text == "")
            {
                lblValidation.Text = "All fields must be completed";
                string message = "You must complete all fields.";
                string caption = "Not saved!";

                using (new CenterWinDialog(this))
                {
                    result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                }
                return false;
            }

            //Path can only be .... a path
            if (textEditPath.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1)
            {
                lblValidation.Text = "Path must be a valid local path with executeable.";
                textEditPath.BackColor = System.Drawing.Color.Tomato;
                string message = "Your application path doesn't look right, please use the \"...\" button to browse for a valid executeable.";
                string caption = "Not saved!";

                using (new CenterWinDialog(this))
                {
                    result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                }
                return false;
            }

            //Check name and path fields are unique
            foreach (MonitorGroup.ApplicationElement monitor in settings.MonitorGroup.Monitors)
            {
                if (monitor.Name != originalName)
                {
                    if (monitor.Name == textEditName.Text || monitor.Path == textEditPath.Text)
                    {
                        //Highlight culprit
                        if (monitor.Name == textEditName.Text) { textEditName.BackColor = System.Drawing.Color.Tomato; }
                        if (monitor.Path == textEditPath.Text) { textEditPath.BackColor = System.Drawing.Color.Tomato; }

                        lblValidation.Text = "All settings must be unique to this application monitor";
                        string message = "One or more of your settings are already in use by another monitor, all fields must be unique.";
                        string caption = "Not saved!";

                        using (new CenterWinDialog(this))
                        {
                            result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Exclamation);
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Populate list view from settings.config
        /// </summary>
        private void UpdateList()
        {
            listMonitors.Items.Clear();
            listMonitors.BeginUpdate();
            foreach (MonitorGroup.ApplicationElement monitor in settings.MonitorGroup.Monitors)
            {
                string alertTick = (monitor.Alert == "1") ? "\u2713" : "";
                //Row entry for listView on Form
                string[] listViewRow = { monitor.Name, monitor.Path, alertTick };
                var listItem = new ListViewItem(listViewRow);
                listMonitors.Items.Add(listItem);
            }
            listMonitors.EndUpdate();
        }

        /// <summary>
        /// Turns edit boxes and buttons on or off as appropriate
        /// </summary>
        /// <param name="enable">True to enable, false to disable UI edit elements</param>
        private void Edit(bool enable)
        {
            if (enable)
            {
                textEditName.Enabled = true;
                textEditPath.Enabled = true;
                btnBrowse.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = false;
                checkAlert.Enabled = true;
            }
            else
            {
                textEditPath.Text = "";
                textEditName.Text = "";
                textEditName.Enabled = false;
                textEditPath.Enabled = false;
                btnBrowse.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                checkAlert.Enabled = false;
                lblValidation.Text = "";
                textEditName.BackColor = System.Drawing.SystemColors.Window;
                textEditPath.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        /// <summary>
        /// Enable editing when an item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMonitors.SelectedItems.Count > 0)
            {
                //Enable UI
                Edit(true);

                //Bring values to edit boxes
                textEditName.Text = (listMonitors.SelectedItems[0].SubItems[0].Text);
                textEditPath.Text = (listMonitors.SelectedItems[0].SubItems[1].Text);
                checkAlert.Checked = (listMonitors.SelectedItems[0].SubItems[2].Text == "\u2713") ? true : false;
                editIndex = listMonitors.SelectedItems[0].Index;
                originalName = listMonitors.SelectedItems[0].SubItems[0].Text;
            }
            else
            {
                //None selected - clear edit boxes image and name and disable
                //Disable UI
                Edit(false);
                editIndex = default(int);
                originalName = "";
            }
        }

        /// <summary>
        /// Disable add/edit controls when SettingsTab is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "SettingsTab")
            {
                Edit(false);
                btnNew.Enabled = false;
            }
            else
            {
                Edit(false);
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (browseExe.ShowDialog() == DialogResult.OK)
            {
                textEditPath.Text = browseExe.FileName;
            }
        }

        /// <summary>
        /// Enable form to create new application monitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //Enable UI
            Edit(true);
        }

        /// <summary>
        /// Cancel editing press definition, just resets the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            Edit(false);
            editIndex = default(int);
            originalName = "";
            listMonitors.SelectedItems.Clear();
        }

        /// <summary>
        /// Save current edits to list and back to settings.config file via config class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //validate - check no fields empty
            if (FieldsAreValid())
            {
                string alertString = (checkAlert.Checked) ? "1" : "0";
                if (originalName != "")
                {
                    //locate originalID in config structure and update it
                    foreach (MonitorGroup.ApplicationElement monitor in settings.MonitorGroup.Monitors)
                    {
                        if (monitor.Name == originalName)
                        {
                            monitor.Name = textEditName.Text;
                            monitor.Path = textEditPath.Text;
                            monitor.Alert = alertString;
                        }
                    }
                }
                else
                {
                    //create new monitor object
                    MonitorGroup.ApplicationElement newMonitor = new MonitorGroup.ApplicationElement
                    {
                        Name = textEditName.Text,
                        Path = textEditPath.Text,
                        Alert = alertString
                    };
                    settings.Monitors.Add(newMonitor);
                }

                //Save and reload to UI
                settings.SaveMonitorSettings();
                UpdateList();
                Edit(false);
                editIndex = default(int);
                originalName = "";
                changed = true;
            }
            else
            {
                //Failed validation
            }
        }

        /// <summary>
        /// Delete press form collection, with confirm dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure you want to delete this monitor?";
            const string caption = "Confirm delete";

            using (new CenterWinDialog(this))
            {
                result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            }

            if (result == DialogResult.Yes)
            {
                //locate originalID in config structure and update it
                foreach (MonitorGroup.ApplicationElement monitor in settings.Monitors)
                {
                    if (monitor.Name == originalName)
                    {
                        settings.Monitors.Remove(monitor.Name);
                        settings.MonitorConfig.Save();
                    }
                }

                //Save and reload to UI
                settings.SaveMonitorSettings();
                UpdateList();
                listMonitors.SelectedItems.Clear();
                Edit(false);
                editIndex = default(int);
                originalName = "";
                changed = true;
            }
        }

        /// <summary>
        /// Close window (saving will have already been handled by the line editor)
        /// Offer to restart service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            SaveSettings();
            CheckReload();
        }

        /// <summary>
        /// Save the general preferences on close
        /// </summary>
        private void SaveSettings()
        {
            settings.FindSettingFromName("CheckPeriod").Value = textCheckInterval.Text;
            settings.FindSettingFromName("AlertEnabled").Value = (checkSendAlerts.Checked) ? "1" : "0";
            settings.FindSettingFromName("SMTPServer").Value = textSMTPServer.Text;
            settings.FindSettingFromName("SMTPUser").Value = textSMTPUser.Text;
            settings.FindSettingFromName("SMTPPort").Value = textSMTPPort.Text;
            settings.FindSettingFromName("CheckPeriod").Value = textCheckInterval.Text;
            settings.FindSettingFromName("EmailTo").Value = textEmailTo.Text;

            //Only do PW if changed
            if (textSMTPPassword.Text != "**********")
            {
                settings.FindSettingFromName("SMTPPassword").Value = ObfuscatePW(textSMTPPassword.Text);
            }

            settings.SaveMonitorSettings();
        }

        /// <summary>
        /// Does what it says on the tin NOTE: Not at all secure!
        /// </summary>
        /// <param name="pw"></param>
        /// <returns></returns>
        private string ObfuscatePW(string pw)
        {
            var obscure = "";
            if (pw != "")
            {
                obscure = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(pw));
            }
            return obscure;
        }

        //Intercept form close to trigger optional reload
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //Close if we've already asked, not needed or is shutting down
            if (e.CloseReason == CloseReason.WindowsShutDown || DialogResult == DialogResult.OK || DialogResult == DialogResult.No) return;

            //Check and ask if settings have changed
            CheckReload();
        }

        //Ask to reload if settings edited, dialog result will pass back to the calling tray application which will restart monitors if asked to
        private void CheckReload()
        {
            if (changed)
            {
                string message = "You have changed the monitor settings, do you want to stop and restart the monitor for changes to take effect?\r\n\r\nWARNING: Your monitored applications will restart if you choose yes.";
                string caption = "Restart Monitor?";

                using (new CenterWinDialog(this))
                {
                    result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
            Close();
        }

        /// <summary>
        /// UI updates if send alerts checkbox is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkSendAlerts_CheckedChanged(object sender, EventArgs e)
        {
            changed = true;
            if (checkSendAlerts.Checked)
            {
                SMTPSettingsGroup.Enabled = true;
                textEmailTo.Enabled = true;
                LabelEmailTo.Enabled = true;
            }
            else
            {
                SMTPSettingsGroup.Enabled = false;
                textEmailTo.Enabled = false;
                LabelEmailTo.Enabled = false;
            }
        }

        private void edited(object sender, EventArgs e)
        {
            changed = true;
        }
    }
}