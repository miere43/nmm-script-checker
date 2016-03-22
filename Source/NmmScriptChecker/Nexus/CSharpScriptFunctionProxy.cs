using System;
using System.Collections.Generic;
using System.Drawing;

namespace Nexus.Client.ModManagement.Scripting.CSharpScript
{
    public class CSharpScriptFunctionProxy : ScriptFunctionProxy
    {
        public CSharpScriptFunctionProxy(IMod p_modMod, IGameMode p_gmdGameMode, IEnvironmentInfo p_eifEnvironmentInfo, InstallerGroup p_igpInstallers, UIUtil p_uipUIProxy)
            : base(p_modMod, p_gmdGameMode, p_eifEnvironmentInfo, p_igpInstallers, p_uipUIProxy)
        {
        }

        public bool CopyDataFile(string p_strFrom, string p_strTo)
        {
            return false;
        }

        public int[] Select(SelectOption[] p_sopOptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }

        public int[] Select(string[] p_strItems, string[] p_strPreviewPaths, string[] p_strDescriptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }

        public int[] Select(string[] p_strItems, Image[] p_imgPreviews, string[] p_strDescriptions, string p_strTitle, bool p_booSelectMany)
        {
            return null;
        }
    }
}