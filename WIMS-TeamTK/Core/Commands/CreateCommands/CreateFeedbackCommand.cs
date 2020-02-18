﻿using System;
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
            string boardName;
            string description;
            int rating;
            FeedbackStatus status;

            try
            {
                Console.Write("Board: ");
                boardName = Console.ReadLine();
                var board = this._validator.ValidateBoardExists(this._engine.Boards, boardName);
                board = this._validator.ValidateMoreThanOneBoard(this._engine.Boards, boardName);
                Console.Write("Feedback Description(Single line.): ");
                description = this._validator.ValidateDescription(Console.ReadLine());
                Console.WriteLine("Feedback Rating(-10 to 10):");
                rating = int.Parse(Console.ReadLine());
                Console.WriteLine("Feedback Status(New/Unscheduled/Scheduled/Done):");
                status = this._validator.ValidateFeedbackStatus(Console.ReadLine());
                Feedback feedback = (Feedback)this._factory.CreateFeedback(title, description, rating, status);
                this._engine.WorkItems.Add(feedback);
                return $"Feedback with ID {this._engine.WorkItems.Count - 1}, Title {title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Incorrect values passed when creating feedback. Feedback was not created.");
            }
        }
    }
}
