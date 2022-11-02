using Castle.Core.Logging;
using EFBlogs.Interfaces;
using EFBlogs.Utility;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace EFBlogs.Menus
{
    internal class Menu : IMenu
    {
        // arbitary limit to prevent stack overflows
        private static readonly int RESTART_LIMIT = 10;

        public int Result { get; set; }

        protected Status statusMsg { get; set; }

        private ILogger<IMenu> logger;
        private int numOfStarts;

        public Menu(ILogger<IMenu> _logger)
        {
            Result = 0;
            statusMsg = new Status();
            logger = _logger;
        }

        protected virtual void ChangeStatus(string msg, MsgStatus status = MsgStatus.INFO)
        {
            statusMsg.MessageStatus = status;
            statusMsg.Message = msg;
        }

        // by default the status is changed to a warning when a restart happens
        protected virtual void Restart(string msg, MsgStatus status = MsgStatus.WARNING)
        {
            ChangeStatus(msg, status);
            Start();
            return;
        }

        protected virtual void WaitForInput(string msg)
        {
            Console.WriteLine();
            Console.Write(msg + " ");
            Console.ReadLine();
        }

        public virtual void Start()
        {

            // boilerplate code for all menus
            numOfStarts++;
            Console.Clear();
            
            if (numOfStarts > RESTART_LIMIT)
            {
                ChangeStatus("You have restarted the menu too many times!", MsgStatus.ERROR);
                Console.WriteLine(statusMsg);
                return;
            }

            logger.LogInformation(statusMsg.Message);
            // sleep so that logger always logs before Console.WriteLine
            Thread.Sleep(10);
            Console.WriteLine(statusMsg);

        }

    }
}
