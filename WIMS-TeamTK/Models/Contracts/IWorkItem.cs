using WIMS_TeamTK.Models.Enums;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IWorkItem
    {
        public string Title { get; }
        public string Description { get; }
        public string ToString();
        public ulong Id { get; }
        public void AddComment(Comment comment);
    }
}
