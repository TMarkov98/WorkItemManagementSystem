using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ListAllCommand : Command
    {
        public ListAllCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string result = string.Empty;
            if(parameter == "")
            {
                result = string.Join($"{Environment.NewLine}============={Environment.NewLine}", this._engine.WorkItems
                    .Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
            }
            else if(parameter.ToLower() == "title")
            {
                result = string.Join($"{Environment.NewLine}============={Environment.NewLine}", this._engine.WorkItems
                    .OrderBy(n => n.Title).Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
            }
            else
            {
                Console.WriteLine($"{parameter} is not a valid field to sort by. Printing by default(ID).");
                result = string.Join($"{Environment.NewLine}============={Environment.NewLine}", this._engine.WorkItems
                    .Select((workItem) => $"ID: {this._engine.WorkItems.IndexOf(workItem)} - {workItem.ToString()}").ToArray());
            }
            return result;
        }
    }
}
