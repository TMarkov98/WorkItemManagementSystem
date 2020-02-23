﻿using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

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
            string boardName;
            string teamName;

            try
            {
                boardName = this._validator.ValidateBoardName(parameter);
                var board = this._factory.CreateBoard(boardName);
                Console.Write("Assign to team: ");
                teamName = Console.ReadLine().Trim();
                var team = this._validator.ValidateTeamExists(this._engine.Teams, teamName);
                this._validator.ValidateDuplicateBoard(team.Boards, boardName);
                this._engine.Teams.First(n => n.Name == teamName).AddBoard(board);
                this._engine.Boards.Add(board);
                return $"Board with ID: {this._engine.Boards.Count - 1} and name: {board.Name} was created in team {teamName}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create board.");
            }


        }
    }
}
