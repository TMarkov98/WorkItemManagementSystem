using System;
using System.Linq;
using System.Reflection;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Providers
{
    public class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            var command = Activator.CreateInstance(commandTypeInfo, Factory.Instance, Engine.Instance) as ICommand;

            return command;
        }

        public string ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').Skip(1).ToList();
            var parameter = string.Join(' ', commandParts);

            if (commandParts.Count() == 0)
            {
                return "";
            }

            return parameter;
        }

        private TypeInfo FindCommand(string commandName)
        {
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
