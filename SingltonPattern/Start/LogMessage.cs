﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SingltonPattern.Start
{
    internal class LogMessage
    {
        public string Message { get; set; }
        public LogType LogType { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            var timestamp = CreatedAt.ToString("yyyy-MM-dd hh:mm");
            return $"{LogType.ToString().PadLeft(7, ' ')} [{timestamp}] {Message}";
        }
    }
}
