using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Board : Resource, IBoard
    {
        public Board(string name, List<WorkItem> workItems, List<string> activityHistory)
            : base(name, workItems, activityHistory)
        {
        }
    }
}
