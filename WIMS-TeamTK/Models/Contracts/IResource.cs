using System.Collections.Generic;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IResource
    {
        // Properties
        string Name { get; }
        List<IWorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }
        // Methods
        string ToString();
        void AddedToTeamComment(Team team);
        void AddWorkItem(IWorkItem workitem);
    }
}
