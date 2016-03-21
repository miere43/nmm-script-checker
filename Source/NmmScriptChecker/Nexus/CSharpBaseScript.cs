using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security;

namespace Nexus.Client.ModManagement.Scripting.CSharpScript
{
    public class CSharpBaseScript
    {
        protected static string LastError { get; set; }

        protected static CSharpScriptFunctionProxy Functions { get; private set; }

        public static void Setup()
        {
        }

        protected static void ExecuteMethod(Action p_gmdMethod)
        {
        }

        protected static T ExecuteMethod<T>(Func<T> p_fncMethod)
        {
            return default(T);
        }

        public static string GetLastError()
        {
            return null;
        }

        public static bool PerformBasicInstall()
        {
            return false;
        }

        public static bool CopyDataFile(string p_strFrom, string p_strTo)
        {
            return false;
        }

        public static bool InstallFileFromMod(string p_strFrom, string p_strTo)
        {
            return false;
        }

        public static bool InstallFileFromMod(string p_strFile)
        {
            return false;
        }

        public static string[] GetModFileList()
        {
            return null;
        }

        public static byte[] GetFileFromMod(string p_strFile)
        {
            return null;
        }

        public static string[] GetExistingDataFileList(string p_strPath, string p_strPattern, bool p_booAllFolders)
        {
            return null;
        }

        public static bool DataFileExists(string p_strPath)
        {
            return false;
        }

        public static byte[] GetExistingDataFile(string p_strPath)
        {
            return null;
        }

        public static bool GenerateDataFile(string p_strPath, byte[] p_bteData)
        {
            return false;
        }

        public static void MessageBox(string p_strMessage)
        {
            return;
        }

        public static void MessageBox(string p_strMessage, string p_strTitle)
        {
            return;
        }

        public static DialogResult MessageBox(string p_strMessage, string p_strTitle, MessageBoxButtons p_mbbButtons)
        {
            return default(DialogResult);
        }

        public DialogResult ExtendedMessageBox(string p_strMessage, string p_strTitle, string p_strDetails, MessageBoxButtons p_mbbButtons, MessageBoxIcon p_mdiIcon)
        {
            return default(DialogResult);
        }

        public static int[] Select(SelectOption[] p_sopOptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }

        public static int[] Select(string[] p_strItems, string[] p_strPreviewPaths, string[] p_strDescriptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }

        public static int[] ImageSelect(string[] p_strItems, Image[] p_imgPreviews, string[] p_strDescriptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }

        public static Form CreateCustomForm()
        {
            return null;
        }

        public static Version GetModManagerVersion()
        {
            return null;
        }

        public static Version GetGameVersion()
        {
            return null;
        }

        public static string[] GetAllPlugins()
        {
            return null;
        }

        public static string[] GetActivePlugins()
        {
            return null;
        }

        public static void SetPluginActivation(string p_strPluginPath, bool p_booActivate)
        {
            return;
        }

        public static void SetPluginOrderIndex(string p_strPlugin, int p_intNewIndex)
        {
            return;
        }

        public static void SetLoadOrder(int[] p_intPlugins)
        {
            return;
        }

        public static void SetLoadOrder(int[] p_intPlugins, int p_intPosition)
        {
            return;
        }

        public static string GetIniString(string p_strSettingsFileName, string p_strSection, string p_strKey)
        {
            return default(string);
        }

        public static Int32 GetIniInt(string p_strSettingsFileName, string p_strSection, string p_strKey)
        {
            return default(Int32);
        }

        public static bool EditIni(string p_strSettingsFileName, string p_strSection, string p_strKey, string p_strValue)
        {
            return false;
        }
    }
}