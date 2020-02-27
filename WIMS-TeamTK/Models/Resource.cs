using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class Resource : IResource
    {
        /// <summary>Name of the resource</summary>
        protected string _name;
        /// <summary>Work items of the resource</summary>
        private List<IWorkItem> _workItems;
        /// <summary>Acticity history of the resource</summary>
        protected List<string> _activityHistory = new List<string>();

        /// <summary>
        /// Constructor of Resource
        /// </summary>
        public Resource(string name)
        {
            this.Name = name;
            this.WorkItems = new List<IWorkItem>();
            this.ActivityHistory = new List<string>();
            this._activityHistory.Add($"[{DateTime.UtcNow}]: Created {this.GetType().Name} with name {this.Name}.");

        }

        /// <summary>
        /// Property of Name
        /// </summary>
        public virtual string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }

        /// <summary>
        /// Property of WorkItems
        /// </summary>
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
        
        /// <summary>
        /// Property of ActivityHistory
        /// </summary>
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

        /// <summary>
        /// Turns class Resource to string.
        /// </summary>
        /// <returns>class as string</returns>
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name}";
        }

        public void AddedToTeamComment(Team team)
        {
            this._activityHistory.Add($"[{DateTime.UtcNow}]: {this.Name} was added to {team}.");
        }
        public void AddWorkItem(IWorkItem workItem)
        {
            _workItems.Add(workItem);
            this._activityHistory.Add($"[{DateTime.UtcNow}]: Item {workItem.Title} was assigned to {this.GetType().Name} {this.Name}.");
        }
    }
}
