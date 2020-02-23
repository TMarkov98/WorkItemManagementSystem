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
    class ChangeBugStatusCommand : Command
    {
        public ChangeBugStatusCommand(IFactory factory, IEngine engine)
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
                Console.Write("New Bug Status(Active/Fixed): ");
                (bug as IBug).Status = this._validator.ValidateBugStatus(Console.ReadLine().Trim());
                return $"Changed {parameter} severity to {(bug as IBug).Status}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change bug status.");
            }
        }
    }
}
