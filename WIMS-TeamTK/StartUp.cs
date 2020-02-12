using System;
using WIMS_TeamTK.Core;

namespace WIMS_TeamTK
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // Singleton design pattern
            // Ensures that there is only one instance of Engine in existance
            // Yo are already familiar with it, right?
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
