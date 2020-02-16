using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class Resource : IResource
    {
        protected string _name;
        private List<IWorkItem> _workItems;
        private List<string> _activityHistory = new List<string>();

        public Resource(string name)
        {
            this.Name = name;
            this.WorkItems = new List<IWorkItem>();
            this.ActivityHistory = new List<string>();
            this._activityHistory.Add($"{DateTime.UtcNow}: Created {this.GetType().Name} with name {this.Name}.");

        }

        public virtual string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                this._activityHistory.Add($"{DateTime.UtcNow}: Changed name to {value}.");
            }
        }
        public virtual List<IWorkItem> WorkItems
        {
            get
            {
                return this._workItems;
            }
            private set
            {
                this._workItems = value;
            }
        }
        public virtual List<string> ActivityHistory
        {
            get
            {
                return this._activityHistory;
            }
            private set
            {
                this._activityHistory = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name}";
        }
    }
}
