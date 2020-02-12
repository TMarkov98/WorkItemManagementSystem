using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Board
    {
        private string _name;
        private List<WorkItem> _workItems = new List<WorkItem>();
        private List<string> _activityHistory = new List<string>();

        public Board(string name, List<WorkItem> workItems, List<string> activityHistory)
        {
            this.Name = name;
            this.WorkItems = workItems;
            this.ActivityHistory = activityHistory;
        }

        public string Name { get; set; }
        public List<WorkItem> WorkItems { get; set; }
        public List<string> ActivityHistory { get; set; }
    }
}
