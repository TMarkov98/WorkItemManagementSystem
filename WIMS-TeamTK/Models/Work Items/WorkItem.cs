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
        private ulong _id = 1;

        public WorkItem(string title)
        {
            this.Title = title;
            this._id++;
            this.History = new List<string>();
            this.Comments = new List<Comment>();
            this.History.Add($"{DateTime.Now}: Created {this.GetType().Name} with ID {this._id}.");
        }
            //TODO: Check if still necessary
        public WorkItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this._id++;
            this.History = new List<string>();
            this.Comments = new List<Comment>();
            this.History.Add($"{DateTime.Now}: Created {this.GetType().Name} with ID {this._id}.");
        }

        public virtual string Title
        {
            get => this._title;
            set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException("Title must be between 10 and 50 symbols.");
                }
                this.History.Add($"{DateTime.Now}: Changed Title to {value}.");
                this._title = value;
            }
        }
        public virtual string Description
        {
            get => this._description;
            set
            {
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException("Description must be between 10 and 500 symbols.");
                }
                this.History.Add($"{DateTime.Now}: Changed Description to {value}.");
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
        public virtual ulong Id 
        {
            get
            {
                return this._id;
            }
        }
        public virtual void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }
        public override string ToString()
        {
            string result = $"Type: {this.GetType().Name} ID: {this.Id}{Environment.NewLine}"
                + $"Title: {this.Title}{Environment.NewLine}"
                + $"Description: {this.Description}{Environment.NewLine}";
            return result;
        }
    }
}
