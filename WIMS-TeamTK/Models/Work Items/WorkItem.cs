using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class WorkItem : IWorkItem
    {
        /// <summary>Title of the workitem</summary>
        private string _title = "";
        /// <summary>Description of the workitem</summary>
        private string _description = "";
        /// <summary>History of the workitem</summary>
        private readonly List<string> _history = new List<string>();
        /// <summary>All comments of the workitem</summary>
        private List<IComment> _comments = new List<IComment>();

        /// <summary>
        /// Constructor of Workitem
        /// </summary>
        /// <param name="title">Title of the workitem</param>
        /// <param name="description">Descrition of the workitem</param>
        public WorkItem(string title, string description)
        {
            this.Title = title;
            this.History.Add($"[{DateTime.UtcNow}]: Created {this.GetType().Name} with Title {this.Title}.");
            this.Description = description;
            this.Comments = new List<IComment>();
        }

        /// <summary>
        /// Property of Title
        /// </summary>
        public virtual string Title
        {
            get => this._title;
            private set
            {
                this._title = value;
            }
        }

        /// <summary>
        /// Property of Description
        /// </summary>
        public virtual string Description
        {
            get => this._description;
            private set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Description to {value}.");
                this._description = value;
            }
        }
        /// <summary>
        /// Property of History
        /// </summary>
        public virtual List<string> History
        {
            get
            {
                return this._history;
            }
        }

        /// <summary>
        /// Property of the Comments
        /// </summary>
        public List<IComment> Comments
        {
            get => this._comments;
            set
            {
                this._comments = value;
            }
        }

        /// <summary>
        /// Method to add comment to the work item
        /// </summary>
        /// <param name="comment"></param>
        public virtual void AddComment(IComment comment)
        {
            this.Comments.Add(comment);
        }

        /// <summary>
        /// Method to list history of the work item
        /// </summary>
        /// <returns>string with history</returns>
        public virtual string ListHistory()
        {
            string result = "";
            foreach (var data in _history)
            {
                result += $"{data}{Environment.NewLine}";
            }
            return result.Trim();
        }

        /// <summary>
        /// Turns class WorkItem to string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string result = $"Type: {this.GetType().Name}{Environment.NewLine}"
                + $"Title: {this.Title}{Environment.NewLine}"
                + $"Description: {this.Description}{Environment.NewLine}";
            return result;
        }
    }
}