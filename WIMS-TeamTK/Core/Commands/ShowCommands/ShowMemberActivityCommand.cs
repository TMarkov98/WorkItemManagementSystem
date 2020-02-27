﻿using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowMemberActivityCommand : Command
    {
        public ShowMemberActivityCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var member = this._validator.ValidateExists(this._engine.Members, parameter);
                if(member.ActivityHistory.Count == 0)
                {
                    return "No member history listed.";
                }
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
