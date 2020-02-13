using System.Collections.Generic;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IMember
    {
        // TODO : Not sure if is it right
        string Name { get; }
        List<WorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }
    }
}
