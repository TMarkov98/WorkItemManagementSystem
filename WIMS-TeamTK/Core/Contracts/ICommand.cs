namespace WIMS_TeamTK.Core.Contracts
{
    public interface ICommand
    {
        /// <summary>Executes a command with the given parameter.</summary>
        string Execute(string parameter);
    }
}
