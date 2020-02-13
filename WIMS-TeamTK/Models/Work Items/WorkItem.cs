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
        private ulong _id = 0;

        public WorkItem(string title, string description)
        {
            _history.Add($"{DateTime.Now}: Created {this.GetType().Name}.");
            this.Title = title;
            this.Description = description;
            this._id++;
        }

        public string Title
        {
            get => this._title;
            set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException();
                }
                this._history.Add($"{DateTime.Now}: Modified Title from {this.Title} to {value}.");
                this._title = value;
            }
        }
        public string Description
        {
            get => this._description;
            set
            {
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException();
                }
                this._history.Add($"{DateTime.Now}: Modified Description from {this.Description} to {value}.");
                this._description = value;
            }
        }
        public string ListHistory() 
        {
            string result = "";
            foreach (var data in _history)
            {
                result += $"{data}\n";
            }
            return result.Trim();
        }
    }
}
