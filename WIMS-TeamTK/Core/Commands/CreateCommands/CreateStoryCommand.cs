﻿using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Creates a new Story in a Board, based on user input.
        /// </summary>
        /// <param name="parameter">The name of the Story.</param>
        /// <returns>A string that reflects if the command was successful.</returns>
        public override string Execute(string parameter)
        {
            string title;
            string description;
            string boardName;
            Priority priority;
            Size size;
            StoryStatus status;
            try
            {
                title = this._validator.ValidateTitle(parameter);
                Console.Write("Board: ");
                boardName = Console.ReadLine().Trim();
                var board = this._validator.ValidateExists(this._engine.Boards, boardName);
                board = this._validator.ValidateMoreThanOne(this._engine.Boards, boardName);
                Console.Write("Story Description(Single line): ");
                description = this._validator.ValidateDescription(Console.ReadLine().Trim());
                Console.Write("Story Priority(High/Medium/Low): ");
                priority = this._validator.ValidatePriority(Console.ReadLine().Trim());
                Console.Write("Story Size(Large/Medium/Small): ");
                size = this._validator.ValidateSize(Console.ReadLine().Trim());
                Console.Write("Story Status(NotDone/InProgress/Done): ");
                status = this._validator.ValidateStoryStatus(Console.ReadLine().Trim());
                IStory story = this._factory.CreateStory(title, description, priority, size, status);
                this._engine.WorkItems.Add(story);
                board.AddWorkItem(story);
                return $"Story with ID {this._engine.WorkItems.Count - 1}, Title {title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create story.");
            }
        }
    }
}
