using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MVC_Dashboard.Helpers.Config
{
    /// <summary>
    /// Utility class for managing app settings in an application/web confuration file.
    /// </summary>
    public class ConfigUtility : AppSettingsReader
    {
        #region Fields
        private XmlNode _node = null;
        private int _configType;
        #endregion

        #region Properties
        public int ConfigType
        {
            get
            {
                return _configType;
            }
            set
            {
                _configType = value;
            }

        }
        #endregion

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// '-----------------------------------------------------------------------------------------
        public string docName = String.Empty;

        #region Public Methods
        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public bool AddSetting(string key, string value)
        {
            XmlDocument cfgDoc = new XmlDocument();
            LoadConfigDoc(cfgDoc, docName);
            // retrieve the appSettings node 
            _node = cfgDoc.SelectSingleNode("//appSettings");

            if (_node == null)
            {
                throw new System.InvalidOperationException("appSettings section not found");
            }

            try
            {
                // XPath select setting "add" element that contains this key    
                XmlElement addElem = (XmlElement)_node.SelectSingleNode("//add[@key='" + key + "']");
                if (addElem != null)
                {
                    addElem.SetAttribute("value", value);
                }
                // not found, so we need to add the element, key and value
                else
                {
                    XmlElement entry = cfgDoc.CreateElement("add");
                    entry.SetAttribute("key", key);
                    entry.SetAttribute("value", value);
                    _node.AppendChild(entry);
                }
                //save it
                SaveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cfgDoc = null;
            }
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public bool RemoveSetting(string key)
        {
            try
            {
                XmlDocument cfgDoc = new XmlDocument();
                LoadConfigDoc(cfgDoc, docName);
                // retrieve the appSettings node 
                _node = cfgDoc.SelectSingleNode("//appSettings");
                if (_node == null)
                {
                    throw new System.InvalidOperationException("appSettings section not found");
                }
                // XPath select setting "add" element that contains this key to remove   
                _node.RemoveChild(_node.SelectSingleNode("//add[@key='" + key + "']"));

                SaveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Private Methods
        private void SaveConfigDoc(XmlDocument cfgDoc, string cfgDocPath)
        {
            XmlTextWriter writer = new XmlTextWriter(cfgDocPath, null);

            try
            {
                writer.Formatting = Formatting.Indented;
                cfgDoc.WriteTo(writer);
                writer.Flush();
                writer.Close();
                return;
            }
            catch
            {
                throw;
            }
            finally
            {
                writer = null;
            }
        }

        private XmlDocument LoadConfigDoc(XmlDocument cfgDoc, string cfgDocPath)
        {
            // load the config file 
            if (Convert.ToInt32(ConfigType) == Convert.ToInt32(ConfigFileType.AppConfig))
            {
                docName = ((Assembly.GetEntryAssembly()).GetName()).Name;
                docName += ".exe.config";
            }
            else
            {
                docName = cfgDocPath;
                //System.Web.HttpContext.Current.Server.MapPath("web.config");
            }
            cfgDoc.Load(docName);
            return cfgDoc;
        }

        //private XmlDocument LoadConfigDoc(XmlDocument cfgDoc)
        //{
        //    // load the config file 
        //    if (Convert.ToInt32(ConfigType) == Convert.ToInt32(ConfigFileType.AppConfig))
        //    {
        //        docName = ((Assembly.GetEntryAssembly()).GetName()).Name;
        //        docName += ".exe.config";
        //    }
        //    else
        //    {
        //        docName = System.Web.HttpContext.Current.Server.MapPath("web.config");
        //    }
        //    cfgDoc.Load(docName);
        //    return cfgDoc;
        //}
        #endregion
    }
}
