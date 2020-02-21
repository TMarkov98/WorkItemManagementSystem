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
    public class AddCommentCommand : Command
    {
        public AddCommentCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string workItemName = parameter;
            string authorName;
            string message;
            try
            {
                var workItem = this._validator.ValidateWorkItemExists(this._engine.WorkItems, workItemName);
                Console.Write("Author: ");
                authorName = Console.ReadLine();
                var author = this._validator.ValidateMemberExists(this._engine.Members, authorName);
                Console.Write("Message: ");
                message = Console.ReadLine();
                workItem = this._validator.ValidateMoreThanOneWorkItem(this._engine.WorkItems, workItemName);
                var comment = this._factory.CreateComment(author.Name, message);
                workItem.AddComment(comment);
                author.AddCommentToHistory();
                return $"Added comment to {parameter}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to add comment to WorkItem.");
            }
        }
    }
}
