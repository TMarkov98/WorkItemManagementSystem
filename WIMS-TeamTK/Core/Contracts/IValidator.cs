using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IValidator
    {
        public string ValidateTitle(string title);
        public string ValidateDescription(string description);
        public BugStatus ValidateBugStatus(string bugStatus);
        public FeedbackStatus ValidateFeedbackStatus(string feedbackStatus);
        public Priority ValidatePriority(string priority);
        public Severity ValidateSeverity(string severity);
        public Size ValidateSize(string size);
        public StoryStatus ValidateStoryStatus(string storyStatus);
        public IMember ValidateExists(IList<IMember> members, string memberName);
        public IBoard ValidateExists(IList<IBoard> boards, string boardName);
        public IWorkItem ValidateExists(IList<IWorkItem> workItems, string workItemName);
        public ITeam ValidateExists(IList<ITeam> teams, string teamName);
        public IBoard ValidateMoreThanOne(IList<IBoard> boards, string boardName);
        public IWorkItem ValidateMoreThanOne(IList<IWorkItem> workItems, string workItemName);
        public void ValidateDuplicate(IList<IBoard> boards, string boardName);
        public void ValidateDuplicate(IList<IMember> members, string memberName);
        public void ValidateDuplicate(IList<ITeam> teams, string teamName);
        public int ValidateRating(string rating);
        public string ValidateBoardName(string name);
        public string ValidateMemberName(string name);
        public string ValidateTeamName(string name);
    }
}
