using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IResource
    {
        string Name { get; }
        List<IWorkItem> WorkItems { get; }
        List<string> ActivityHistory { get; }
        string ToString();
        void AddedCommentToHistory();
        void AddedToTeamComment(Team team);
        void AddWorkItem(IWorkItem workitem);
    }
}
