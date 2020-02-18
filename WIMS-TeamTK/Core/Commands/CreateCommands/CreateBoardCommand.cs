using System;
using System.Collections.Generic;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateBoardCommand : Command
    {
        public CreateBoardCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string boardName = parameter;
            string teamName;

            try
            {
                var board = this._factory.CreateBoard(boardName);
                Console.Write("Assign to team: ");
                teamName = Console.ReadLine();
                var team = this._validator.ValidateTeamExists(this._engine.Teams, teamName);
                this._engine.Boards.Add(board);
                this._validator.ValidateDuplicateBoard(team.Boards, boardName);
                this._engine.Teams.First(n => n.Name == teamName).AddBoard(board);
                return $"Board with ID: {this._engine.Boards.Count - 1} and name: {board.Name} was created in team {teamName}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Incorrect values passed. Board was not created.");
            }


        }
    }
}
