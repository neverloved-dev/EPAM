using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileConfigurationProvider
{// Configuration providers
    public  class FileConfigurationProvider
    {
        public static void SaveSetting(string settingName, string value)
        {
            // Logic to save settings to a custom file
            // Example: Write to a text file
            File.WriteAllText("config.txt", $"{settingName}={value}");
        }

        public static string LoadSetting(string settingName)
        {
            // Logic to load settings from a custom file
            // Example: Read from a text file
            if (File.Exists("config.txt"))
            {
                string[] lines = File.ReadAllLines("config.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2 && parts[0] == settingName)
                        return parts[1];
                }
            }
            return null; // Setting not found
        }
    }



}
