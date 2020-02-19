using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Story : WorkItem, IStory, IAssignable
    {
        private Priority _priority;
        private Size _size;
        private StoryStatus _status;
        private string _assignee;

        public Story(string title)
            : base(title)
        {

        }

        public Story(string title, string description, Priority priority, Size size, StoryStatus status) : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
        }

        public Priority Priority
        {
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

        public Size Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this.History.Add($"{DateTime.UtcNow}: Changed Size to {value}.");
                this._size = value;
            }
        }

        public StoryStatus Status
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

        public StoryStatus StoryStatus { get; internal set; }

        public override string ToString()
        {
            string result = base.ToString()
                + $"Priority: {this.Priority}{Environment.NewLine}"
                + $"Size: {this.Size}{Environment.NewLine}"
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
