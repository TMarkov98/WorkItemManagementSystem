﻿using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public abstract class Resource : IResource
    {
        private string _name;
        private List<WorkItem> _workItems = new List<WorkItem>();
        private List<string> _activityHistory = new List<string>();

        public Resource(string name, List<WorkItem> workItems, List<string> activityHistory)
        {
            this.Name = name;
            this.WorkItems = workItems;
            this.ActivityHistory = activityHistory;
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
        public virtual List<string> ActivityHistory { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name}";
        }
    }
}
