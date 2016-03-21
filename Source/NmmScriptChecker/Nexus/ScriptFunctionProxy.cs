using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using Nexus.Client.ModManagement.Scripting.CSharpScript;

namespace Nexus.Client.ModManagement.Scripting
{
    public class ScriptFunctionProxy : MarshalByRefObject
    {
        public ScriptFunctionProxy(IMod p_modMod, IGameMode p_gmdGameMode, IEnvironmentInfo p_eifEnvironmentInfo, InstallerGroup p_igpInstallers, UIUtil p_uipUIProxy)
        {
        }

        protected virtual void OnTaskStarted(EventArgs<IBackgroundTask> e)
        {
            TaskStarted(this, e);
        }

        private void TaskStarted(ScriptFunctionProxy scriptFunctionProxy, EventArgs<IBackgroundTask> e)
        {
            return;
        }

        protected void OnTaskStarted(IBackgroundTask p_bgtTask)
        {
            return;
        }

        public bool PerformBasicInstall()
        {
            return false;
        }

        public bool InstallFolderFromMod(string p_strFrom, bool p_booRecurse)
        {
            return false;
        }

        public bool InstallFolderFromMod(string p_strFrom, string p_strTo, bool p_booRecurse)
        {
            return false;
        }

        public virtual bool InstallFileFromMod(string p_strFrom, string p_strTo)
        {
            return false;
        }

        private void SaveXMLInstalledFiles(string p_strFrom, string p_strTo)
        {
            return;
        }

        public bool InstallFileFromMod(string p_strFile)
        {
            return false;
        }

        public string[] GetModFileList()
        {
            return null;
        }

        public string[] GetModFileList(string p_strFolder, bool p_booRecurse)
        {
            return null;
        }

        public byte[] GetFileFromMod(string p_strFile)
        {
            return null;
        }

        public string[] GetExistingDataFileList(string p_strPath, string p_strPattern, bool p_booAllFolders)
        {
            return null;
        }

        public bool DataFileExists(string p_strPath)
        {
            return false;
        }

        public byte[] GetExistingDataFile(string p_strPath)
        {
            return null;
        }

        public bool GenerateDataFile(string p_strPath, byte[] p_bteData)
        {
            return false;
        }

        public void MessageBox(string p_strMessage)
        {
            return;
        }

        public void MessageBox(string p_strMessage, string p_strTitle)
        {
            return;
        }

        public DialogResult MessageBox(string p_strMessage, string p_strTitle, MessageBoxButtons p_mbbButtons)
        {
            return default(DialogResult);
        }

        public DialogResult MessageBox(string p_strMessage, string p_strTitle, MessageBoxButtons p_mbbButtons, MessageBoxIcon p_mdiIcon)
        {
            return default(DialogResult);
        }

        public DialogResult ExtendedMessageBox(string p_strMessage, string p_strTitle, string p_strDetails, MessageBoxButtons p_mbbButtons, MessageBoxIcon p_mdiIcon)
        {
            return default(DialogResult);
        }

        public string[] Select(IList<SelectOption> p_lstOptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }

        public virtual Version GetModManagerVersion()
        {
            return null;
        }

        public Version GetGameVersion()
        {
            return null;
        }

        protected string[] RelativizePluginPaths(IList<Plugin> p_lstPlugins)
        {
            return null;
        }

        public string[] GetAllPlugins()
        {
            return null;
        }

        public string[] GetActivePlugins()
        {
            return null;
        }

        public void SetPluginActivation(string p_strPluginPath, bool p_booActivate)
        {
            return;
        }

        protected void DoSetPluginOrderIndex(string p_strPlugin, int p_intNewIndex)
        {
            return;
        }

        public void SetPluginOrderIndex(string p_strPlugin, int p_intNewIndex)
        {
            return;
        }

        protected void DoSetLoadOrder(int[] p_intPlugins)
        {
            return;
        }

        public void SetLoadOrder(int[] p_intPlugins)
        {
            return;
        }
        
        protected void DoSetLoadOrder(int[] p_intPlugins, int p_intPosition)
        {
            return;
        }

        public void SetLoadOrder(int[] p_intPlugins, int p_intPosition)
        {
            return;
        }

        public void SetRelativeLoadOrder(string[] p_strRelativelyOrderedPlugins)
        {
            return;
        }

        public string GetIniString(string p_strSettingsFileName, string p_strSection, string p_strKey)
        {
            return null;
        }

        public Int32 GetIniInt(string p_strSettingsFileName, string p_strSection, string p_strKey)
        {
            return 0;
        }

        public bool EditIni(string p_strSettingsFileName, string p_strSection, string p_strKey, string p_strValue)
        {
            return false;
        }

        public void SetDeactivationWarning(string p_strPlugin, string p_strWarningType)
        {
        }

        private void SetDeactivationWarning(string p_strPlugin, DeactivationWarningType p_dwtWarningType)
        {
        }
    }

    public enum DeactivationWarningType
    {
        Allow,
        WarnAgainst,
        Disallow
    }
}
