using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowTeamMembersCommand : Command
    {
        public ShowTeamMembersCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try 
            { 
                var team = this._engine.Teams.First(n => n.Name == parameter);
                if(team.Members.Count == 0)
                {
                    return "No team members added.";
                }
                string result = string.Join($"{Environment.NewLine}", team.Members
                    .Select((member) => $"ID: {this._engine.Members.IndexOf(member)} - {member.ToString()}").ToArray());
                return result;
            }
            catch
            {
                throw new ArgumentException($"Team name {parameter} not found.");
            }
        }
    }
}
