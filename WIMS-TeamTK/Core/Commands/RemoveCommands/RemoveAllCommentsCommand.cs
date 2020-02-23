using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.RemoveCommands
{
    class RemoveAllCommentsCommand : Command
    {
        public RemoveAllCommentsCommand(IFactory factory, IEngine engine) : base(factory, engine)
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
                workItem.Comments.RemoveAll(comment => comment.Author == authorName);
                return $"Removed all comments of {authorName} from {workItemName}";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to remove comments.");
            }
        }
    }
}
