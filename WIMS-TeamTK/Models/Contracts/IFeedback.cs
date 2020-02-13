using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        public decimal Rating { get; }
        public FeedbackStatus Status { get; }
    }
}
