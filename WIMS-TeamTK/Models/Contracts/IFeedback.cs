using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        decimal Rating();
        FeedbackStatus Status();
    }
}
