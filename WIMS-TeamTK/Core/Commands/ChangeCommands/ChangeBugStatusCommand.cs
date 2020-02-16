using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeBugStatusCommand : Command
    {
        public ChangeBugStatusCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                if (!this._engine.WorkItems.Any(n => n.Title == parameter && n.GetType().Name == "Bug"))
                {
                    throw new ArgumentException($"Bug with title {parameter} not found.");
                }
                Console.WriteLine("New Bug Status(Active/Fixed):");
                string newStatus = Console.ReadLine();

                (this._engine.WorkItems.First(n => n.Title == parameter && n.GetType().Name == "Bug") as Bug)
                    .Status = (BugStatus)Enum.Parse(typeof(BugStatus), newStatus, true);
                return $"Changed {parameter} severity to {newStatus}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change bug status.");
            }
        }
    }
}
