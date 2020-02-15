using System;
using System.Collections.Generic;
using System.Linq;
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

        public override string Execute(string parameter)
        {

            try
            {
                if(this._engine.Members.Any(n => n.Name == parameter))
                {
                    throw new ArgumentException($"Member with name {parameter} already exists.");
                }
                var member = this._factory.CreateMember(parameter);
                this._engine.Members.Add(member);
                return $"Member with ID: {this._engine.Members.Count - 1} and  name: {parameter} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}{Environment.NewLine}Unable to create member.");
            }


        }
    }
}
