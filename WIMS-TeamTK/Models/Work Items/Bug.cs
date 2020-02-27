using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Bug : WorkItem, IBug, IAssignable
    {
        /// <summary>Steps to reproduce the bug(with strings)</summary>
        private List<string> _stepsToReproduce = new List<string>();
        /// <summary>Enum with priority</summary>
        private Priority _priority;
        /// <summary>Enum with severity</summary>
        private Severity _severity;
        /// <summary>Enum with status</summary>
        private BugStatus _status;
        /// <summary>name of the assigned member to this bug
        private string _assignee = string.Empty;

        /// <summary>
        /// Constructor of Bug
        /// </summary>
        /// <param name="title">Title of Bug</param>
        /// <param name="description">Description of the bug</param>
        /// <param name="stepsToReproduce">Steps to reproduce the bug</param>
        /// <param name="priority">Priority of the bug</param>
        /// <param name="severity">Severity of the bug</param>
        /// <param name="status">Status of the bug</param>
        public Bug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status)
            : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = status;
        }

        /// <summary>
        /// Property of StepsToReproduce
        /// </summary>
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

        /// <summary>
        /// Property of Priority
        /// </summary>
        public Priority Priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Priority to {value}.");
                this._priority = value;
            }
        }

        /// <summary>
        /// Property of Severity
        /// </summary>
        public Severity Severity
        {
            get
            {
                return this._severity;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Severity to {value}.");
                this._severity = value;
            }
        }

        /// <summary>
        /// Property of Status
        /// </summary>
        public BugStatus Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Status to {value}.");
                this._status = value;
            }
        }

        /// <summary>
        /// Property of Assignee
        /// </summary>
        public string Assignee
        {
            get => this._assignee;
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Assignee to {value}.");
                this._assignee = value;
            }
        }

        /// <summary>
        /// Turns class Bug to string.
        /// </summary>
        /// <returns>class to string</returns>
        public override string ToString()
        {
            string result = base.ToString()
                + $"Steps to Reproduce:{Environment.NewLine}{string.Join(Environment.NewLine, this.StepsToReproduce)}{Environment.NewLine}"
                + $"Priority: {this.Priority}{Environment.NewLine}"
                + $"Severity: {this.Severity}{Environment.NewLine}"
                + $"Status: {this.Status}{Environment.NewLine}";
            if (this.Assignee == string.Empty)
            {
                result += "Not assigned.";
            }
            else
            {
                result += $"Assignee: {this.Assignee}";
            }
            return result;
        }
    }
}
