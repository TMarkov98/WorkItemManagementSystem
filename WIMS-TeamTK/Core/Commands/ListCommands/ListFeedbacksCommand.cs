using System;
using System.Collections.Generic;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;
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
            string result = string.Empty;
            List<IFeedback> allFeedbacks = this._engine.WorkItems.Where(n => n.GetType().Name == "Feedback").Select(n => n as IFeedback).ToList();
            if(allFeedbacks.Count == 0)
            {
                return "No feedbacks added.";
            }
            if (parameter == "")
            {
                result = string.Join(Environment.NewLine, allFeedbacks
                    .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
            }
            else if (parameter.ToLower() == "sort")
            {
                Console.Write("Sort by(Title/Rating): ");
                string sortedBy = Console.ReadLine().Trim().ToLower();
                switch (sortedBy)
                {
                    case "title":
                        result = string.Join(Environment.NewLine, allFeedbacks.OrderBy(n => n.Title)
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                        break;
                    case "rating":
                        result = string.Join(Environment.NewLine, allFeedbacks.OrderBy(n => n.Rating)
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                        break;
                    default:
                        throw new ArgumentException("Input is not valid parameter to be sort by.");
                }
            }
            else if (parameter.ToLower() == "filter")
            {
                Console.Write("Filter by(status): ");
                string filter = Console.ReadLine().Trim().ToLower();

                if (filter == "status")
                {
                    Console.Write("Status to filter by(New/Unscheduled/Scheduled/Done): ");
                    string filterStatus = Console.ReadLine().Trim().ToLower();
                    if (filterStatus == "new")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.New))
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                    }
                    else if (filterStatus == "unscheduled")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.Unscheduled))
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                    }
                    else if (filterStatus == "scheduled")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.Scheduled))
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
                    }
                    else if (filterStatus == "done")
                    {
                        result = string.Join(Environment.NewLine, allFeedbacks.Where(n => n.Status.Equals(FeedbackStatus.Done))
                            .Select(workItem => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
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
