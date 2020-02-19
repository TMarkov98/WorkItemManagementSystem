﻿using System;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ChangeCommands
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
                var story = this._validator.ValidateWorkItemExists(this._engine.WorkItems.Where(n => n.GetType().Name == "Story").ToList(), parameter);
                Console.Write("New Story Size(Large/Medium/Small): ");
                string newSize = Console.ReadLine();

                (story as IStory).Size = this._validator.ValidateSize(Console.ReadLine());
                return $"Changed {parameter} size to {(story as IStory).Size}.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to change story size.");
            }
        }
    }
}
