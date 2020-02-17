using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeBugSeverityCommand : Command
    {
        public ChangeBugSeverityCommand(IFactory factory, IEngine engine)
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
                Console.Write("New Bug Severity(Critical/Major/Minor): ");
                string newSeverity = Console.ReadLine();

                (this._engine.WorkItems.First(n => n.Title == parameter && n.GetType().Name == "Bug") as Bug)
                    .Severity = (Severity)Enum.Parse(typeof(Severity), newSeverity, true);
                return $"Changed {parameter} severity to {newSeverity}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change bug severity.");
            }
        }
    }
}
