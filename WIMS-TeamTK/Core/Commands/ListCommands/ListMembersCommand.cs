using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ListMembersCommand : Command
    {
        public ListMembersCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Lists all members.
        /// </summary>
        /// <returns>A string with the listed members.</returns>
        public override string Execute(string parameter)
        {
            if (this._engine.Members.Count == 0)
            {
                return "No members added";
            }
            string result = string.Join($"{Environment.NewLine}", this._engine.Members
                .Select((member) => $"ID: {this._engine.Members.IndexOf(member)} - {member.ToString()}").ToArray());

            return result;
        }
    }
}
