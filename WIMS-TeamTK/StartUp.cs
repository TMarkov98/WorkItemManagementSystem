using System;
using WIMS_TeamTK.Core;

namespace WIMS_TeamTK
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Type \"help\" for a list of commands.");
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
