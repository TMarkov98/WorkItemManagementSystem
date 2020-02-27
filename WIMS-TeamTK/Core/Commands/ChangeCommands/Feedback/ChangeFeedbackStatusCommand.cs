﻿using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands
{
    class ChangeFeedbackStatusCommand : Command
    {
        public ChangeFeedbackStatusCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                var feedback = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").ToList(), parameter);
                feedback = this._validator.ValidateMoreThanOne((this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").ToList()), parameter);
                Console.Write("New Feedback Status(New/Unscheduled/Scheduled/Done): ");
                string newStatus = Console.ReadLine().Trim();

                (feedback as IFeedback).Status = (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), newStatus, true);
                return $"Changed {parameter} status to {newStatus}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change feedback status.");
            }
        }
    }
}
