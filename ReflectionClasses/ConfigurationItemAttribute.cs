namespace ReflectionClasses
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute:Attribute
    {
        public string SettingName { get; }
        public string ProviderType { get; }

        public ConfigurationItemAttribute(string settingName, string providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }
    }
}