using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ListItemHistoryCommand : Command
    {
        public ListItemHistoryCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var workItem = this._validator.ValidateWorkItemExists(this._engine.WorkItems, parameter);
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
