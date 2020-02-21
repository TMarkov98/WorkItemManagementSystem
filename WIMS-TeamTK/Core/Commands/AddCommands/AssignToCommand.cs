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
            string memberName;
            string workItemTitle;
            try
            {
                memberName = parameter.Trim();
                var member = this._validator.ValidateMemberExists(this._engine.Members, memberName);
                Console.Write("WorkItem: ");
                workItemTitle = Console.ReadLine();
                var workItem = this._validator.ValidateWorkItemExists(this._engine.WorkItems, workItemTitle);
                workItem = this._validator.ValidateMoreThanOneWorkItem(this._engine.WorkItems, workItemTitle);
                member.AddWorkItem(workItem);
                if(workItem.GetType().Name == "Bug")
                {
                    (workItem as IBug).Assignee = memberName;
                }
                if (workItem.GetType().Name == "Story")
                {
                    (workItem as Story).Assignee = memberName;
                }
                return $"Assigned {workItemTitle} to {memberName}";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to assign work item to member.");
            }
        }
    }
}
