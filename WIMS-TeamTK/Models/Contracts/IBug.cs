using System.Collections.Generic;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        // Properties
        public List<string> StepsToReproduce { get; }
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
        public BugStatus Status { get; set; }
        public string Assignee { get; set; }
    }
}
