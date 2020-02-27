using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Creates a new Team, based on user input.
        /// </summary>
        /// <param name="parameter">The name of the Team.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            string teamName;
            try
            {
                teamName = this._validator.ValidateTeamName(parameter);
                var team = this._factory.CreateTeam(teamName);
                this._validator.ValidateDuplicate(this._engine.Teams, teamName);
                this._engine.Teams.Add(team);

                return $"Team with ID: {this._engine.Teams.Count - 1} and name: {parameter} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create team.");
            }

        }
    }
}
