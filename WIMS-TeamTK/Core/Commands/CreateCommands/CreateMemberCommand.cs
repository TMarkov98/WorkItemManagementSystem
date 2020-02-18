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
            string memberName = parameter;
            try
            {
                _validator.ValidateDuplicateMember(this._engine.Members, memberName);
                var member = this._factory.CreateMember(memberName);
                this._engine.Members.Add(member);
                return $"Member with ID: {this._engine.Members.Count - 1} and  name: {parameter} was created.";
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to create member.");
            }


        }
    }
}
