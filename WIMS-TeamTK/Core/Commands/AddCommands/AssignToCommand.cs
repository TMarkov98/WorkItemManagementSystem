using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.AddCommands
{
    public class AssignToCommand : Command
    {
        public AssignToCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string workItemTitle;
            try
            {
                if (!this._engine.Members.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Author {parameter} is not a valid member.");
                }
                var member = this._engine.Members.First(n => n.Name == parameter);
                Console.Write("WorkItem: ");
                workItemTitle = Console.ReadLine();
                if (!this._engine.WorkItems.Any(n => n.Title == workItemTitle))
                {
                    throw new ArgumentException($"WorkItem {workItemTitle} not found.");
                }
                var workItem = this._engine.WorkItems.First(n => n.Title == workItemTitle);
                if (this._engine.WorkItems.Count(n => n.Title == workItemTitle) > 1)
                {
                    Console.Write("More than one WorkItem found with this title. Please use WorkItem ID: ");
                    var workItemId = int.Parse(Console.ReadLine());
                    workItem = this._engine.WorkItems[workItemId];
                }
                member.AddWorkItem(workItem);
                if(workItem.GetType().Name == "Bug")
                {
                    (workItem as IBug).Assignee = parameter;
                }
                if (workItem.GetType().Name == "Story")
                {
                    (workItem as Story).Assignee = parameter;
                }
                return $"Assigned {workItemTitle} to {parameter}";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to assign work item to member.");
            }
        }
    }
}
