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

        public override string Execute(IList<string> parameters)
        {
            string name;
            string teamname;

            try
            {
                name = parameters[0];
                teamname = parameters[1];

                var board = this._factory.CreateBoard(name);
                this._engine.Boards.Add(board);
                this._engine.Teams.First(n => n.Name == teamname).Boards.Add(board);
                return $"Board with ID: {this._engine.Boards.Count - 1} and name: {board.Name} was created in team {teamname}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message + "\nIncorrect values passed. Board was not created.");
            }


        }
    }
}
