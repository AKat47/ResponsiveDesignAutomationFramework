namespace Automation.Settings
{
    public static class ReadSettings
    {
        public static void ReadConfig()
        {
             string jsonString = File.ReadAllText(System.Reflection.Assembly.GetExecutingAssembly().Location);  
                    
        }
    }
}