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
                var board = this._engine.Boards.First(n => n.Name == parameter);
                if (this._engine.Boards.Count(n => n.Name == parameter) > 1)
                {
                    Console.Write("More than one board found. Please use board's ID: ");
                    var boardId = int.Parse(Console.ReadLine());
                    board = this._engine.Boards[boardId];
                }
                else if (!this._engine.Boards.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Board {parameter} not found.");
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
