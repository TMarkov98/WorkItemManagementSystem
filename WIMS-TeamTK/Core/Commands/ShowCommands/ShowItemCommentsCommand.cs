using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowItemCommentsCommand : Command
    {
        public ShowItemCommentsCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Shows all Comments in a WorkItem.
        /// </summary>
        /// <param name="parameter">The title of the WorkItem.</param>
        /// <returns>A string with all listed comments.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var workItem = this._validator.ValidateExists(this._engine.WorkItems, parameter);
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
