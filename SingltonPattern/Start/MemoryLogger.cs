using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingltonPattern.Start
{
    internal class MemoryLogger
    {
       
        private static readonly object _Lock = new object();
        private MemoryLogger _instance = new MemoryLogger(); //Eager loading..
        private int _InfoCount;
        private int _WarnCount;
        private int _ErrorCount;

        private List<LogMessage> _Logs = new List<LogMessage>();
        public IReadOnlyCollection<LogMessage> Logs => _Logs;
       

        private MemoryLogger()
        {
            
        }

        public MemoryLogger GetLogger
        {
            get
            {
                return _instance;

            }
               
            
        }
        private void Log(string message, LogType logType) =>
            _Logs.Add(new LogMessage
            {
                Message = message,
                LogType = logType,
                CreatedAt = DateTime.Now
            });

        public void LogInfo(string message)
        {
            ++_InfoCount;
            Log(message, LogType.INFO);
        }

        public void LogError(string message)
        {
            ++_ErrorCount;
            Log(message, LogType.ERROR);
        }

        public void LogWarning(string message)
        {
            ++_WarnCount;
            Log(message, LogType.WARNING);
        }


        public void ShowLog()
        {
            _Logs.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"------------------------------");
            Console.WriteLine($"Info({_InfoCount}), Warning ({_WarnCount}), Error({_ErrorCount})");
        }
    }
}
