using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowTeamsCommand : Command
    {
        public ShowTeamsCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            //TODO : Try to add indexes
            string result = string.Join($"{Environment.NewLine}", this._engine.Teams);
            return result;
        }
    }
}
