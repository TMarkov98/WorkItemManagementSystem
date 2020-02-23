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
    class ChangeStoryPriorityCommand : Command
    {
        public ChangeStoryPriorityCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var story = this._validator.ValidateWorkItemExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Story").ToList(), parameter);
                Console.Write("New Story Priority(High/Medium/Low): ");

                (story as IStory).Priority = this._validator.ValidatePriority(Console.ReadLine().Trim());
                return $"Changed {parameter} priority to {(story as IStory).Priority}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change story priority.");
            }
        }
    }
}
