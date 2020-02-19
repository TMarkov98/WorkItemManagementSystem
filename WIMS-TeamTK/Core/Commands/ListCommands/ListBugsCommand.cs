using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
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
                result = string.Join(Environment.NewLine, this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").Select((workItem, index) => $"ID: {index} - {workItem.ToString()}").ToArray());
            }
            else if (parameter.ToLower() == "sort")
            {
                Console.Write("Sort by(title/priority/severity/status): ");
                string sortedBy = Console.ReadLine().ToLower();
                switch (sortedBy)
                {
                    case "title":
                        result = string.Join(Environment.NewLine, this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").OrderBy(n => n.Title));
                        break;
                    case "priority":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Priority));
                        break;
                    case "severity":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Severity));
                        break;
                    case "status":
                        result = string.Join(Environment.NewLine, allBugs.OrderBy(n => n.Status));
                        break;
                    default:
                        throw new ArgumentException("Input is not valid parameter to be sort by.");
                }
            }
            else if (parameter.ToLower() == "filter")
            {
                Console.WriteLine("Filter by(status/assigne): ");
                string filter = Console.ReadLine().ToLower();

                if (filter == "status")
                {
                    Console.WriteLine("Status to filter by(active, fixed): ");
                    string filterStatus = Console.ReadLine().ToLower();
                    if (filterStatus == "active")
                    {
                        result = string.Join(Environment.NewLine, allBugs.Where(n => n.Status.Equals(BugStatus.Active)));
                    }
                    else if (filterStatus == "fixed")
                    {
                        result = string.Join(Environment.NewLine, allBugs.Where(n => n.Status.Equals(BugStatus.Fixed)));
                    }
                }
                else if(filter == "assigne")
                {
                    Console.WriteLine("Assigne to filter by: ");
                    string filterAssigne = Console.ReadLine();
                    this._validator.ValidateMemberExists(this._engine.Members, filterAssigne);
                    result = string.Join(Environment.NewLine, allBugs.Where(n => n.Assignee.Equals(filterAssigne)));
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
