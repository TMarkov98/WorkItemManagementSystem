using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Core.Commands
{
    class ChangeFeedbackRatingCommand : Command
    {
        public ChangeFeedbackRatingCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                if (!this._engine.WorkItems.Any(n => n.Title == parameter && n.GetType().Name == "Feedback"))
                {
                    throw new ArgumentException($"Feedback with title {parameter} not found.");
                }
                Console.WriteLine("New Feedback Rating(-10 to 10):");
                int newRating = int.Parse(Console.ReadLine());

                (this._engine.WorkItems.First(n => n.Title == parameter && n.GetType().Name == "Feedback") as Feedback)
                    .Rating = newRating;
                return $"Changed {parameter} rating to {newRating}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change feedback rating.");
            }
        }
    }
}
