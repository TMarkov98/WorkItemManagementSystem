using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;

namespace WIMS_TeamTK.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine().Trim();
        }
    }
}
