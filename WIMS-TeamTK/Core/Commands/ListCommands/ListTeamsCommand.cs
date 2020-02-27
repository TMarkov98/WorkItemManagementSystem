using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ListTeamsCommand : Command
    {
        public ListTeamsCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Lists all Teams.
        /// </summary>
        /// <returns>A string with all Teams listed.</returns>
        public override string Execute(string parameter)
        {
            if (this._engine.Teams.Count == 0)
            {
                return "No teams added.";
            }
            string result = string.Join($"{Environment.NewLine}", this._engine.Teams
                .Select((team) => $"ID: {this._engine.Teams.IndexOf(team)} - {team.ToString()}").ToArray());
            return result;
        }
    }
}
