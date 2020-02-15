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
            string boardname;
            List<string> stepsToReproduce = new List<string>();

            try
            {
                Story story = (Story)this._factory.CreateStory(parameter);
                Console.Write("Board: ");
                boardname = Console.ReadLine();
                if (this._engine.Boards.Count(n => n.Name == boardname) > 1)
                {
                    Console.Write("More than one board found. Please use board's ID: ");
                    var boardId = int.Parse(Console.ReadLine());
                    this._engine.Boards[boardId].WorkItems.Add(story);
                }
                else if (this._engine.Boards.Count(n => n.Name == boardname) < 1)
                {
                    throw new ArgumentException($"Board {boardname} not found.");
                }
                else
                {
                    this._engine.Boards.FirstOrDefault(n => n.Name == boardname).WorkItems.Add(story);
                }
                Console.Write("Story Description(Single line): ");
                story.Description = Console.ReadLine();
                Console.WriteLine("Story Priority(High/Medium/Low):");
                story.Priority = (Priority)Enum.Parse(typeof(Priority), Console.ReadLine(), true);
                Console.WriteLine("Story Size(Large/Medium/Small):");
                story.Size = (Size)Enum.Parse(typeof(Size), Console.ReadLine(), true);
                Console.WriteLine("Story Status(NotDone/InProgress/Done):");
                story.Status = (StoryStatus)Enum.Parse(typeof(StoryStatus), Console.ReadLine(), true);
                this._engine.WorkItems.Add(story);
                return $"Story with ID {this._engine.WorkItems.Count - 1}, Title {story.Title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message + "\nIncorrect values passed when creating story. Story was not created.");
            }
        }
    }
}
