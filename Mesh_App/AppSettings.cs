using System.Configuration;

namespace Mesh_App
{
    public static class AppSettings
    {

        // port that the didcomm agent will use to listen for incoming messages
        public static int DefaultAgentPort
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

        public static string AgentURL { get { return $"http://localhost:{DefaultAgentPort}/DIDCOMMEndpoint/"; } }

        public static string ProfileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Technitium", "Mesh"); 
    }
}
