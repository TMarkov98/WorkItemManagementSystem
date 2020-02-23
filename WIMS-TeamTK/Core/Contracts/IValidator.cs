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
        public IMember ValidateMemberExists(IList<IMember> members, string memberName);
        public IBoard ValidateBoardExists(IList<IBoard> boards, string boardName);
        public IWorkItem ValidateWorkItemExists(IList<IWorkItem> workItems, string workItemName);
        public ITeam ValidateTeamExists(IList<ITeam> teams, string teamName);
        public IBoard ValidateMoreThanOneBoard(IList<IBoard> boards, string boardName);
        public IWorkItem ValidateMoreThanOneWorkItem(IList<IWorkItem> workItems, string workItemName);
        public void ValidateDuplicateBoard(IList<IBoard> boards, string boardName);
        public void ValidateDuplicateMember(IList<IMember> members, string memberName);
        public int ValidateRating(string rating);
        public void ValidateDuplicateTeam(IList<ITeam> teams, string teamName);
        public string ValidateBoardName(string name);
        public string ValidateMemberName(string name);
    }
}
