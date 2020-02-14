using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IResource
    {
        string Name { get; }
        List<WorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }
    }
}
