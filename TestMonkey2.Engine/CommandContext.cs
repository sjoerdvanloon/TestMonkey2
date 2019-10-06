using System;
using System.Collections.Generic;
using System.Text;

namespace CommandRunner
{
    public class CommandContext
    {
        public List<Test> Cases { get; set; }

        public string OutputFilePath { get; set; }
        public string InputFilePath { get; set; }

        public CommandContext()
        {
            Cases = new List<Test>();
        }
    }
}
