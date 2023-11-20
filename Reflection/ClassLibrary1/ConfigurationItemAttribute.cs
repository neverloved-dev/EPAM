using System;
using System.IO;
using System.Configuration;
using System.Reflection;

// Custom attribute for configuration settings
[AttributeUsage(AttributeTargets.Property)]
public class ConfigurationItemAttribute : Attribute
{
    public string SettingName { get; }
    public string ProviderType { get; }

    public ConfigurationItemAttribute(string settingName, string providerType)
    {
        SettingName = settingName;
        ProviderType = providerType;
    }
}


