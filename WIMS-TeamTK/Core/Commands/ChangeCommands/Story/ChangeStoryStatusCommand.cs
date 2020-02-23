using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeStoryStatusCommand : Command
    {
        public ChangeStoryStatusCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var story = this._validator.ValidateWorkItemExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Story").ToList(), parameter);
                Console.Write("New Story Status(NotDone/InProgress/Done): ");
                string newStatus = Console.ReadLine().Trim();

                (story as IStory).Status = this._validator.ValidateStoryStatus(Console.ReadLine().Trim());
                return $"Changed {parameter} status to {(story as IStory).Status}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change story status.");
            }
        }
    }
}
