using System.Collections.Generic;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IResource
    {
        string Name { get; }
        List<IWorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }
        string ToString();
        void AddedToTeamComment(Team team);
        void AddWorkItem(IWorkItem workitem);
    }
}
