﻿using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowBoardItemsCommand : Command
    {
        public ShowBoardItemsCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Shows all WorkItems in a Board.
        /// </summary>
        /// <param name="parameter">The name of the Board.</param>
        /// <returns>A string with the Board's WorkItems.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var board = this._validator.ValidateExists(this._engine.Boards, parameter);
                if (board.WorkItems.Count == 0)
                {
                    throw new ArgumentException("No work items in this board.");
                }
                string result = string.Join(Environment.NewLine, board.WorkItems
                    .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}"));
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to list board's items.");
            }
        }
    }
}
