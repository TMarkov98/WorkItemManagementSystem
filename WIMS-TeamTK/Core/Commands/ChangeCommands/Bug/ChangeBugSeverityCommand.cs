using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

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
            string workItemName = parameter;
            try
            {
                var bug = this._validator.ValidateWorkItemExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").ToList(), workItemName);
                bug = this._validator.ValidateMoreThanOneWorkItem(this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").ToList(), workItemName);
                Console.Write("New Bug Severity(Critical/Major/Minor): ");
                (bug as IBug).Severity = this._validator.ValidateSeverity(Console.ReadLine().Trim());
                return $"Changed {parameter} severity to {(bug as IBug).Severity}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change bug severity.");
            }
        }
    }
}
