using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var team = this._validator.ValidateExists(this._engine.Teams, parameter);
                if(team.ActivityHistory.Count == 0)
                {
                    return "No team history listed.";
                }
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
