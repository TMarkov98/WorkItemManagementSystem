using System;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    class CreateMemberCommand : Command
    {
        public CreateMemberCommand(IFactory factory, IEngine engine, IValidator validator)
            : base(factory, engine, validator)
        {
        }

        public override string Execute(string parameter)
        {
            string memberName;
            try
            {
                memberName = this._validator.ValidateMemberName(parameter);
                this._validator.ValidateDuplicate(this._engine.Members, memberName);
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
