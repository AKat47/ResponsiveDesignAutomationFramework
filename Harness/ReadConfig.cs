using Harness.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Harness.ReadSettings
{
    public static class Configurations
    {
        public static Uri url;
        public static string browserName;
        public static string dbInstance;
        public static string userName;
        public static string passWord;
        public static string deviceName;

    }

    public static class ReadSettings
    {
        public static void ReadConfig()
        {
             string filePath = @"C:\Anantha\ResponsiveDesignFramework\Configuration.json";
             string jsonString = File.ReadAllText(filePath);
             RootObject configModel = JsonConvert.DeserializeObject<RootObject>(jsonString);
             foreach(EnironmentConfig config in configModel.EnironmentConfig)
             {
                if(config.Environment == configModel.env)
                {
                    Configurations.url = config.Url;
                    Configurations.dbInstance = config.DBInstance;

                }
             }

            Configurations.deviceName = configModel.deviceName;
            Configurations.browserName = configModel.browserName;
            Configurations.userName = configModel.userName;
            Configurations.passWord = configModel.passWord;
            

        }
    }
}