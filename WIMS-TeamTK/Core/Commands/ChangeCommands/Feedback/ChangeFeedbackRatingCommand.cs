using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands
{
    class ChangeFeedbackRatingCommand : Command
    {
        public ChangeFeedbackRatingCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string workItemName = parameter;
            try
            {
                var feedback = this._validator.ValidateWorkItemExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").ToList(), workItemName);
                feedback = this._validator.ValidateMoreThanOneWorkItem(this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").ToList(), workItemName);
                Console.Write("New Feedback Rating(-10 to 10): ");
                (feedback as IFeedback).Rating = this._validator.ValidateRating(Console.ReadLine());
                return $"Changed {parameter} rating to {(feedback as IFeedback).Rating}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change feedback rating.");
            }
        }
    }
}
