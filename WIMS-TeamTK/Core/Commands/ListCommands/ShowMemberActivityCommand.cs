using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowMemberActivityCommand : Command
    {
        public ShowMemberActivityCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var member = this._validator.ValidateMemberExists(this._engine.Members, parameter);
                string result = string.Join($"{Environment.NewLine}", member.ActivityHistory);
                return result;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to list member history.");
            }
        }
    }
}
