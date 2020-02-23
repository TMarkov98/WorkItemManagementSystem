using System;
using System.Collections.Generic;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ListBugsCommand : Command
    {
        public ListBugsCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string result = string.Empty;
            List<IBug> allBugs = this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").Select(n => n as IBug).ToList();
            if(allBugs.Count == 0)
            {
                return "No bugs added.";
            }
            if (parameter == "")
            {
                result = string.Join(Environment.NewLine, allBugs
                    .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
            }
            else if (parameter.ToLower() == "sort")
            {
                Console.Write("Sort by(title/priority/severity/status): ");
                string sortedBy = Console.ReadLine().Trim().ToLower();
                switch (sortedBy)
                {
                    case "title":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Title)
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                        break;
                    case "priority":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Priority)
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                        break;
                    case "severity":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Severity)
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                        break;
                    case "status":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Status)
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                        break;
                    default:
                        throw new ArgumentException("Input is not valid parameter to be sort by.");
                }
            }
            else if (parameter.ToLower() == "filter")
            {
                Console.Write("Filter by(status/assigne): ");
                string filter = Console.ReadLine().Trim().ToLower();

                if (filter == "status")
                {
                    Console.Write("Status to filter by(active, fixed): ");
                    string filterStatus = Console.ReadLine().Trim().ToLower();
                    if (filterStatus == "active")
                    {
                        result = string.Join(Environment.NewLine, allBugs.Where(n => n.Status.Equals(BugStatus.Active))
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                    }
                    else if (filterStatus == "fixed")
                    {
                        result = string.Join(Environment.NewLine, allBugs.Where(n => n.Status.Equals(BugStatus.Fixed))
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                    }
                }
                else if(filter == "assigne")
                {
                    Console.Write("Assigne to filter by: ");
                    string filterAssignee = Console.ReadLine().Trim();
                    this._validator.ValidateMemberExists(this._engine.Members, filterAssignee);
                    result = string.Join(Environment.NewLine, allBugs.Where(n => n.Assignee.Equals(filterAssignee))
                        .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                }
                else
                {
                    throw new ArgumentException($"{filter} is not valid parameter to filter by.");
                }
            }
            return result;
        }
    }
}
