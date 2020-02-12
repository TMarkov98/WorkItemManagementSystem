using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Bug : WorkItem
    {
        public Bug(string title, string description) : base(title, description)
        {
        }
    }
}
