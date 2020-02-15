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

        public override string Execute(IList<string> parameters)
        {
            string title;
            string description;
            List<string> stepsToReproduce = new List<string>();

            try
            {
                title = string.Join(" ", parameters);
                Bug bug = (Bug)this._factory.CreateBug(title);
                Console.Write("Bug Description(Single line.): ");
                description = Console.ReadLine();
                Console.WriteLine("Steps to reproduce(Reads until it reaches an empty line.):");
                string input = Console.ReadLine();
                while(input != "")
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
            catch
            {
                throw new ArgumentException("Incorrect values passed when creating bug. Bug was not created.");
            }
        }
    }
}
