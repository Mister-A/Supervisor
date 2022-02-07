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

            //Check all fields are unique in pressGroup
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
                //Row entry for listView on Form
                string[] listViewRow = { monitor.Name, monitor.Path };
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
                lblValidation.Text = "";
                textEditName.BackColor = System.Drawing.SystemColors.Window;
                textEditPath.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void ListMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMonitors.SelectedItems.Count > 0)
            {
                //Enable UI
                Edit(true);

                //Bring values to edit boxes
                textEditName.Text = (listMonitors.SelectedItems[0].SubItems[0].Text);
                textEditPath.Text = (listMonitors.SelectedItems[0].SubItems[1].Text);
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
                if (originalName != "")
                {
                    //locate originalID in config structure and update it
                    foreach (MonitorGroup.ApplicationElement monitor in settings.MonitorGroup.Monitors)
                    {
                        if (monitor.Name == originalName)
                        {
                            monitor.Name = textEditName.Text;
                            monitor.Path = textEditPath.Text;
                        }
                    }
                }
                else
                {
                    //create new monitor object
                    MonitorGroup.ApplicationElement newMonitor = new MonitorGroup.ApplicationElement
                    {
                        Name = textEditName.Text,
                        Path = textEditPath.Text
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
            CheckReload();
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

        //Ask to reload if settings edited
        private void CheckReload()
        {
            if (changed)
            {
                string message = "You have changed the monitor settings, do you want to stop and restart the monitor for changes to take effect?";
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
    }
}