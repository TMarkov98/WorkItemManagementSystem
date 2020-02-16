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
    class ChangeFeedbackStatusCommand : Command
    {
        public ChangeFeedbackStatusCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                if (!this._engine.WorkItems.Any(n => n.Title == parameter && n.GetType().Name == "Feedback"))
                {
                    throw new ArgumentException($"Feedback with title {parameter} not found.");
                }
                Console.WriteLine("New Feedback Status(New/Unscheduled/Scheduled/Done):");
                string newStatus = Console.ReadLine();

                (this._engine.WorkItems.First(n => n.Title == parameter && n.GetType().Name == "Feedback") as Feedback)
                    .Status = (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), newStatus, true);
                return $"Changed {parameter} status to {newStatus}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change feedback status.");
            }
        }
    }
}
