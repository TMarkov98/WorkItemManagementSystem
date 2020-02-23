using System;
using System.Collections.Generic;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Providers;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core
{
    public class Engine : IEngine
    {
        private static IEngine instanceHolder;

        private const string TerminationCommand = "Exit";

        private Engine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();

            this.WorkItems = new List<IWorkItem>();
            this.Boards = new List<IBoard>();
            this.Members = new List<IMember>();
            this.Teams = new List<ITeam>();
        }

        public static IEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new Engine();
                }

                return instanceHolder;
            }
        }

        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IParser Parser { get; set; }

        public List<IWorkItem> WorkItems { get; private set; }

        public IList<IBoard> Boards { get; private set; }

        public IList<IMember> Members { get; private set; }

        public IList<ITeam> Teams { get; private set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
    }
}
