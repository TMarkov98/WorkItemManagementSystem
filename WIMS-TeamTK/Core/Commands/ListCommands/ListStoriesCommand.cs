using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ListStoriesCommand : Command
    {
        public ListStoriesCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string result = string.Empty;
            List<IStory> allStories = this._engine.WorkItems.Where(n => n.GetType().Name == "Story").Select(n => n as IStory).ToList();
            if(allStories.Count == 0)
            {
                return "No stories added.";
            }
            if (parameter == "")
            {
                result = string.Join(Environment.NewLine, allStories.Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
            }
            else if (parameter.ToLower() == "sort")
            {
                Console.Write("Sort by(title/priority/size/status): ");
                string sortedBy = Console.ReadLine().ToLower();
                switch (sortedBy)
                {
                    case "title":
                        result = string.Join(Environment.NewLine, allStories.OrderBy(n => n.Title));
                        break;
                    case "priority":
                        result = string.Join(Environment.NewLine, allStories.OrderBy(n => n.Priority));
                        break;
                    case "size":
                        result = string.Join(Environment.NewLine, allStories.OrderBy(n => n.Size));
                        break;
                    case "status":
                        result = string.Join(Environment.NewLine, allStories.OrderBy(n => n.Status));
                        break;
                    default:
                        throw new ArgumentException("Input is not valid parameter to be sort by.");
                }
            }
            else if (parameter.ToLower() == "filter")
            {
                Console.Write("Filter by(status/assigne): ");
                string filter = Console.ReadLine().ToLower();

                if (filter == "status")
                {
                    Console.Write("Status to filter by(NotDone/InProgress/Done): ");
                    string filterStatus = Console.ReadLine().ToLower();
                    if (filterStatus == "notdone")
                    {
                        result = string.Join(Environment.NewLine, allStories.Where(n => n.Status.Equals(StoryStatus.NotDone)).Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}"));
                    }
                    else if (filterStatus == "inprogress")
                    {
                        result = string.Join(Environment.NewLine, allStories.Where(n => n.Status.Equals(StoryStatus.InProgress)).Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}"));
                    }
                    else if (filterStatus == "done")
                    {
                        result = string.Join(Environment.NewLine, allStories.Where(n => n.Status.Equals(StoryStatus.Done)).Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}"));
                    }
                }
                else if (filter == "assigne")
                {
                    Console.Write("Assigne to filter by: ");
                    string filterAssigne = Console.ReadLine();
                    this._validator.ValidateMemberExists(this._engine.Members, filterAssigne);
                    result = string.Join(Environment.NewLine, allStories.Where(n => n.Assignee.Equals(filterAssigne)).Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}"));
                }
                else
                {
                    throw new ArgumentException($"{filter} is not valid parameter to filter by.");
                }
            }
            return result;
        }
    }
}
