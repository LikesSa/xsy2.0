using System.Configuration;

namespace xsy.likes.Base
{
    public class ConfigContent
    {

        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSettingsGet(string key)
        {
            string result = string.Empty;
            try
            {
                result = ConfigurationManager.AppSettings.Get(key);
            }
            catch { }
            return result;
        }



        public static void AppSettingsSet(string key, string value)
        {
            var configure = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (configure.AppSettings.Settings[key] != null)
                configure.AppSettings.Settings[key].Value = value;
            else
                configure.AppSettings.Settings.Add(key, value);

            configure.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSetting");
            ConfigurationManager.AppSettings[key] = value;
        }


        /// <summary>
        /// 添加新的Key ，Value键值对
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public static void Add(string key, string value)
        {
            ConfigurationManager.AppSettings.Add(key, value);
        }

        /// <summary>
        /// 根据Key删除项
        /// </summary>
        /// <param name="key">Key</param>
        public static void Remove(string key)
        {
            ConfigurationManager.AppSettings.Remove(key);
        }


    }
}
