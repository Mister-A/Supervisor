using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using static System.Environment;

namespace Supervisor
{
    /// <summary>
    /// Loads the application settings file from ProgramData path
    /// </summary>
    public class MonitorSettings
    {
        private readonly string localSettingsPath = GetFolderPath(SpecialFolder.CommonApplicationData) + "\\Supervisor\\";

        public MonitorSettings()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = localSettingsPath + @"settings.config"
            };
            try
            {
                MonitorConfig = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                MonitorGroup = MonitorConfig.GetSection("MonitorGroup") as MonitorGroup;
                Monitors = MonitorGroup.Monitors;
                SettingsGroup = MonitorConfig.GetSection("SettingsGroup") as SettingsGroup;
                Settings = SettingsGroup.Settings;
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

        public Configuration MonitorConfig { get; set; }
        public MonitorGroup MonitorGroup { get; set; }
        public SettingsGroup SettingsGroup { get; set; }
        public SettingsGroup.SettingsCollection Settings { get; set; }
        public MonitorGroup.MonitorCollection Monitors { get; set; }

        /// <summary>
        /// Triggers current settings to be written to file
        /// </summary>
        public bool SaveMonitorSettings()
        {
            MonitorConfig.Save(ConfigurationSaveMode.Modified);
            return true;
        }

        /// <summary>
        /// Look up setting from name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SettingsGroup.SettingsElement FindSettingFromName(string name)
        {
            SettingsGroup.SettingsElement result = null;

            var setting = from SettingsGroup.SettingsElement s in Settings
                          where s.Name == name
                          select s;

            if (setting.Any())
            {
                result = setting.First();
            }

            return result;
        }
    }
}