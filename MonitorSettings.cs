using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Environment;

namespace Supervisor
{
    /// <summary>
    /// Loads the application settings file from ProgramData path
    /// </summary>
    internal class MonitorSettings
    {
        private string localSettingsPath = GetFolderPath(SpecialFolder.CommonApplicationData) + "\\Supervisor\\";

        internal MonitorSettings()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = localSettingsPath + @"settings.config";
            try
            {
                monitorConfig = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                monitorGroup = monitorConfig.GetSection("MonitorGroup") as MonitorGroup;
                monitors = monitorGroup.Monitors;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Supervisor: Exception opening settings.config: " + ex.Message);
                int errorCode = -1;
                if (ex.InnerException != null)
                {
                    errorCode = ex.InnerException.HResult & 0xFFFF;
                }
                else
                {
                    errorCode = ex.HResult & 0xFFFF;
                }
                string message = "Your settings.config file appears to be corrupt, you may need to delete it or reinstall this program\r\n (" + ex.Message + ")";
                string caption = "Corrupt settings detected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = System.Windows.Forms.MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //Close app
                Environment.Exit(1);
            }
        }

        public Configuration monitorConfig { get; set; }
        public MonitorGroup monitorGroup { get; set; }
        public MonitorGroup.MonitorCollection monitors { get; set; }

        /// <summary>
        /// Triggers current settings to be written to file
        /// </summary>
        public bool SaveMonitorSettings()
        {
            monitorConfig.Save(ConfigurationSaveMode.Modified);
            return true;
        }
    }
}