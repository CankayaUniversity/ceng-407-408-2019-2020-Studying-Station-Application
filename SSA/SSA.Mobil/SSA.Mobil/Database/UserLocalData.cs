
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSA.Mobil.Database
{
    public class UserLocalData
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string userToken
        {
            get => AppSettings.GetValueOrDefault(DataKey.userToken.ToString(), string.Empty);
            set => AppSettings.AddOrUpdateValue(DataKey.userToken.ToString(), value);
        }

        public static void removeData()
        {
            AppSettings.Remove(DataKey.userToken.ToString());
        }
    }

    public enum DataKey
    {
        userToken
    }
}
