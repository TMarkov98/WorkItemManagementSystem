using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var board = this._validator.ValidateMoreThanOneBoard(this._engine.Boards, parameter);
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
