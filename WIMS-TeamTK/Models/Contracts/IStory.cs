using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        // Properties
        Size Size { get; set; }
        Priority Priority { get; set; }
        StoryStatus Status { get; set; }
        public string Assignee { get; set; }
    }
}
