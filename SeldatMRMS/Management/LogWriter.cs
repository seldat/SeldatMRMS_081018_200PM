using System;
using System.IO;
using System.Reflection;
using System.Windows;


namespace SeldatMRMS.Management
{
    public class LogWriter
	{
		private static string m_exePath = string.Empty;

		public static void LogWrite(string logMessage,String header)
		{

            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Properties.Resources.NAME_LOGFOLDER;
            //MessageBox.Show(m_exePath);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + header + "_log_" + DateTime.Today.ToString("ddMMyy") + ".txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
		public static void LogWrite(String foldername,string logMessage, String header)
		{

            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Properties.Resources.NAME_LOGFOLDER + "\\" + foldername;
            //MessageBox.Show(m_exePath);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + header + "_log_" + DateTime.Today.ToString("ddMMyy") + ".txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("{0} {1}", DateTime.Now.ToShortTimeString(), DateTime.Now.ToShortDateString());
                txtWriter.WriteLine(" - {0}", logMessage);
            }
            catch (Exception ex)
            {
            }
        }
        private void OnNewDay(object sender, EventArgs e)
		{
			// new day comes
		}
	}
}
