using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ListFeedbacksCommand : Command
    {
        public ListFeedbacksCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string result = "";
            List<Feedback> allFeedbacks = this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").Select(n => n as Feedback).ToList();
            if (parameter == "")
            {
                result = string.Join(Environment.NewLine, this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").Select((workItem, index) => $"ID: {index} - {workItem.ToString()}").ToArray());
            }
            else if (parameter.ToLower() == "sort")
            {
                Console.Write("Sort by(Title/Rating): ");
                string sortedBy = Console.ReadLine().ToLower();
                switch (sortedBy)
                {
                    case "title":
                        result = string.Join(Environment.NewLine, this._engine.WorkItems.Where(n => n.GetType().Name == "Bug").OrderBy(n => n.Title));
                        break;
                    case "rating":
                        result = string.Join(Environment.NewLine, allFeedbacks.OrderBy(n => n.Rating));
                        break;
                    default:
                        throw new ArgumentException("Input is not valid parameter to be sort by.");
                }
            }
            else if (parameter.ToLower() == "filter")
            {
                Console.WriteLine("Filter by(status): ");
                string filter = Console.ReadLine().ToLower();

                if (filter == "status")
                {
                    Console.WriteLine("Status to filter by(New/Unscheduled/Scheduled/Done): ");
                    string filterStatus = Console.ReadLine().ToLower();
                    if (filterStatus == "new")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.New)));
                    }
                    else if (filterStatus == "unscheduled")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.Unscheduled)));
                    }
                    else if (filterStatus == "scheduled")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.Scheduled)));
                    }
                    else if (filterStatus == "done")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.Done)));
                    }
                    else
                    {
                        throw new ArgumentException($"{filter} is not valid parameter to filter by.");
                    }
                }
            }
            return result;
        }
    }
}
