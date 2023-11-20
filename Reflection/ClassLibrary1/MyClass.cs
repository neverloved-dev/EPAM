using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // Base class where custom attributes will be used

    // Example class using custom attributes
    public class MyClass : ConfigurationComponentBase
    {
        [ConfigurationItem("MySettingFile", "File")]
        public string SettingFromFile { get; set; }

        [ConfigurationItem("MySettingConfig", "ConfigurationManager")]
        public string SettingFromConfigManager { get; set; }
    }
}
