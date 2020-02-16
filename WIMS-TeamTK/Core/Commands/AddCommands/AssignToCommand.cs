using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.AddCommands
{
    public class AssignToCommand : Command
    {
        public AssignToCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string workItem;
            try
            {
                if (!this._engine.Members.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Author {parameter} is not a valid member.");
                }
                var member = this._engine.Members.First(n => n.Name == parameter);
                Console.WriteLine("WorkItem:");
                workItem = Console.ReadLine();
                if (this._engine.WorkItems.Count(n => n.Title == workItem) > 1)
                {
                    Console.Write("More than one WorkItem found with this title. Please use WorkItem ID: ");
                    var workItemId = int.Parse(Console.ReadLine());
                    member.AssigneWorkItem(this._engine.WorkItems[workItemId]);
                }
                else if (this._engine.WorkItems.Count((n => n.Title == workItem)) < 1)
                {
                    throw new ArgumentException($"WorkItem {workItem} not found.");
                }
                else
                {
                    member.AssigneWorkItem(this._engine.WorkItems.First(n => n.Title == workItem));
                }
                return $"Assigned {workItem} to {parameter}";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}{Environment.NewLine}Unable to assign work item to member.");
            }
        }
    }
}
