using System;
using Nexus.Client.ModManagement.Scripting.CSharpScript;

namespace Nexus.Client.Games.Fallout3.Scripting.CSharpScript
{
    public abstract class FalloutCSharpBaseScript : CSharpBaseScript
    {
        public static bool InstallFileFromFomod(string p_strFrom, string p_strTo)
        {
            return false;
        }

        public static bool InstallFileFromFomod(string p_strFile)
        {
            return false;
        }

        public static byte[] GetFileFromFomod(string p_strFile)
        {
            return null;
        }
        
        public static string[] GetFomodFileList()
        {
            return null;
        }
        
        public static Version GetFommVersion()
        {
            return null;
        }

        
        
        
        
        
        public static Version GetFalloutVersion()
        {
            return null;
        }

        
        
        
        
        public static bool ScriptExtenderPresent()
        {
            return false;
        }

        

        

        
        
        
        
        
        public static string[] GetBSAFileList(string p_strBsa)
        {

            return null;
        }

        
        
        
        
        
        
        public static byte[] GetDataFileFromBSA(string p_strBsa, string p_strFile)
        {
            return null;
        }

        

        

        

        
        
        
        
        
        
        
        public static string GetFalloutIniString(string p_strSection, string p_strKey)
        {
            return null;
        }

        
        
        
        
        
        
        public static int GetFalloutIniInt(string p_strSection, string p_strKey)
        {
            return 0;
        }

        
        
        
        
        
        
        
        public static string GetPrefsIniString(string p_strSection, string p_strKey)
        {
            return null;
        }

        
        
        
        
        
        
        
        public static int GetPrefsIniInt(string p_strSection, string p_strKey)
        {
            return 0;
        }

        
        
        
        
        
        
        
        public static string GetGeckIniString(string p_strSection, string p_strKey)
        {
            return null;
        }

        
        
        
        
        
        
        
        public static int GetGeckIniInt(string p_strSection, string p_strKey)
        {
            return 0;
        }

        
        
        
        
        
        
        
        public static string GetGeckPrefsIniString(string p_strSection, string p_strKey)
        {
            return null;
        }

        
        
        
        
        
        
        
        public static int GetGeckPrefsIniInt(string p_strSection, string p_strKey)
        {
            return 0;
        }

        

        

        
        
        
        
        
        
        
        
        
        public static bool EditFalloutINI(string p_strSection, string p_strKey, string p_strValue, bool p_booSaveOld)
        {
            return false;
        }

        
        
        
        
        
        
        
        
        
        public static bool EditPrefsINI(string p_strSection, string p_strKey, string p_strValue, bool p_booSaveOld)
        {
            return false;
        }

        
        
        
        
        
        
        
        
        
        public static bool EditGeckINI(string p_strSection, string p_strKey, string p_strValue, bool p_booSaveOld)
        {
            return false;
        }

        
        
        
        
        
        
        
        
        
        public static bool EditGeckPrefsINI(string p_strSection, string p_strKey, string p_strValue, bool p_booSaveOld)
        {
            return false;
        }

        

        

        

        
        
        
        
        
        
        public static string GetRendererInfo(string p_strValue)
        {
            return null;
        }

        
        
        
        
        
        public static bool IsAIActive()
        {
            return false;
        }

        

        

        
        
        
        
        
        
        
        
        public static bool EditShader(int p_intPackage, string p_strShaderName, byte[] p_bteData)
        {
            return false;
        }

        

        

        
        
        
        
        public static void SetupScriptCompiler(TesPlugin[] p_plgPlugins)
        {
        }

        
        
        
        public static void CompileResultScript(SubRecord sr, out Record r2, out string msg)
        {
            r2 = null;
            msg = null;
        }

        
        
        
        public static void CompileScript(Record r2, out string msg)
        {
            msg = null;
        }

        

        

        

        
        
        
        
        
        public static bool IsLoadOrderAutoSorted()
        {
            return false;
        }

        public static int GetAutoInsertionPoint(string p_strPlugin)
        {
            return 0;
        }

        public static void AutoSortPlugins(string[] p_strPlugins)
        {
        }
    }
}
