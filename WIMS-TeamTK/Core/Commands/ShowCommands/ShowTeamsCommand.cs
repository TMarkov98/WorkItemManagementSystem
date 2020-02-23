using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowTeamsCommand : Command
    {
        public ShowTeamsCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            if(this._engine.Teams.Count == 0)
            {
                return "No teams added.";
            }
            string result = string.Join($"{Environment.NewLine}", this._engine.Teams
                .Select((team) => $"ID: {this._engine.Teams.IndexOf(team)} - {team.ToString()}").ToArray());
            return result;
        }
    }
}
