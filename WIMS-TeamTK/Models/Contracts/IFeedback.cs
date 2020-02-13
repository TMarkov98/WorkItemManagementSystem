using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        public int Rating { get; }
        public FeedbackStatus Status { get; }
    }
}
