using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeBugSeverityCommand : Command
    {
        public ChangeBugSeverityCommand(IFactory factory, IEngine engine, IValidator validator)
            : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Changes the Severity property of a Bug, based on user input.
        /// </summary>
        /// <param name="parameter">The title of the Bug.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            string workItemName = parameter;
            try
            {
                var bug = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").ToList(), workItemName);
                bug = this._validator.ValidateMoreThanOne(this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").ToList(), workItemName);
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
