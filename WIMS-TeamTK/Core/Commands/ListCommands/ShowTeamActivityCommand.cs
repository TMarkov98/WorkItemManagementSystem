using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                if (!this._engine.Teams.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Team with name {parameter} does not exist.");
                }
                var team = this._engine.Teams.First(n => n.Name == parameter);
                string result = string.Join(Environment.NewLine, team.ActivityHistory);
                return result;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to show team activity.");
            }
        }
    }
}
