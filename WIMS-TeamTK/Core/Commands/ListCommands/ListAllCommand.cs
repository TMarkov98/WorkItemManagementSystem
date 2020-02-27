using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    class ListAllCommand : Command
    {
        public ListAllCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            string result = string.Empty;

            if (this._engine.WorkItems.Count == 0)
            {
                return "No WorkItems added.";
            }
            if (parameter == "")
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
