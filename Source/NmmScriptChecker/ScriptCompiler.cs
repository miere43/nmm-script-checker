using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;
using Nexus.Client.ModManagement.Scripting.CSharpScript;
using System.Reflection;
using System.Text.RegularExpressions;
using Nexus.Client.Games.FalloutNV.Scripting.CSharpScript;
using Nexus.Client.Games.Fallout3.Scripting.CSharpScript;
using Nexus.Client.Games.Fallout4.Scripting.CSharpScript;
using Nexus.Client.Games.Skyrim.Scripting.CSharpScript;

namespace NmmScriptChecker
{
    public class ScriptCompiler
    {
        static Regex scriptClassRegex = new Regex(@"(class\s+Script\s*:.*?)(\S*BaseScript)");
        static Regex usingFommRegex = new Regex(@"\s*using\s*fomm.Scripting\s*;");

        public CompilerResults Results { get; private set; }

        public Type ScriptDerivedType { get; private set; }

        public ScriptCompiler()
        {
        }

        public bool CompileFile(string path)
        {
            return CompileCode(SafeIO.ReadAllText(path));
        }

        public bool CompileCode(string code)
        {
            string baseScriptClassName = scriptClassRegex.Match(code).Groups[2].ToString().Trim();
            Type baseScriptType;

            if (baseScriptClassName == "FalloutNewVegasBaseScript"
             || baseScriptClassName == "FalloutNVBaseScript"
             || baseScriptClassName == "FalloutNewVegasCSharpBaseScript"
             || baseScriptClassName == "FalloutNVCSharpBaseScript")
            {
                baseScriptType = typeof(FalloutNVCSharpBaseScript);
            }
            else if (baseScriptClassName == "Fallout3BaseScript"
                  || baseScriptClassName == "Fallout3CSharpBaseScript")
            {
                baseScriptType = typeof(Fallout3CSharpBaseScript);
            }
            else if (baseScriptClassName == "Fallout4BaseScript"
                  || baseScriptClassName == "Fallout4CSharpBaseScript")
            {
                baseScriptType = typeof(Fallout4CSharpBaseScript);
            }
            else if (baseScriptClassName == "SkyrimBaseScript"
                  || baseScriptClassName == "SkyrimCSharpBaseScript")
            {
                baseScriptType = typeof(SkyrimCSharpBaseScript);
            }
            else
            {
                baseScriptType = typeof(CSharpBaseScript);
            }

            ScriptDerivedType = baseScriptType;

            // import script namespace
            code = scriptClassRegex.Replace(code, $"using {baseScriptType.Namespace};\r\n$1{baseScriptType.Name}");

            Regex otherScriptClasses = new Regex(@"(class\s+\S+\s*:.*?)(?<!\w)" + baseScriptClassName);

            code = otherScriptClasses.Replace(code, "$1" + baseScriptType.Name);

            // getting rid of obsolete "using fomm.Scripting" code.
            code = usingFommRegex.Replace(code, "");

            Dictionary<string, string> providerOptions = new Dictionary<string, string>();
            providerOptions["CompilerVersion"] = "v4.0";

            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            parameters.OutputAssembly = System.IO.Path.GetTempFileName();
            parameters.IncludeDebugInformation = true;

            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.dll");

            HashSet<string> scriptAssemblies = new HashSet<string>();
            scriptAssemblies.Add(Assembly.GetAssembly(baseScriptType).Location);

            foreach (string reference in scriptAssemblies)
                parameters.ReferencedAssemblies.Add(reference);
            
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
            Results = results;
            return !results.Errors.HasErrors;
        }
    }
}
