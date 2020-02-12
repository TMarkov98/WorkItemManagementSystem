using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;

namespace WIMS_TeamTK.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
