using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
