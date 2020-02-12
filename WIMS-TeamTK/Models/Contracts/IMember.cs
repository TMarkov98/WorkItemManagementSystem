using System.Collections.Generic;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IMember
    {
        // TODO : Not sure if is it right
        string Name();
        List<WorkItem> WorkItems();
        List<string> ActivityHistory();
    }
}
