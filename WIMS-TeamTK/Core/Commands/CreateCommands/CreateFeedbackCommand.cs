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

        public override string Execute(string parameter)
        {
            string title = parameter;
            string boardname;
            string description;
            int rating;
            FeedbackStatus status;

            try
            {
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
                    throw new ArgumentException($"Board {boardname} not found.");
                }
                else
                {
                    this._engine.Boards.FirstOrDefault(n => n.Name == boardname).WorkItems.Add(feedback);
                }
                Console.Write("Feedback Description(Single line.): ");
                description = this._validator.ValidateDescription(Console.ReadLine());
                Console.WriteLine("Feedback Rating(-10 to 10):");
                rating = int.Parse(Console.ReadLine());
                Console.WriteLine("Feedback Status(New/Unscheduled/Scheduled/Done):");
                status = this._validator.ValidateFeedbackStatus(Console.ReadLine());
                this._engine.WorkItems.Add(feedback);
                return $"Feedback with ID {this._engine.WorkItems.Count - 1}, Title {feedback.Title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Incorrect values passed when creating feedback. Feedback was not created.");
            }
        }
    }
}
