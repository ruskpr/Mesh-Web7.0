using System.Configuration;

namespace Mesh_App
{
    public static class AppSettings
    {

        // port that the didcomm agent will use to listen for incoming messages
        public static int AgentPort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["Port"]);
            }
            set
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Port"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        
    }
}
