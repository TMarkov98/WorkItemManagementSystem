using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

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
                var board = this._validator.ValidateBoardExists(this._engine.Boards, boardName);
                board = this._validator.ValidateMoreThanOneBoard(this._engine.Boards, boardName);
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
