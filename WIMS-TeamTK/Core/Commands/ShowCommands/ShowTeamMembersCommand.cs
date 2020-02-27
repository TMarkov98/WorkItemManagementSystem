using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowTeamMembersCommand : Command
    {
        public ShowTeamMembersCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Shows all Members in a Team.
        /// </summary>
        /// <param name="parameter">The name of the Team.</param>
        /// <returns>A string with all Members added to the Team.</returns>
        public override string Execute(string parameter)
        {
            try
            {
                var team = this._validator.ValidateExists(this._engine.Teams, parameter);
                if (team.Members.Count == 0)
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
