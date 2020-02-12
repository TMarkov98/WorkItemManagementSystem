using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        string StepsToReproduce();
        Priority Priority();
        Severity Severity();
        BugStatus Status();
        Member Assignee();
    }
}
