﻿using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    public abstract class Command : ICommand
    {
        protected readonly IFactory _factory;
        protected readonly IEngine _engine;
        protected readonly IValidator _validator;
        public Command(IFactory factory, IEngine engine)
        {
            this._factory = factory;
            this._engine = engine;
            this._validator = new Validator();
        }
        public abstract string Execute(string parameter);
    }
}
