﻿using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    public abstract class Command : ICommand
    {
        protected readonly IFactory _factory;
        protected readonly IEngine _engine;
        protected readonly IValidator _validator;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory">Factory to use</param>
        /// <param name="engine">Engine to use</param>
        /// <param name="validator">Validator to use</param>
        public Command(IFactory factory, IEngine engine, IValidator validator)
        {
            this._factory = factory;
            this._engine = engine;
            this._validator = validator;
        }

        /// <summary>
        /// Executes a command with the given parameter.
        /// </summary>
        /// <param name="parameter">The given parameter.</param>
        /// <returns></returns>
        public abstract string Execute(string parameter);
    }
}
