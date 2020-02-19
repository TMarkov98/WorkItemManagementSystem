

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

        public Bug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status)
            : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = status;
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
                this.History.Add($"{DateTime.UtcNow}: Changed Priority to {value}.");
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
                this.History.Add($"{DateTime.UtcNow}: Changed Severity to {value}.");
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
                this.History.Add($"{DateTime.UtcNow}: Changed Status to {value}.");
                this._status = value;
            }
        }

        public string Assignee
        {
            get => this._assignee;
            set
            {
                this.History.Add($"{DateTime.UtcNow}: Changed Assignee to {value}.");
                this._assignee = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString()
                + $"Steps to Reproduce:{Environment.NewLine}{string.Join(Environment.NewLine, this.StepsToReproduce)}{Environment.NewLine}"
                + $"Priority: {this.Priority}{Environment.NewLine}"
                + $"Severity: {this.Severity}{Environment.NewLine}"
                + $"Status: {this.Status}{Environment.NewLine}";
            if(this.Assignee == string.Empty)
            {
                result += "Not assigned.";
            }
            else {
                result += $"Assignee: {this.Assignee}";
            }
            return result;
        }
    }
}
