using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManagerConfigurationProvider
{
    public static class ConfigurationManagerConfigurationProvider
    {
        public static void SaveSetting(string settingName, string value)
        {
            // Logic to save settings to ConfigurationManager (app.config / appsettings.json)
            ConfigurationManager.AppSettings[settingName] = value;
        }

        public static string LoadSetting(string settingName)
        {
            // Logic to load settings from ConfigurationManager (app.config / appsettings.json)

            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
