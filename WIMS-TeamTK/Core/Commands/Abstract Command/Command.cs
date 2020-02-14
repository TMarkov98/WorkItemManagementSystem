using System;
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
        public Command(IFactory factory, IEngine engine)
        {
            this._factory = factory;
            this._engine = engine;
        }
        public abstract string Execute(IList<string> parameters);
    }
}
