using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IWorkItem
    {
        public string Title { get; }
        public string Description { get; }
    }
}
