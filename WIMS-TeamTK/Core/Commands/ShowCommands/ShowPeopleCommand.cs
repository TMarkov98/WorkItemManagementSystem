using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowPeopleCommand : Command
    {
        public ShowPeopleCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

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
