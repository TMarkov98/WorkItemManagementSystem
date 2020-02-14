using System.Collections.Generic;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IBug
    {
        public List<string> StepsToReproduce { get; }
        public Priority Priority { get; }
        public Severity Severity { get; }
        public BugStatus Status { get; }
    }
}
