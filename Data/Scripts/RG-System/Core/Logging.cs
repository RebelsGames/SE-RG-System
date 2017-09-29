using System;
using System.IO;
using System.Text;
using Sandbox.ModAPI;

namespace szczepix.RGSystem.Core
{
    internal class Logging
    {
        private static Logging _instance;
        private static int lineCount;
        private static bool init;
        private static readonly string[] log = new string[10];
        private readonly StringBuilder _cache = new StringBuilder();
        private readonly TextWriter _writer;
        private int _indent;
        private static readonly string LogFileName = RGSystem.Name;

        private Logging(string logFile)
        {
            logFile += ".log";
            _writer = MyAPIGateway.Utilities.WriteFileInLocalStorage(logFile, typeof(Logging));
            _instance = this;
        }

        public static Logging Instance
        {
            get
            {
                if (MyAPIGateway.Utilities == null)
                {
                    return null;
                }

                return _instance ?? (_instance = new Logging(Logging.LogFileName));
            }
        }

        public void IncreaseIndent()
        {
            _indent++;
        }

        public void DecreaseIndent()
        {
            if (_indent > 0)
                _indent--;
        }

        public void WriteLine(object o)
        {
            WriteLine("[Object]: " + o.ToString());
        }

        public void WriteLine(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Error Message]: " + ex.Message + "\n");
            sb.Append("[Error StackTrace]: " + ex.StackTrace + "\n");
            sb.Append("[Error Source]: " + ex.Source + "\n");
            WriteLine(sb.ToString());
            sb.Clear();
        }

        public void WriteLine(string text)
        {

                if (_cache.Length > 0)
                    _writer.WriteLine(_cache);

                _cache.Clear();
                _cache.Append(DateTime.Now.ToString("[HH:mm:ss:ffff] "));
                for (var i = 0; i < _indent; i++)
                    _cache.Append("\t");

                _writer.WriteLine(_cache.Append(text));
                _writer.Flush();
                _cache.Clear();
            
        }

        public void WriteDebug(string text)
        {
            if (ErrorHandler.Debug)
                WriteLine(text);
        }

        public void Debug_obj(string text)
        {
            if (!ErrorHandler.Debug)
                return;

            WriteLine("\tDEBUG_OBJ: " + text);

            //server can't show objectives. probably.
            if (MyAPIGateway.Session.Player == null)
                return;

            //I'm the only one that needs to see this
            if (MyAPIGateway.Session.Player.SteamUserId != 76561198019800973)
                return;

            text = $"{DateTime.Now.ToString("[HH:mm:ss:ffff]")}: {text}";

            if (!init)
            {
                init = true;
                MyAPIGateway.Utilities.GetObjectiveLine().Title = "Link debug";
                MyAPIGateway.Utilities.GetObjectiveLine().Objectives.Clear();
                MyAPIGateway.Utilities.GetObjectiveLine().Objectives.Add("Start");
                MyAPIGateway.Utilities.GetObjectiveLine().Show();
            }
            if (lineCount > 9)
                lineCount = 0;
            log[lineCount] = text;
            string[] oldLog = log;
            for (var i = 0; i < 9; i++)
                log[i] = oldLog[i + 1];
            log[9] = text;

            MyAPIGateway.Utilities.GetObjectiveLine().Objectives[0] = string.Join("\r\n", log);
            lineCount++;
        }

        public void Write(string text)
        {
            _cache.Append(text);
        }

        internal void Close()
        {
            if (_cache.Length > 0)
                _writer.WriteLine(_cache);

            _writer.Flush();
            _writer.Close();
        }
    }
}