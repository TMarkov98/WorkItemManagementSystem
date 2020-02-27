using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeStoryPriorityCommand : Command
    {
        public ChangeStoryPriorityCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Changes the Priority property of a Story, based on user input.
        /// </summary>
        /// <param name="parameter">The title of the Story.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var story = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Story").ToList(), parameter);
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
