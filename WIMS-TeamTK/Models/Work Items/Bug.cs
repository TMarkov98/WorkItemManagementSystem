

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
        private Priority _priority;
        private Severity _severity;
        private BugStatus _status;

        public Bug(string title)
            : base(title)
        {
        }

        public Bug(string title, string description, List<string> stepsToReproduce)
            : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
        }

        public List<string> StepsToReproduce
        {
            get
            {
                return this._stepsToReproduce;
            }
            set
            {
                this._stepsToReproduce = value;
            }
        }

        public Priority Priority {
            get
            {
                return this._priority;
            }
            set
            {
                this.History.Add($"{DateTime.Now}: Modified Priority from {this.Priority} to {value}.");
                this._priority = value;
            } 
        }

        public Severity Severity {
            get
            {
                return this._severity;
            }
            set
            {
                this.History.Add($"{DateTime.Now}: Modified Severity from {this.Severity} to {value}.");
                this._severity = value;
            }
        }

        public BugStatus Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this.History.Add($"{DateTime.Now}: Modified Status from {this.Status} to {value}.");
                this._status = value;
            }
        }

        public string Assignee
        {
            get => this._assignee;
            set
            {
                this.History.Add($"{DateTime.Now}: Modified Assignee from {this.Assignee} to {value}.");
                this._assignee = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() 
                + $"Steps to Reproduce:{Environment.NewLine} {string.Join(Environment.NewLine, this.StepsToReproduce)}{Environment.NewLine}"
                + $"Priority: {this.Priority}{Environment.NewLine}"
                + $"Severity {this.Severity}{Environment.NewLine}"
                + $"Status {this.Status}{Environment.NewLine}"
                + $"Assignee {this.Assignee}";
        }
    }
}
