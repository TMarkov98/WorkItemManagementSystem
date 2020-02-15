using System;
using System.Collections.Generic;
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

        public override string Execute(IList<string> parameters)
        {
            string title;
            List<string> stepsToReproduce = new List<string>();

            try
            {
                title = string.Join(" ", parameters);
                Story story = (Story)this._factory.CreateStory(title);
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
