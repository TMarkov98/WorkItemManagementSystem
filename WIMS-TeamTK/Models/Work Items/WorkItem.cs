using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class WorkItem : IWorkItem
    {
        private string _title = "";
        private string _description = "";
        private readonly List<string> _history = new List<string>();
        private List<IComment> _comments = new List<IComment>();
        public WorkItem(string title, string description)
        {
            this.Title = title;
            this.History.Add($"[{DateTime.UtcNow}]: Created {this.GetType().Name} with Title {this.Title}.");
            this.Description = description;
            this.Comments = new List<IComment>();
        }

        public virtual string Title
        {
            get => this._title;
            set
            {
                this._title = value;
            }
        }
        public virtual string Description
        {
            get => this._description;
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Description to {value}.");
                this._description = value;
            }
        }
        public virtual List<string> History
        {
            get
            {
                return this._history;
            }
        }
        public List<IComment> Comments
        {
            get => this._comments;
            set
            {
                this._comments = value;
            }
        }
        public virtual string ListHistory()
        {
            string result = "";
            foreach (var data in _history)
            {
                result += $"{data}{Environment.NewLine}";
            }
            return result.Trim();
        }
        public virtual void AddComment(IComment comment)
        {
            this.Comments.Add(comment);
        }
        public override string ToString()
        {
            string result = $"Type: {this.GetType().Name}{Environment.NewLine}"
                + $"Title: {this.Title}{Environment.NewLine}"
                + $"Description: {this.Description}{Environment.NewLine}";
            return result;
        }
    }
}