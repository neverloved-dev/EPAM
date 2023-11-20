using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ConfigurationComponentBase
    {
        public void SaveSettings()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ConfigurationItemAttribute attribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute));
                if (attribute != null)
                {
                    string settingValue = property.GetValue(this)?.ToString();
                    if (settingValue != null)
                    {
                        if (attribute.ProviderType == "File")
                        {
                            FileConfigurationProvider.SaveSetting(attribute.SettingName, settingValue);
                        }
                        else if (attribute.ProviderType == "ConfigurationManager")
                        {
                            ConfigurationManagerConfigurationProvider.SaveSetting(attribute.SettingName, settingValue);
                        }
                        // Add more providers as needed
                    }
                }
            }
        }

        public void LoadSettings()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ConfigurationItemAttribute attribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute));
                if (attribute != null)
                {
                    string loadedValue = null;
                    if (attribute.ProviderType == "File")
                    {
                        loadedValue = FileConfigurationProvider.LoadSetting(attribute.SettingName);
                    }
                    else if (attribute.ProviderType == "ConfigurationManager")
                    {
                        loadedValue = ConfigurationManagerConfigurationProvider.LoadSetting(attribute.SettingName);
                    }
                    // Add more providers as needed

                    if (loadedValue != null)
                    {
                        Type propertyType = property.PropertyType;
                        object convertedValue = Convert.ChangeType(loadedValue, propertyType);
                        property.SetValue(this, convertedValue);
                    }
                }
            }
        }
    }

}
