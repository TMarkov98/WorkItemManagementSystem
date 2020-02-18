using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Models
{
    public abstract class WorkItem : IWorkItem
    {
        private string _title = "";
        private string _description = "";
        private List<string> _history = new List<string>();
        private List<Comment> _comments = new List<Comment>();

        public WorkItem(string title)
        {
            this.Title = title;
            this.History = new List<string>();
            this.Comments = new List<Comment>();
            this.History.Add($"{DateTime.UtcNow}: Created {this.GetType().Name} with Title {this.Title}.");
        }
            //TODO: Check if still necessary
        public WorkItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.History = new List<string>();
            this.Comments = new List<Comment>();
            this.History.Add($"{DateTime.UtcNow}: Created {this.GetType().Name} with Title {this.Title}.");
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
                this.History.Add($"{DateTime.UtcNow}: Changed Description to {value}.");
                this._description = value;
            }
        }
        public virtual List<string> History
        {
            get
            {
                return this._history;
            }
            set
            {
                this._history = value;
            }
        }
        public List<Comment> Comments
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
        public virtual void AddComment(Comment comment)
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
