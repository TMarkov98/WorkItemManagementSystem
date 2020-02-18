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
    class CreateBugCommand : Command
    {
        public CreateBugCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string title = parameter;
            string description;
            List<string> stepsToReproduce = new List<string>();
            Priority priority;
            Severity severity;
            BugStatus status;
            string boardName;

            try
            {
                Console.Write("Board: ");
                boardName = Console.ReadLine();
                var board = _validator.ValidateBoardExists(this._engine.Boards, boardName);
                board = _validator.ValidateMoreThanOneBoard(this._engine.Boards, boardName);
                Console.Write("Bug Description(Single line.): ");
                description = _validator.ValidateDescription(Console.ReadLine());
                Console.WriteLine("Steps to reproduce(Reads until it reaches an empty line.):");
                string input = Console.ReadLine();
                while(input != string.Empty)
                {
                    stepsToReproduce.Add(input);
                    input = Console.ReadLine();
                }
                Console.WriteLine("Bug Priority(High/Medium/Low):");
                priority = this._validator.ValidatePriority(Console.ReadLine());
                Console.WriteLine("Bug Severity(Critical/Major/Minor):");
                severity = this._validator.ValidateSeverity(Console.ReadLine());
                Console.WriteLine("Bug Status(Active/Fixed):");
                status = this._validator.ValidateBugStatus(Console.ReadLine());
                Bug bug = (Bug)this._factory.CreateBug(title, description, stepsToReproduce, priority, severity, status);
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
