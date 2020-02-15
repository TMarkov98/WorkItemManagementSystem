using System;
using System.Collections.Generic;
using System.Linq;
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
            string boardname;

            try
            {
                title = string.Join(" ", parameters);
                Feedback feedback = (Feedback)this._factory.CreateFeedback(title);
                Console.Write("Board: ");
                boardname = Console.ReadLine();
                if (this._engine.Boards.Count(n => n.Name == boardname) > 1)
                {
                    Console.Write("More than one board found. Please use board's ID: ");
                    var boardId = int.Parse(Console.ReadLine());
                    this._engine.Boards[boardId].WorkItems.Add(feedback);
                }
                else if (this._engine.Boards.Count(n => n.Name == boardname) < 1)
                {
                    throw new ArgumentException("Board does not exist!");
                }
                else
                {
                    this._engine.Boards.FirstOrDefault(n => n.Name == boardname).WorkItems.Add(feedback);
                }
                Console.Write("Feedback Description(Single line.): ");
                feedback.Description = Console.ReadLine();
                Console.WriteLine("Feedback Rating(integer):");
                feedback.Rating = int.Parse(Console.ReadLine());
                Console.WriteLine("Feedback Status(New/Unscheduled/Scheduled/Done):");
                feedback.Status = (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), Console.ReadLine(), true);
                this._engine.WorkItems.Add(feedback);
                return $"Feedback with ID {this._engine.WorkItems.Count - 1}, Title {feedback.Title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message + "\nIncorrect values passed when creating feedback. Feedback was not created.");
            }
        }
    }
}
