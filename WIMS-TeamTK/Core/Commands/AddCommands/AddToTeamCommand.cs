using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.CreateCommands
{
    class AddToTeamCommand : Command
    {
        public AddToTeamCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Adds a member into the provided team, based on user input.
        /// </summary>
        /// <param name="parameter">The name of the team.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            string teamName = parameter.Trim();
            string memberName;
            try
            {
                var team = this._validator.ValidateExists(this._engine.Teams, teamName);
                Console.Write("Member: ");
                memberName = Console.ReadLine().Trim();
                var member = this._validator.ValidateExists(this._engine.Members, memberName);
                this._validator.ValidateDuplicate(team.Members, memberName);
                team.AddMember(member);
                return $"Added member {memberName} to team {parameter}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to add member to team.");
            }
        }
    }
}
