using System;
using System.Collections.Generic;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IFactory factory, IEngine engine) : base(factory, engine)
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
                throw new ArgumentException("Failed to parse CreateTeam command parameters.");
            }

            var team = this._factory.CreateTeam(name);
            this._engine.Teams.Add(team);

            return $"Team with ID: {this._engine.Teams.Count} and name: {name} was created.";
        }
    }
}
