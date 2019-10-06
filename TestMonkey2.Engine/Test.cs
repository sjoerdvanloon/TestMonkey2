using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandRunner
{
   public class Test
    {
        public int Number { get; set; }

        public List<String> Steps { get; set; } = new List<String>();

        public void Preview()
        {
            Console.WriteLine($"Number: {Number} and {Steps.Count()} steps");
        }
    }
}
