using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
