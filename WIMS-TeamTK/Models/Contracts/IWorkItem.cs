using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IWorkItem
    {
        string Title();
        string Description();
    }
}
