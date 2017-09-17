using System;
using System.Configuration;
using System.Globalization;

namespace CoreTestFramework.Settings
{
    internal static class ConfigurationHelper
    {
        internal static T Get<T>(string name)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value != null)
            {
                if (typeof(T).IsEnum)
                    return (T)Enum.Parse(typeof(T), value);
                return (T)Convert.ChangeType(value, typeof(T));
            }
            else
            {
                var message = String.Format(CultureInfo.InvariantCulture, "AppSetting with name {0} not found. Please check the application configuration file.", name);
                throw new InvalidOperationException(message);
            }
        }
    }
}
