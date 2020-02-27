namespace WIMS_TeamTK.Core.Contracts
{
    public interface IWriter
    {
        /// <summary>
        /// Writes a message to the output.
        /// </summary>
        /// <param name="message">The message to write.</param>
        void Write(string message);
        /// <summary>
        /// Writes a line containing a message to the output.
        /// </summary>
        /// <param name="message">The message to write.</param>
        void WriteLine(string message);
    }
}
