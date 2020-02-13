using System.Collections.Generic;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IBoard
    {
        string Name { get; }
        List<WorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }       
    }
}
