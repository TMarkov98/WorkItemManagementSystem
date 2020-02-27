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
