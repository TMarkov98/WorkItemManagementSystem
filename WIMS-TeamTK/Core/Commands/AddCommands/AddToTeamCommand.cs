using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.CreateCommands
{
    class AddToTeamCommand : Command
    {
        public AddToTeamCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string memberName;
            try
            {
                Console.Write("Member: ");
                memberName = Console.ReadLine();
                if (!this._engine.Members.Any(n => n.Name == memberName))
                {
                    throw new ArgumentException($"{memberName} is not a valid member.");
                }
                var team = this._engine.Teams.First(n => n.Name == parameter);
                var member = this._engine.Members.First(n => n.Name == memberName);
                if (team.Members.Any(n => n.Name == memberName))
                {
                    throw new ArgumentException($"Member {memberName} is already assigned to this team.");
                }
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
