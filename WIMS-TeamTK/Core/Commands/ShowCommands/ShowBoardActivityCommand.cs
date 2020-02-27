using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Shows the ActivityHistory of a Board.
        /// </summary>
        /// <param name="parameter">The name of the Board.</param>
        /// <returns>A string with the Board's history.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var board = this._validator.ValidateMoreThanOne(this._engine.Boards, parameter);
                if (board.ActivityHistory.Count == 0)
                {
                    return "No board history listed.";
                }
                string result = string.Join($"{Environment.NewLine}", board.ActivityHistory);
                return result;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to list board history.");
            }
        }
    }
}
