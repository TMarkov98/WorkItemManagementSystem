using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Story : WorkItem
    {
        public Story(string title, string description) : base(title, description)
        {
        }
    }
}
