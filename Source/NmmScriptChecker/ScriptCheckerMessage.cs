using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmmScriptChecker
{
    public class ScriptCheckerMessage
    {
        public readonly string Message;

        public readonly string SolutionMessage;

        public bool HasSolutionMessage => SolutionMessage != null;

        public ScriptCheckerMessage(string errorMessage, string solutionMessage = null)
        {
            Message = errorMessage;
            SolutionMessage = solutionMessage;
        }
    }
}
