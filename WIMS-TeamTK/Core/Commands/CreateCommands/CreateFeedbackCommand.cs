using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;
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
            string title;
            string boardName;
            string description;
            int rating;
            FeedbackStatus status;

            try
            {
                title = this._validator.ValidateTitle(parameter);
                Console.Write("Board: ");
                boardName = Console.ReadLine().Trim();
                var board = this._validator.ValidateBoardExists(this._engine.Boards, boardName);
                board = this._validator.ValidateMoreThanOneBoard(this._engine.Boards, boardName);
                Console.Write("Feedback Description(Single line.): ");
                description = this._validator.ValidateDescription(Console.ReadLine().Trim());
                Console.Write("Feedback Rating(-10 to 10): ");
                rating = this._validator.ValidateRating(Console.ReadLine().Trim());
                Console.Write("Feedback Status(New/Unscheduled/Scheduled/Done): ");
                status = this._validator.ValidateFeedbackStatus(Console.ReadLine().Trim());
                IFeedback feedback = this._factory.CreateFeedback(title, description, rating, status);
                this._engine.WorkItems.Add(feedback);
                board.AddWorkItem(feedback);
                return $"Feedback with ID {this._engine.WorkItems.Count - 1}, Title {title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create feedback.");
            }
        }
    }
}
