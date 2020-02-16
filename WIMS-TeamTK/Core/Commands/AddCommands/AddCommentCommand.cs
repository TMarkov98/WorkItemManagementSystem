using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Core.Commands.AddCommands
{
    public class AddCommentCommand : Command
    {
        public AddCommentCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string author;
            string message;
            try
            {
                Console.Write("Author: ");
                author = Console.ReadLine();
                if(!this._engine.Members.Any(n => n.Name == author))
                {
                    throw new ArgumentException($"Author {author} is not a valid member.");
                }
                var member = this._engine.Members.First(n => n.Name == author);
                Console.Write("Message: ");
                message = Console.ReadLine();
                Comment comment = (Comment)this._factory.CreateComment(author, message);
                member.AddedCommentToHistory();
                if (this._engine.WorkItems.Count(n => n.Title == parameter) > 1)
                {
                    Console.Write("More than one WorkItem found with this name. Please use WorkItem ID: ");
                    var workItemId = int.Parse(Console.ReadLine());
                    this._engine.WorkItems[workItemId].AddComment(comment);
                }
                else if (this._engine.WorkItems.Count((n => n.Title == parameter)) < 1)
                {
                    throw new ArgumentException($"WorkItem {parameter} not found.");
                }
                else
                {
                    this._engine.WorkItems.First(n => n.Title == parameter).AddComment(comment);
                }
                return $"Added comment to {parameter}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}{Environment.NewLine}Unable to add comment to WorkItem.");
            }
        }
    }
}
