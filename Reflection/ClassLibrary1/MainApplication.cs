using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
     class MainApplication
    {
        public void UseConfigurationProviders()
        {
            string fileProviderPath = "\"C:\\Users\\x0nr\\Desktop\\EPAM\\Reflection\\FileConfigurationProvider\\bin\\Debug\\netstandard2.1\\FileConfigurationProvider.dll\"";
            string configManagerProviderPath = "\"C:\\Users\\x0nr\\Desktop\\EPAM\\Reflection\\ConfigurationAttributeComponentBase\\bin\\Debug\\netstandard2.1\\ConfigurationManagerConfigurationProvider.dll\"";

            object fileProviderObject = PluginLoader.LoadProvider(fileProviderPath, "FileConfigurationProvider.FileConfigurationProvider");
            dynamic fileProvider = Convert.ChangeType(fileProviderObject, fileProviderObject.GetType());

            if (fileProvider != null)
            {
                fileProvider.SaveSetting("SettingName", "Value");
                string loadedValue = fileProvider.LoadSetting("SettingName");
                Console.WriteLine("File Provider Loaded Value: " + loadedValue);
            }

            object configManagerProviderObject = PluginLoader.LoadProvider(configManagerProviderPath, "ConfigurationManagerConfigurationProvider.ConfigurationManagerConfigurationProvider");
            dynamic configManagerProvider = Convert.ChangeType(configManagerProviderObject, configManagerProviderObject.GetType());

            if (configManagerProvider != null)
            {
                configManagerProvider.SaveSetting("SettingName", "Value");
                string loadedValue = configManagerProvider.LoadSetting("SettingName");
                Console.WriteLine("Config Manager Provider Loaded Value: " + loadedValue);
            }
        }
    }
}
