using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using System.Linq;

namespace WIMS_TeamTK.Core.Commands.RemoveCommands
{
    public class RemoveLastCommentCommand : Command
    {
        public RemoveLastCommentCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string workItemName = parameter;
            try
            {
                var workItem = this._validator.ValidateWorkItemExists(this._engine.WorkItems, workItemName);
                workItem = this._validator.ValidateMoreThanOneWorkItem(this._engine.WorkItems, workItemName);
                Console.Write("Author: ");
                string authorName = Console.ReadLine().Trim();
                var author = this._validator.ValidateMemberExists(this._engine.Members, authorName);
                var comment = workItem.Comments.FindLast(c => c.Author == authorName);
                workItem.Comments.Remove(comment);
                return $"Removed last comment of {authorName} from {workItemName}";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to remove comment.");
            }
        }
    }
}
