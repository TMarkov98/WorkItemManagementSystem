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
            string teamName;
            try
            {
                Console.Write("Team: ");
                teamName = Console.ReadLine();
                var team = this._engine.Teams.First(n => n.Name == teamName);
                if(team.Members.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Member {parameter} is already assigned to this team.");
                }
                team.Members.Add(this._engine.Members.First(n => n.Name == parameter));
                return $"Added member {parameter} to team {teamName}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}{Environment.NewLine}Unable to add member to team.");
            }
        }
    }
}
