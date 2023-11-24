using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IConfigurationProvider
    {
        void SaveSetting(string settingName, string value);
        string LoadSetting(string settingName);
    }
}
