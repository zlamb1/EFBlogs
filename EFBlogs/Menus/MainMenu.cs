using EFBlogs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogs.Menus
{
    internal class MainMenu : Menu
    {
        public MainMenu() : base()
        {
            statusMsg.ClassDir = "EFBlogs.MainMenu";
            statusMsg.MessageStatus = MsgStatus.INFO;
            statusMsg.Message = "Program started";
        }
        public override void Start()
        {
            
            // use base menu functionality
            base.Start();

            // write menu
            Console.WriteLine("Enter your selection:");
            Console.WriteLine("1) Display all blogs");
            Console.WriteLine("2) Add Blog");
            Console.WriteLine("3) Add Post");
            Console.WriteLine("4) Display Posts");
            Console.WriteLine("Enter q to quit");

            // get user input selection
            string? input = Console.ReadLine();

            if (input is null || input == "")
            {
                // restart menu
                statusMsg.MessageStatus = MsgStatus.WARNING;
                statusMsg.Message = "Your selection cannot be blank/null!";
                Start();
                return;
            }

            // exit
            if (input == "q")
            {
                return;
            }

            // check if input is an integer
            int selection = 0;
            try
            {
                selection = int.Parse(input);
            } catch (FormatException)
            {
                statusMsg.MessageStatus = MsgStatus.WARNING;
                statusMsg.Message = "Your selection must be 'q' or an integer!";
                Start();
                return;
            }

            // check if selection is one of the valid options
            if (selection < 1 || selection > 4)
            {
                statusMsg.MessageStatus = MsgStatus.WARNING;
                statusMsg.Message = "Your selection must be in the range of one to four!";
                Start();
                return;
            }

            Result = selection;

        }
    }
}
