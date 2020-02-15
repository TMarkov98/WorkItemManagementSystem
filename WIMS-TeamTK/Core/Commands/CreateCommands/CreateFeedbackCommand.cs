using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string title;
            List<string> stepsToReproduce = new List<string>();

            try
            {
                title = string.Join(" ", parameters);
                Feedback feedback = (Feedback)this._factory.CreateFeedback(title);
                Console.Write("Feedback Description(Single line.): ");
                feedback.Description = Console.ReadLine();
                Console.WriteLine("Feedback Rating(integer):");
                feedback.Rating = int.Parse(Console.ReadLine());
                Console.WriteLine("Feedback Status(New/Unscheduled/Scheduled/Done):");
                feedback.Status = (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), Console.ReadLine(), true);
                this._engine.WorkItems.Add(feedback);
                return $"Story with ID {this._engine.WorkItems.Count - 1}, Title {feedback.Title} was created.";
            }
            catch
            {
                throw new ArgumentException("Incorrect values passed when creating bug. Bug was not created.");
            }
        }
    }
}
