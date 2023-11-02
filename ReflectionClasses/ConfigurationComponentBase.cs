using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionClasses
{
    public class ConfigurationComponentBase
    {
        public void LoadSettings()
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ConfigurationItemAttribute configurationItemAttribute = (ConfigurationItemAttribute)property.GetCustomAttribute(typeof(ConfigurationItemAttribute));
                if (configurationItemAttribute!=null)
                {
                    string settingName = configurationItemAttribute.SettingName;
                    string providerType = configurationItemAttribute.ProviderType; 
                    // Use the provider based on providerType and set the property value.
                    // You need to implement the logic to read settings here.
                }
            }
        }

        public void SaveSettings() 
        {

        }

    }
}
