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
            string title;
            string boardname;
            List<string> stepsToReproduce = new List<string>();

            try
            {
                //TODO: Check if bug is unique in board.
                title = parameter;
                Bug bug = (Bug)this._factory.CreateBug(title);
                Console.Write("Board: ");
                boardname = Console.ReadLine();
                if (this._engine.Boards.Count(n=>n.Name == boardname) > 1)
                {
                    Console.Write("More than one board found. Please use board's ID: ");
                    var boardId = int.Parse(Console.ReadLine());
                    this._engine.Boards[boardId].WorkItems.Add(bug);
                }
                else if (this._engine.Boards.Count(n => n.Name == boardname) < 1)
                {
                    throw new ArgumentException($"Board {boardname} not found.");
                }
                else
                {
                    this._engine.Boards.FirstOrDefault(n => n.Name == boardname).WorkItems.Add(bug);
                }
                Console.Write("Bug Description(Single line.): ");
                bug.Description = Console.ReadLine();
                Console.WriteLine("Steps to reproduce(Reads until it reaches an empty line.):");
                string input = Console.ReadLine();
                while(input != string.Empty)
                {
                    stepsToReproduce.Add(input);
                    input = Console.ReadLine();
                }
                bug.StepsToReproduce = stepsToReproduce;
                Console.WriteLine("Bug Priority(High/Medium/Low):");
                bug.Priority = (Priority)Enum.Parse(typeof(Priority), Console.ReadLine(), true);
                Console.WriteLine("Bug Severity(Critical/Major/Minor):");
                bug.Severity = (Severity)Enum.Parse(typeof(Severity), Console.ReadLine(), true);
                Console.WriteLine("Bug Status(Active/Fixed):");
                bug.Status = (BugStatus)Enum.Parse(typeof(BugStatus), Console.ReadLine(), true);
                this._engine.WorkItems.Add(bug);
                return $"Bug with ID {this._engine.WorkItems.Count - 1}, Title {bug.Title} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message + "\nIncorrect values passed when creating bug. Bug was not created.");
            }
        }
    }
}
