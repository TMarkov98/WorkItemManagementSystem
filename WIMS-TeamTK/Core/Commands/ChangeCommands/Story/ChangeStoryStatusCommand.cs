using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeStoryStatusCommand : Command
    {
        public ChangeStoryStatusCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Changes the Status property of a Story, based on user input.
        /// </summary>
        /// <param name="parameter">The title of the Story.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var story = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Story").ToList(), parameter);
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
