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
    class ChangeStorySizeCommand : Command
    {
        public ChangeStorySizeCommand(IFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            try
            {
                if (!this._engine.WorkItems.Any(n => n.Title == parameter && n.GetType().Name == "Story"))
                {
                    throw new ArgumentException($"Story with title {parameter} not found.");
                }
                Console.WriteLine("New Story Size(Large/Medium/Small):");
                string newSize = Console.ReadLine();

                (this._engine.WorkItems.First(n => n.Title == parameter && n.GetType().Name == "Story") as Story)
                    .Size = (Size)Enum.Parse(typeof(Size), newSize, true);
                return $"Changed {parameter} size to {newSize}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change story size.");
            }
        }
    }
}
