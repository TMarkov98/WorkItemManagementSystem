using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands
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
                if (!this._engine.WorkItems.Any(n => n.Title == parameter && n.GetType().Name == "Story"))
                {
                    throw new ArgumentException($"Story with title {parameter} not found.");
                }
                Console.WriteLine("New Story Status(NotDone/InProgress/Done):");
                string newStatus = Console.ReadLine();

                (this._engine.WorkItems.First(n => n.Title == parameter && n.GetType().Name == "Story") as Story)
                    .Status = (StoryStatus)Enum.Parse(typeof(StoryStatus), newStatus, true);
                return $"Changed {parameter} priority to {newStatus}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change story priority.");
            }
        }
    }
}
