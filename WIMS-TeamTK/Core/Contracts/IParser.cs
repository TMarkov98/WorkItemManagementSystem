namespace WIMS_TeamTK.Core.Contracts
{
    public interface IParser
    {
        /// <summary>
        /// Parses a provided command.
        /// </summary>
        /// <param name="fullCommand">The command string.</param>
        /// <returns>The parsed command as ICommand.</returns>
        ICommand ParseCommand(string fullCommand);
        /// <summary>
        /// Parses all given parameters in a command.
        /// </summary>
        /// <param name="fullCommand">The command string.</param>
        /// <returns>A string with only the parameters in the command.</returns>
        string ParseParameters(string fullCommand);
    }
}
