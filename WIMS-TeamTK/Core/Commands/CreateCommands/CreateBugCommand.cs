using System;
using System.Collections.Generic;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateBugCommand : Command
    {
        public CreateBugCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            string title;
            string description;
            List<string> stepsToReproduce = new List<string>();
            Priority priority;
            Severity severity;
            BugStatus status;
            string boardName;

            try
            {
                title = this._validator.ValidateTitle(parameter);
                Console.Write("Board: ");
                boardName = Console.ReadLine().Trim();
                var board = _validator.ValidateExists(this._engine.Boards, boardName);
                board = _validator.ValidateMoreThanOne(this._engine.Boards, boardName);
                Console.Write("Bug Description(Single line.): ");
                description = _validator.ValidateDescription(Console.ReadLine().Trim());
                Console.WriteLine("Steps to reproduce(Reads until it reaches an empty line.):");
                string input = Console.ReadLine().Trim();
                while (input != string.Empty)
                {
                    stepsToReproduce.Add(input);
                    input = Console.ReadLine().Trim();
                }
                Console.Write("Bug Priority(High/Medium/Low): ");
                priority = this._validator.ValidatePriority(Console.ReadLine().Trim());
                Console.Write("Bug Severity(Critical/Major/Minor): ");
                severity = this._validator.ValidateSeverity(Console.ReadLine().Trim());
                Console.Write("Bug Status(Active/Fixed): ");
                status = this._validator.ValidateBugStatus(Console.ReadLine().Trim());
                IBug bug = this._factory.CreateBug(title, description, stepsToReproduce, priority, severity, status);
                this._engine.WorkItems.Add(bug);
                board.AddWorkItem(bug);
                return $"Bug with ID {this._engine.WorkItems.Count - 1}, Title {bug.Title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create bug.");
            }
        }
    }
}
