using WIMS_TeamTK.Models.Enums;
using WIMS_TeamTK.Models;
using System.Collections.Generic;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IWorkItem
    {
        public string Title { get; }
        public string Description { get; }
        public string ToString();
        public List<IComment> Comments { get; }
        public List<string> History { get; }
        public void AddComment(IComment comment);
    }
}
