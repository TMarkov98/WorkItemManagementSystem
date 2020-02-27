using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
{
    class ChangeBugPriorityCommand : Command
    {
        public ChangeBugPriorityCommand(IFactory factory, IEngine engine, IValidator validator)
            : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            string workItemName = parameter;
            try
            {
                var bug = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").ToList(), workItemName);
                bug = this._validator.ValidateMoreThanOne(this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").ToList(), workItemName);
                Console.Write("New Bug Priority(High/Medium/Low): ");
                (bug as IBug).Priority = this._validator.ValidatePriority(Console.ReadLine().Trim());
                return $"Changed {parameter} priority to {(bug as IBug).Priority}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change bug priority.");
            }
        }
    }
}
