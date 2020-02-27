using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands
{
    class ChangeFeedbackRatingCommand : Command
    {
        public ChangeFeedbackRatingCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Changes the Rating property of a Feedback, based on user input.
        /// </summary>
        /// <param name="parameter">The title of the Feedback.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            string workItemName = parameter;
            try
            {
                var feedback = this._validator.ValidateExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").ToList(), workItemName);
                feedback = this._validator.ValidateMoreThanOne(this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").ToList(), workItemName);
                Console.Write("New Feedback Rating(-10 to 10): ");
                (feedback as IFeedback).Rating = this._validator.ValidateRating(Console.ReadLine().Trim());
                return $"Changed {parameter} rating to {(feedback as IFeedback).Rating}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change feedback rating.");
            }
        }
    }
}
