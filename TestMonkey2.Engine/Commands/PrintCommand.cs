using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommandRunner.Commands
{
    class PrintCommand : CommandBase, ICommand
    {
        string ICommand.FriendlyName => "Print something";
        public string Text { get; set; } = "Something";

        public PrintCommand(CommandContext context) : base(context) { }

        public bool Go()
        {
            Console.WriteLine(Text);

            return true;
        }
    }
}
