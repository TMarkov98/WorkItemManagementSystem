﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;

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
                Console.Write("Bug Description: ");
                description = Console.ReadLine();
                Console.WriteLine("Steps to reproduce:");
                string input = Console.ReadLine();
                while(input != "")
                {
                    stepsToReproduce.Add(input);
                    input = Console.ReadLine();
                }
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBug command parameters.");
            }

            var bug = this._factory.CreateBug(title, description, stepsToReproduce) as Bug;
            this._engine.WorkItems.Add(bug);

            return $"Bug with Title {bug.Title} was created.";
        }
    }
}
