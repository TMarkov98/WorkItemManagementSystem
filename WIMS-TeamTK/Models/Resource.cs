using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class Resource : IResource
    {
        protected string _name;
        private List<WorkItem> _workItems;
        private List<string> _activityHistory;

        public Resource(string name)
        {
            this.Name = name;
            this.WorkItems = new List<WorkItem>();
            this.ActivityHistory = new List<string>();
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
            }
        }
        public virtual List<WorkItem> WorkItems 
        {
            get
            {
                return this._workItems;
            }
            set
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
            set
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
