using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogs.Utility
{
    public enum MsgStatus
    {
        INFO, WARNING, ERROR
    }

    internal class Status
    {
        public static LogLevel LogLevelConvert(MsgStatus status)
        {
            switch(status)
            {
                case MsgStatus.INFO:
                    return LogLevel.Information;
                case MsgStatus.WARNING:
                    return LogLevel.Warning;
                case MsgStatus.ERROR:
                    return LogLevel.Error;
                default:
                    return LogLevel.Information;
            }
        }

        public string? Message { get; set; }

        public string? ClassDir { get; set; }

        public MsgStatus MessageStatus { get; set; }

        public override string ToString()
        {
            return DateTime.Now.ToString() + "|" +
                MessageStatus + "|" + ClassDir + "|" + Message;
        }

    }
}
