using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;

namespace NmmScriptChecker
{
    /// <remarks>
    /// This source code was recovered from ILSpy, so it's a bit messy.
    /// </remarks>
    public class ScriptChecker
    {
        public List<ScriptCheckerMessage> Errors = new List<ScriptCheckerMessage>();

        public List<ScriptCheckerMessage> Warnings = new List<ScriptCheckerMessage>();

        private ScriptCompiler scriptCompiler;

        public bool HasErrors => Errors.Count > 0;

        public bool HasWarnings => Warnings.Count > 0;

        public string CheckerGameContext { get; set; }

        public ScriptChecker(ScriptCompiler compiler, string context)
        {
            scriptCompiler = compiler;
            if (string.IsNullOrWhiteSpace(context))
            {
                CheckerGameContext = null;
            }
            else
            {
                CheckerGameContext = context;
            }
        }

        private void CreateErrorMessage(string errorMessage, string solutionMessage = null)
        {
            Errors.Add(new ScriptCheckerMessage(errorMessage, solutionMessage));
        }

        private void CreateWarningMessage(string warningMessage, string solutionMessage = null)
        {
            Warnings.Add(new ScriptCheckerMessage(warningMessage, solutionMessage));
        }

        public void Check(CompilerResults results)
        {
            Assembly compiledAssembly = results.CompiledAssembly;
            Type scriptClassType = compiledAssembly.GetType("Script");
            if (scriptClassType == null)
            {
                this.CreateErrorMessage("Class named \"Script\" was not found.", "Add class named \"Script\" in root namespace.");
            }
            else
            {
                object scriptInstance = compiledAssembly.CreateInstance("Script");
                if (scriptInstance == null)
                {
                    CreateErrorMessage("Cannot create \"Script\" class instance", null);
                }
                else
                {
                    if (scriptClassType.BaseType == typeof(object)
                     || scriptClassType.BaseType != this.scriptCompiler.ScriptDerivedType)
                    {
                        CreateErrorMessage("\"Script\" class doesn't inherit from \"CSharpBaseScript\" class.", null);
                    }

                    MethodInfo onActivateMethod = scriptClassType.GetMethod("OnActivate");
                    if (onActivateMethod == null)
                    {
                        onActivateMethod = scriptClassType.GetMethod("OnActivate", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (onActivateMethod == null)
                        {
                            this.CreateErrorMessage("Method named \"OnActivate\" inside \"Script\" class was not found.", "Create public method with name \"OnActivate\" inside \"Script\" class.");
                        }
                        else
                        {
                            this.CreateErrorMessage("Method named \"OnActivate\" inside \"Script\" class is not public.", "Set \"OnActivate\" access level to public.");
                        }
                    }
                    else
                    {
                        if (onActivateMethod?.ReturnType != typeof(bool))
                        {
                            this.CreateErrorMessage("Return type of \"OnActivate\" method of \"Script\" class is not \"bool\"", "Change return type of method to \"bool\" or \"Boolean\"");
                        }
                    }
                }
            }
        }
    }
}
