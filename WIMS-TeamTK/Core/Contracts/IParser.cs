namespace WIMS_TeamTK.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        string ParseParameters(string fullCommand);
    }
}
