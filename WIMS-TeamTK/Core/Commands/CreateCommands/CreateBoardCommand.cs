using System;
using System.Collections.Generic;
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

        public override string Execute(IList<string> parameters)
        {
            string name;

            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBoard command parameters.");
            }

            var board = this._factory.CreateBoard(name);
            this._engine.Boards.Add(board);

            return $"Board with ID: {this._engine.Boards.Count - 1} and name: {board.Name} was created.";
        }
    }
}
