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
        string fileProviderPath = @"C:\Users\x0nr\Desktop\EPAM\Reflection\FileConfigurationProvider\bin\Debug\netstandard2.1\FileConfigurationProvider.dll";
        string configManagerProviderPath = @"C:\Users\x0nr\Desktop\EPAM\Reflection\ConfigurationAttributeComponentBase\bin\Debug\netstandard2.1\ConfigurationManagerConfigurationProvider.dll";

        protected dynamic FileConfigurationProvider { get; set; }
        protected dynamic ConfigurationManagerConfigurationProvider { get; set; }

        protected ConfigurationComponentBase()
        {
            InitializeProviders();
        }

        private void InitializeProviders()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type fileConfigProviderType = assembly.GetType("FileConfigurationProvider.FileConfigurationProvider");
            if (fileConfigProviderType != null)
            {
                FileConfigurationProvider = Activator.CreateInstance(fileConfigProviderType);
            }

            Type configManagerConfigProviderType = assembly.GetType("ConfigurationManagerConfigurationProvider.ConfigurationManagerConfigurationProvider");
            if (configManagerConfigProviderType != null)
            {
                ConfigurationManagerConfigurationProvider = Activator.CreateInstance(configManagerConfigProviderType);
            }
        }

            public void SaveSettings()
        {
            object fileProviderObject = PluginLoader.LoadProvider(fileProviderPath, "FileConfigurationProvider.FileConfigurationProvider");
            dynamic fileProvider = Convert.ChangeType(fileProviderObject, fileProviderObject.GetType());
            object configManagerProviderObject = PluginLoader.LoadProvider(configManagerProviderPath, "ConfigurationManagerConfigurationProvider.ConfigurationManagerConfigurationProvider");
            dynamic configManagerProvider = Convert.ChangeType(configManagerProviderObject, configManagerProviderObject.GetType());
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
                            if (fileProvider != null)
                            {
                                fileProvider.SaveSetting(attribute.SettingName, settingValue);
                            }
                            else
                            {
                                throw new NullReferenceException("File configuration  is null");
                            }
                            
                        }
                        else if (attribute.ProviderType == "ConfigurationManager")
                        {
                            if (configManagerProvider != null)
                            { 
                               configManagerProvider.SaveSetting(attribute.SettingName, settingValue);
                            
                            }
                            else
                            {
                                throw new NullReferenceException("Configuration managaer is null");
                            }
                            
                        }
                        // Add more providers as needed
                    }
                }
            }
        }

        public void LoadSettings()
        {
            object fileProviderObject = PluginLoader.LoadProvider(fileProviderPath, "FileConfigurationProvider.FileConfigurationProvider");
            dynamic fileProvider = Convert.ChangeType(fileProviderObject, fileProviderObject.GetType());
            object configManagerProviderObject = PluginLoader.LoadProvider(configManagerProviderPath, "ConfigurationManagerConfigurationProvider.ConfigurationManagerConfigurationProvider");
            dynamic configManagerProvider = Convert.ChangeType(configManagerProviderObject, configManagerProviderObject.GetType());
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ConfigurationItemAttribute attribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute));
                if (attribute != null)
                {
                    string loadedValue = null;
                    if (attribute.ProviderType == "File")
                    {
                        if (fileProvider != null)
                        {
                            fileProvider.SaveSetting("SettingName", "Value");
                            loadedValue = fileProvider.LoadSetting("SettingName");
                        }
                        else
                        {
                            if (configManagerProvider != null)
                            {
                                configManagerProvider.SaveSetting("SettingName", "Value");
                                loadedValue = configManagerProvider.LoadSetting("SettingName");
                            }
                            else
                            {
                                loadedValue = fileProvider.LoadSetting(attribute.SettingName);
                            }
                        }

                    }
                    else if (attribute.ProviderType == "ConfigurationManager")
                    {
                        loadedValue = configManagerProvider.LoadSetting(attribute.SettingName);
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
