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
                this.History.Add($"{DateTime.Now}: Modified Priority from {this.Priority} to {value}.");
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
                this.History.Add($"{DateTime.Now}: Modified Size from {this.Size} to {value}.");
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
                this.History.Add($"{DateTime.Now}: Modified Status from {this.Status} to {value}.");
                this._status = value;
            }
        }

        public string Assignee
        {
            get
            {
                return this._assignee;
            }
            set
            {
                this.History.Add($"{DateTime.Now}: Modified Assignee from {this.Assignee} to {value}.");
                this._assignee = value;
            }
        }
    }
}
