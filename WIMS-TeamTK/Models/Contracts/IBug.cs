using System.Collections.Generic;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        public List<string> StepsToReproduce();
        public Priority Priority();
        public Severity Severity();
        public BugStatus Status();
        public string Assignee();
    }
}
