using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Supervisor
{
    /// <summary>
    /// Sends email if an application is restarted
    /// </summary>
    internal class Alert
    {
        private readonly MonitorSettings settings = new MonitorSettings();

        public bool Send(string information)
        {
            string message = "Program " + information + " on " + Environment.MachineName + " was restarted at " + DateTime.Now.ToString();
            System.Diagnostics.Debug.WriteLine("Supervisor: " + message);
            bool result = true;

            //Send email if enabled
            if (settings.FindSettingFromName("AlertEnabled").Value == "1")
            {
                var smtpClient = new SmtpClient(settings.FindSettingFromName("SMTPServer").Value)
                {
                    Port = int.Parse(settings.FindSettingFromName("SMTPPort").Value),
                    Credentials = new NetworkCredential(settings.FindSettingFromName("SMTPUser").Value, deObfuscate(settings.FindSettingFromName("SMTPPassword").Value)),
                    EnableSsl = true,
                };
                try
                {
                    smtpClient.Send(settings.FindSettingFromName("SMTPUser").Value, settings.FindSettingFromName("SMTPUser").Value, "Supervisor restarted a program", message);
                }
                catch (Exception ex)
                {
                    result = false;
                    System.Diagnostics.Debug.WriteLine("Exception sending email: " + ex.ToString());
                }
            }
            return result;
        }

        private string deObfuscate(string data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }
    }
}