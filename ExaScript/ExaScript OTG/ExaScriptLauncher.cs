/*

 */

using System;
using Microsoft.Scripting;

namespace ExaScript_OTG
{
    public class CodeSigningException : Exception
    {
    }

    /// <summary>
    ///     ExaScript on the Fly
    /// </summary>
    public class ExaScriptLauncher
    {
        private string _code;

        public ExaScriptLauncher()
        {
            UnderlyingInstance = new ExaScriptInstance();
            UnderlyingInstance.AppendToSearchPath(Environment.CurrentDirectory);
        }

        public ExaScriptInstance UnderlyingInstance { get; set; }

        public void LoadCode(string scriptCode)
        {
            _code = scriptCode;
            UnderlyingInstance.LoadCode(_code);
        }

        public string RunCode()
        {
            try
            {
                return UnderlyingInstance.RunCode();
            }
            catch (SyntaxErrorException mse)
            {
                if (mse.Message != "unexpected EOF while parsing")
                    throw mse;
                return null;
            }
        }
    }
}