using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IAssignable
    {
        public string Assignee { get; }
    }
}
