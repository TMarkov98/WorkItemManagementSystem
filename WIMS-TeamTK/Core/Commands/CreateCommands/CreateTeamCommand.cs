using System;
using System.Collections.Generic;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {

            try
            {
                var team = this._factory.CreateTeam(parameter);
                if(this._engine.Teams.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Team with name {parameter} already exists.");
                }
                this._engine.Teams.Add(team);

                return $"Team with ID: {this._engine.Teams.Count - 1} and name: {parameter} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}{Environment.NewLine}Unable to create team.");
            }

        }
    }
}
