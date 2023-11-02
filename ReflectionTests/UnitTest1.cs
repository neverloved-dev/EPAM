using ReflectionClasses;
namespace ReflectionTests
{
    public class UnitTest1
    {
        [Fact]
        public void LoadSettings_LoadsFileConfigurationSetting()
        {
            // Arrange
            var myAppSettings = new MyAppSettings();
            // Mock the FileConfigurationProvider to return a specific value for "MySetting"

            // Act
            myAppSettings.LoadSettings();

            // Assert
            Assert.Equal(expectedValue, myAppSettings.MyIntSetting);
        }

        [Fact]
        public void LoadSettings_LoadsConfigurationManagerSetting()
        {
            // Arrange
            var myAppSettings = new MyAppSettings();
            // Mock the ConfigurationManagerConfigurationProvider to return a specific value for "AnotherSetting"

            // Act
            myAppSettings.LoadSettings();

            // Assert
            Assert.Equal(expectedValue, myAppSettings.MyStringSetting);
        }

        [Fact]
        public void SaveSettings_SavesFileConfigurationSetting()
        {
            // Arrange
            var myAppSettings = new MyAppSettings();
            // Mock the FileConfigurationProvider

            // Act
            myAppSettings.MyIntSetting = 42;
            myAppSettings.SaveSettings();

            // Assert: Check if the FileConfigurationProvider saved the correct value
            // You may need to implement a mechanism to check the saved value in the mock.
        }

        [Fact]
        public void SaveSettings_SavesConfigurationManagerSetting()
        {
            // Arrange
            var myAppSettings = new MyAppSettings();
            // Mock the ConfigurationManagerConfigurationProvider

            // Act
            myAppSettings.MyStringSetting = "NewValue";
            myAppSettings.SaveSettings();

            // Assert: Check if the ConfigurationManagerConfigurationProvider saved the correct value
            // You may need to implement a mechanism to check the saved value in the mock.
        }

    }
}