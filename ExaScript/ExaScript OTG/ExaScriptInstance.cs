using System.IO;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace ExaScript_OTG
{
    public class ExaScriptInstance
    {
        private CompiledCode _compiled;
        private object _pythonClass;

        public ExaScriptInstance()
        {
            //creating engine and stuff
            Engine = Python.CreateEngine();
            Scope = Engine.CreateScope();
        }

        public ScriptEngine Engine { get; }

        public ScriptScope Scope { get; }

        public ScriptSource Source { get; private set; }

        public string RunCode()
        {
            string ret = null;
            using (var ms = new MemoryStream())
            {
                using (var tw = new StreamWriter(ms, Encoding.UTF8))
                {
                    Engine.Runtime.IO.SetOutput(ms, tw);
                    Engine.Runtime.IO.SetOutput(ms, tw);
                    Source.Execute(Scope);
                    ms.Position = 0;
                    TextReader reader = new StreamReader(ms, Encoding.UTF8);
                    ret = reader.ReadToEnd();
                }
            }
            return ret;
        }

        public void LoadCode(string code)
        {
            Source = Engine.CreateScriptSourceFromString(code, SourceCodeKind.Statements);
            Source.Compile();
        }

        public void AppendToSearchPath(string path)
        {
            var paths = Engine.GetSearchPaths();
            paths.Add(path);
            Engine.SetSearchPaths(paths);
        }

        public void CompileCodeFromClass(string code, string className)
        {
            //loading and compiling code
            Source = Engine.CreateScriptSourceFromString(code, SourceCodeKind.Statements);
            _compiled = Source.Compile();

            //now executing this code (the code should contain a class)
            _compiled.Execute(Scope);

            //now creating an object that could be used to access the stuff inside a python script
            _pythonClass = Engine.Operations.Invoke(Scope.GetVariable(className));
        }

        public void SetVariable(string variable, dynamic value)
        {
            Scope.SetVariable(variable, value);
        }

        public dynamic GetVariable(string variable)
        {
            return Scope.GetVariable(variable);
        }

        public void CallMethod(string method, params dynamic[] arguments)
        {
            Engine.Operations.InvokeMember(_pythonClass, method, arguments);
        }

        public dynamic CallFunction(string method, params dynamic[] arguments)
        {
            return Engine.Operations.InvokeMember(_pythonClass, method, arguments);
        }
    }
}