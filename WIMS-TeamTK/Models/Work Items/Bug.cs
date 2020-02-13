

using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Bug : WorkItem, IBug, IAssignable
    {
        private string _assignee;
        private List<string> _stepsToReproduce = new List<string>();
        public Bug(string title, string description, List<string> stepsToReproduce) : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
        }

        public List<string> StepsToReproduce
        {
            get => this._stepsToReproduce;
            set
            {
                this._stepsToReproduce = value;
            }
        }

        public Priority Priority { get; set; }

        public Severity Severity { get; set; }

        public BugStatus Status { get; set; }

        public string Assignee
        {
            get => this._assignee;
            set
            {
                this._assignee = value;
            }
        }
    }
}
