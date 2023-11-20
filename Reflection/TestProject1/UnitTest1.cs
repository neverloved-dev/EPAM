using ClassLibrary1;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void SaveAndLoadFromFileConfigurationProvider()
        {
            // Arrange
            MyClass obj = new MyClass();

            // Act
            obj.SettingFromFile = "ValueFromFile";
            obj.SaveSettings();
            obj.SettingFromFile = null; // Clear the value
            obj.LoadSettings();

            // Assert
            Assert.Equal("ValueFromFile", obj.SettingFromFile);
        }

        // Test saving and loading settings using ConfigurationManagerConfigurationProvider
        [Fact]
        public void SaveAndLoadFromConfigurationManagerConfigurationProvider()
        {
            // Arrange
            MyClass obj = new MyClass();

            // Act
            obj.SettingFromConfigManager = "ValueFromConfigManager";
            obj.SaveSettings();
            obj.SettingFromConfigManager = null; // Clear the value
            obj.LoadSettings();

            // Assert
            Assert.Equal("ValueFromConfigManager", obj.SettingFromConfigManager);
        }

        [Fact]
        public void SaveAndLoadFromFileConfigurationProvider_NonExistentFile()
        {
            // Arrange
            MyClass obj = new MyClass();
            // Clear the existing config file if it exists
            if (File.Exists("config.txt"))
                File.Delete("config.txt");

            // Act
            obj.SettingFromFile = "ValueFromFile";
            obj.SaveSettings();
            obj.SettingFromFile = null; // Clear the value
            obj.LoadSettings();

            // Assert
            Assert.Equal("ValueFromFile", obj.SettingFromFile);
        }

        // Test loading settings using FileConfigurationProvider when setting doesn't exist
        [Fact]
        public void LoadFromFileConfigurationProvider_SettingNotFound()
        {
            // Arrange
            MyClass obj = new MyClass();
            // Clear the existing config file if it exists
            if (File.Exists("config.txt"))
                File.Delete("config.txt");

            // Act
            obj.LoadSettings();

            // Assert
            Assert.Null(obj.SettingFromFile);
        }

        // Test loading settings using ConfigurationManagerConfigurationProvider when setting doesn't exist
        [Fact]
        public void LoadFromConfigurationManagerConfigurationProvider_SettingNotFound()
        {
            // Arrange
            MyClass obj = new MyClass();
            // Clear the existing setting from ConfigurationManager
            System.Configuration.ConfigurationManager.AppSettings["MySettingConfig"] = null;

            // Act
            obj.LoadSettings();

            // Assert
            Assert.Null(obj.SettingFromConfigManager);
        }

        // Test saving and loading settings using ConfigurationManagerConfigurationProvider with null value
        [Fact]
        public void SaveAndLoadFromConfigurationManagerConfigurationProvider_NullValue()
        {
            // Arrange
            MyClass obj = new MyClass();

            // Act
            obj.SettingFromConfigManager = null;
            obj.SaveSettings();
            obj.LoadSettings();

            // Assert
            Assert.Null(obj.SettingFromConfigManager);
        }
    }
}