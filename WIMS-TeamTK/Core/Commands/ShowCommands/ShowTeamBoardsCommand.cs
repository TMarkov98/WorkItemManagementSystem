using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowTeamBoardsCommand : Command
    {
        public ShowTeamBoardsCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var team = this._engine.Teams.First(n => n.Name == parameter);
                if (team.Boards.Count == 0)
                {
                    return "No boards added to team.";
                }
                string result = string.Join($"{Environment.NewLine}", team.Boards
                    .Select((board) => $"ID: {this._engine.Boards.IndexOf(board)} - {board.ToString()}").ToArray());
                return result;
            }
            catch
            {
                throw new ArgumentException($"Team name {parameter} not found.");
            }
        }
    }
}
