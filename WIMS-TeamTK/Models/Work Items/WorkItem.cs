using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class WorkItem
    {
        private string _title;
        private string _description;

        public WorkItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
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
                this._title = value;
            }
        }
        public string Description { get => this._description; private set => this._description = value; }
    }
}
