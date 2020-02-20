using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        public int Rating { get; set; }
        public FeedbackStatus Status { get; set; }
    }
}
