using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PluginLoader
    {
        public static object LoadProvider(string providerAssemblyPath, string providerClassName)
        {
            Assembly providerAssembly = Assembly.LoadFrom(providerAssemblyPath);

            Type providerType = providerAssembly.GetType(providerClassName);
            if (providerType != null)
            {
                return Activator.CreateInstance(providerType);
            }

            return null;
        }

    }
}
