using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        Priority Priority { get; }
        Size Size { get; }
        StoryStatus Status { get; }
    }
}
