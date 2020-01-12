using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace GitHubAutomation.Services
{
    public static class TestDataReader
    {
        public static class Settings
        {
            private static string _browser;
            public static string Browser
            {
                get
                {
                    return _browser;
                }
                set
                {
                    if (_browser == null)
                    {
                        _browser = value;
                    }
                }
            }

            private static string _env;
            public static string Env
            {
                get
                {
                    return _env;
                }
                set
                {
                    if (_env == null)
                    {
                        _env = value switch
                        {
                            "dev" => Configurations.DevConfig,
                            "qa" => Configurations.QAConfig,
                            _ => Configurations.DevConfig
                        };
                    }
                }
            }

            internal static class Configurations
            {
                public const string DevConfig = "dev";
                public const string QAConfig = "qa";
            }
        }

        static Configuration ConfigFile
        {
            get
            {
                var variableFromConsole = Settings.Env;
                string file = string.IsNullOrEmpty(variableFromConsole) ? "qa" : variableFromConsole;
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    @"ConfigFiles\" + file + ".config"
                };
                return ConfigurationManager.OpenMappedExeConfiguration(configeMap, ConfigurationUserLevel.None);
            }
        }
       
        public static string GetData(string key)
        {
            return ConfigFile.AppSettings.Settings[key]?.Value;
        }
    }
}
