using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class WorkItem : IWorkItem
    {
        private string _title;
        private string _description;
        private List<string> _history;
        private ulong _id = 1;

        public WorkItem(string title, string description)
        {
            this.History.Add($"{DateTime.Now}: Created {this.GetType().Name} with ID {this._id}.");
            this.Title = title;
            this.Description = description;
            this._id++;
        }

        public virtual string Title
        {
            get => this._title;
            set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException();
                }
                this.History.Add($"{DateTime.Now}: Modified Title from {this.Title} to {value}.");
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
                    throw new ArgumentException();
                }
                this.History.Add($"{DateTime.Now}: Modified Description from {this.Description} to {value}.");
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
        public virtual string ListHistory() 
        {
            string result = "";
            foreach (var data in _history)
            {
                result += $"{data}\n";
            }
            return result.Trim();
        }
        public virtual ulong ID { get; }
        public override string ToString()
        {
            string result = $"Type: {this.GetType().Name} ID: {this.ID}{Environment.NewLine}"
                + $"Title: {this.Title}{Environment.NewLine}"
                + $"Description: {this.Description}{Environment.NewLine}";
            return result;
        }
    }
}
