using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        Priority Priority { get; set;  }
        Size Size { get; set; }
        StoryStatus Status { get; set; }
        public string Assignee { get; set; }
    }
}
