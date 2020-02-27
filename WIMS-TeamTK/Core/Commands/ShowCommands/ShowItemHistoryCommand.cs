using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowItemHistoryCommand : Command
    {
        public ShowItemHistoryCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Shows the History of a WorkItem.
        /// </summary>
        /// <param name="parameter">The title of the WorkItem.</param>
        /// <returns>A string with the WorkItem history.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var workItem = this._validator.ValidateExists(this._engine.WorkItems, parameter);
                if (workItem.History.Count == 0)
                {
                    throw new ArgumentException("History of this item is empty.");
                }
                string result = string.Join(Environment.NewLine, workItem.History);
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to list work item's history.");
            }
        }
    }
}
