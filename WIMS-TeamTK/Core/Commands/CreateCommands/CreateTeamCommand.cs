﻿using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string teamName = parameter.Trim();
            try
            {
                var team = this._factory.CreateTeam(teamName);
                this._validator.ValidateDuplicateTeam(this._engine.Teams, teamName);
                this._engine.Teams.Add(team);

                return $"Team with ID: {this._engine.Teams.Count - 1} and name: {parameter} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create team.");
            }

        }
    }
}
