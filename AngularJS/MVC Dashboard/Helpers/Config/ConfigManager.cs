
using MVC_Dashboard.Helpers.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.Config
{
    /// <summary>
    /// Helper class for working with an application's configuration's app settings.
    /// </summary>
    public static class ConfigManager
    {
        #region Constants
        private const string MISSING_APPSETTING_ERR_MSG = "Missing {0} setting";
        #endregion

        #region Static Methods
        /// <summary>
        /// 
        /// </summary>
        public static NameValueCollection AppSettings = ConfigurationManager.AppSettings;

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified config app setting's value as a boolean value 
        /// </summary>
        /// <param name="appSetting"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static bool GetAppSettingAsBool(string appSetting)
        {
            string setting = AppSettings[appSetting];
            if (setting == null || setting.Trim().Length == 0)
            {
                throw new ConfigurationErrorsException(String.Format(MISSING_APPSETTING_ERR_MSG, appSetting));
            }

            return BooleanHelper.ConvertToBool(setting);
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified config app setting's value as an integer number.
        /// </summary>
        /// <param name="appSetting"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static int GetAppSettingAsInt(string appSetting)
        {
            string setting = AppSettings[appSetting];
            if (setting == null || setting.Trim().Length == 0)
            {
                throw new ConfigurationErrorsException(String.Format(MISSING_APPSETTING_ERR_MSG, appSetting));
            }

            return IntegerHelper.ConvertToInt(setting);
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified config app setting's value as a float number.
        /// </summary>
        /// <param name="appSetting"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static float GetAppSettingAsFloat(string appSetting)
        {
            string setting = AppSettings[appSetting];
            if (setting == null || setting.Trim().Length == 0)
            {
                throw new ConfigurationErrorsException(String.Format(MISSING_APPSETTING_ERR_MSG, appSetting));
            }

            return FloatHelper.ConvertToFloat(setting);
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Get specified config setting's value.
        /// </summary>
        /// <param name="appSetting"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static string GetAppSetting(string appSetting)
        {
            string setting = AppSettings[appSetting];
            if (setting == null || setting.Trim().Length == 0)
            {
                throw new ConfigurationErrorsException(String.Format(MISSING_APPSETTING_ERR_MSG, appSetting));
            }

            return setting;
        }

        ///// '-----------------------------------------------------------------------------------------
        ///// <summary>
        ///// Adds the ConfigurationManager.AppSettings NameValueCollection to a DataTable.
        ///// </summary>
        ///// <returns></returns>
        ///// '-----------------------------------------------------------------------------------------
        //public static DataTable GetAppSettingsAsDataTable()
        //{
        //    NameValueCollection appSettings = AppSettings;
        //    string[] keys = appSettings.AllKeys;

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("key");
        //    dt.Columns.Add("value");

        //    for (int i = 0; i < appSettings.Count; i++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["key"] = keys[i];
        //        dr["value"] = appSettings[i];

        //        dt.Rows.Add(dr);
        //    }

        //    return dt;
        //}

        ///// '-----------------------------------------------------------------------------------------
        ///// <summary>
        ///// Adds the ConfigurationManager.AppSettings NameValueCollection to a DataSet.
        ///// </summary>
        ///// <returns></returns>
        ///// '-----------------------------------------------------------------------------------------
        //public static DataSet GetAppSettingsAsDataSet()
        //{
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(GetAppSettingsAsDataTable());
        //    return ds;
        //}

        ///// '-----------------------------------------------------------------------------------------
        ///// <summary>
        ///// Adds the ConfigurationManager.AppSettings NameValueCollection to a DataTable.
        ///// </summary>
        ///// <param name="keyColumnName">Specify your own column name for the key.</param>
        ///// <param name="valueColumnName">Specify your own column name for the value.</param>
        ///// <returns></returns>
        ///// '-----------------------------------------------------------------------------------------
        //public static DataTable GetAppSettingsAsDataTable(string keyColumnName, string valueColumnName)
        //{
        //    NameValueCollection appSettings = AppSettings;
        //    string[] keys = appSettings.AllKeys;

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(keyColumnName);
        //    dt.Columns.Add("value");

        //    for (int i = 0; i < appSettings.Count; i++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr[keyColumnName] = keys[i];
        //        dr[valueColumnName] = appSettings[i];

        //        dt.Rows.Add(dr);
        //    }

        //    return dt;
        //}

        ///// '-----------------------------------------------------------------------------------------
        ///// <summary>
        ///// Adds the ConfigurationManager.AppSettings NameValueCollection to a DataSet.
        ///// </summary>
        ///// <param name="keyColumnName">Specify your own column name for the key.</param>
        ///// <param name="valueColumnName">Specify your own column name for the value.</param>
        ///// <returns></returns>
        ///// '-----------------------------------------------------------------------------------------
        //public static DataSet GetAppSettingsAsDataSet(string keyColumnName, string valueColumnName)
        //{
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(GetAppSettingsAsDataTable(keyColumnName, valueColumnName));
        //    return ds;
        //}

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the specified database connection string in the ConnectionStrings section.
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the first database connection string in the ConnectionStrings section.
        /// </summary>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }
        #endregion
    }
}
