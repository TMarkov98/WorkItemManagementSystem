using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateMemberCommand : Command
    {
        public CreateMemberCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string name;

            try
            {
                name = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }

            var member = this._factory.CreateMember(name);
            this._engine.Members.Add(member);

            return $"Member with name: {name} and ID: {this._engine.Members.Count} was created.";
        }
    }
}
