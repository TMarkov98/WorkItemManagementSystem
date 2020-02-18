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
    class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string storyName = parameter;
            string description;
            string boardName;
            Priority priority;
            Size size;
            StoryStatus status;
            try
            {
                Story story = (Story)this._factory.CreateStory(parameter);
                Console.Write("Board: ");
                boardName = Console.ReadLine();
                var board = this._validator.ValidateBoardExists(this._engine.Boards, boardName);
                board = this._validator.ValidateMoreThanOneBoard(this._engine.Boards, boardName);
                board.AddWorkItem(story);
                Console.Write("Story Description(Single line): ");
                description = this._validator.ValidateDescription(Console.ReadLine());
                Console.WriteLine("Story Priority(High/Medium/Low):");
                priority = this._validator.ValidatePriority(Console.ReadLine());
                Console.WriteLine("Story Size(Large/Medium/Small):");
                size = this._validator.ValidateSize(Console.ReadLine());
                Console.WriteLine("Story Status(NotDone/InProgress/Done):");
                status = this._validator.ValidateStoryStatus(Console.ReadLine());
                this._engine.WorkItems.Add(story);
                return $"Story with ID {this._engine.WorkItems.Count - 1}, Title {story.Title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Incorrect values passed when creating story. Story was not created.");
            }
        }
    }
}
