using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeStorySizeCommand : Command
    {
        public ChangeStorySizeCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var story = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Story").ToList(), parameter);
                Console.Write("New Story Size(Large/Medium/Small): ");
                string newSize = Console.ReadLine().Trim();

                (story as IStory).Size = this._validator.ValidateSize(Console.ReadLine().Trim());
                return $"Changed {parameter} size to {(story as IStory).Size}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change story size.");
            }
        }
    }
}
