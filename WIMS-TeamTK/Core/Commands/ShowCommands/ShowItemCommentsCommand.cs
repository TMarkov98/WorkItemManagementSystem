using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowItemCommentsCommand : Command
    {
        public ShowItemCommentsCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var workItem = this._validator.ValidateWorkItemExists(this._engine.WorkItems, parameter);
                if (workItem.Comments.Count == 0)
                {
                    throw new ArgumentException("No comments yet.");
                }
                string result = string.Join($"{Environment.NewLine}", workItem.Comments);
                return result;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to list workitem's comments.");
            }
        }
    }
}
