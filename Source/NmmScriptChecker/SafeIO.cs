using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NmmScriptChecker
{
    public static class SafeIO
    {
        static int maxAttempts = 4;

        public static string ReadAllText(string path)
        {
            string text = null;
            int attempts = 0;

            while (true)
            {
                try
                {
                    text = File.ReadAllText(path);
                    return text;
                }
                catch (IOException)
                {
                    if (attempts >= maxAttempts)
                        throw;
                    attempts++;
                    Thread.Sleep(75);
                }
            }
        }
    }
}
