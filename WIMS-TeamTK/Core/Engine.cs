using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Providers;
using WIMS_TeamTK.Models;
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
            this.Members = instanceHolder.LoadMembers();
            this.Teams = instanceHolder.LoadTeams();
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
                        Console.Write("Saving files "); Thread.Sleep(500);
                        Console.Write(" ."); Thread.Sleep(500);
                        Console.Write(" ."); Thread.Sleep(500);
                        Console.WriteLine(" ."); Thread.Sleep(500);
                        Console.WriteLine("Files saved!"); Thread.Sleep(1000);
                        Console.WriteLine("Exiting program!");
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
            instanceHolder.SaveMembers();
            instanceHolder.SaveTeams();
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
