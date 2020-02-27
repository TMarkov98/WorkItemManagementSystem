using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IValidator
    {
        public string ValidateTitle(string title);
        /// <summary>
        /// Validates the Description of a WorkItem.
        /// </summary>
        /// <param name="description">The description provided.</param>
        /// <returns>A string containing the description if it is valid or an error if it is invalid.</returns>
        public string ValidateDescription(string description);
        /// <summary>
        /// Validates the Status property of a Bug.
        /// </summary>
        /// <param name="bugStatus">The Status provided.</param>
        /// <returns>The BugStatus as an Enum if the provided string was valid, or an error if it was not.</returns>
        public BugStatus ValidateBugStatus(string bugStatus);
        /// <summary>
        /// Validates the Status property of a Feedback.
        /// </summary>
        /// <param name="feedbackStatus">The Status provided.</param>
        /// <returns>The FeedbackStatus as an Enum if the provided string was valid, or an error if it was not.</returns>
        public FeedbackStatus ValidateFeedbackStatus(string feedbackStatus);
        /// <summary>
        /// Validates the Priority property of a WorkItem.
        /// </summary>
        /// <param name="priority">The Priority provided.</param>
        /// <returns>The Priority as an Enum if the provided string was valid, or an error if it was not.</returns>
        public Priority ValidatePriority(string priority);
        /// <summary>
        /// Validates the Severity property of a WorkItem.
        /// </summary>
        /// <param name="severity">The Severity provided.</param>
        /// <returns>The Severity as an Enum if the provided string was valid, or an error if it was not.</returns>
        public Severity ValidateSeverity(string severity);
        /// <summary>
        /// Validates the Size property of a Story.
        /// </summary>
        /// <param name="size">The Size provided.</param>
        /// <returns>The Size as an Enum if the provided string was valid, or an error if it was not.</returns>
        public Size ValidateSize(string size);
        /// <summary>
        /// Validates the Status property of a Story.
        /// </summary>
        /// <param name="storyStatus">The Status provided.</param>
        /// <returns>The Status as an Enum if the provided string was valid, or an error if it was not.</returns>
        public StoryStatus ValidateStoryStatus(string storyStatus);
        /// <summary>
        /// Validates the Rating property of a Feedback.
        /// </summary>
        /// <param name="rating">The Rating provided.</param>
        /// <returns>An int value containing the rating if the provided string was valid, or throws an error if it was not.</returns>
        public int ValidateRating(string rating);
        /// <summary>
        /// Validates if a Member exists in a list by their name.
        /// </summary>
        /// <param name="members">The list containing members.</param>
        /// <param name="memberName">The name of the target member.</param>
        /// <returns>The Member if the name was valid, or an error if they were not found.</returns>
        /// 
        public IMember ValidateExists(IList<IMember> members, string memberName);
        /// <summary>
        /// Validates if a Board exists in a list by its name.
        /// </summary>
        /// <param name="boards">The list containing boards.</param>
        /// <param name="boardName">The name of the target board.</param>
        /// <returns>The Board if the name was valid, or an error if they were not found.</returns>
        public IBoard ValidateExists(IList<IBoard> boards, string boardName);
        /// <summary>
        /// Validates if a WorkItem exists in a list by its title.
        /// </summary>
        /// <param name="workItems">The list containing workItems.</param>
        /// <param name="workItemTitle">The name of the target workItem.</param>
        /// <returns>The WorkItem if the title was valid, or an error if it was not found.</returns>
        public IWorkItem ValidateExists(IList<IWorkItem> workItems, string workItemTitle);
        /// <summary>
        /// Validates if a Team exists in a list by its name.
        /// </summary>
        /// <param name="teams">The list containing teams.</param>
        /// <param name="teamName">The name of the target team.</param>
        /// <returns>The Team if the title was valid, or an error if it was not found.</returns>
        public ITeam ValidateExists(IList<ITeam> teams, string teamName);
        /// <summary>
        /// Asks which board to target if more than one board with the same name exists.
        /// </summary>
        /// <param name="boards">The list containing boards.</param>
        /// <param name="boardName">The name of the target board.</param>
        /// <returns>The Board if there is only one in the global list, or asks for the Board ID if there is more than one.</returns>
        public IBoard ValidateMoreThanOne(IList<IBoard> boards, string boardName);
        /// <summary>
        /// Asks which workItem to target if more than one workItem with the same title exists.
        /// </summary>
        /// <param name="workItems">The list containing workItems.</param>
        /// <param name="workItemTitle">The title of the target workItem.</param>
        /// <returns>The WorkItem if there is only one in the global list, or asks for the WorkItem ID if there is more than one.</returns>
        public IWorkItem ValidateMoreThanOne(IList<IWorkItem> workItems, string workItemTitle);
        /// <summary>
        /// Throws an error if a board already exists within a list.
        /// </summary>
        /// <param name="boards">The list containing boards.</param>
        /// <param name="boardName">The name of the Board.</param>
        public void ValidateDuplicate(IList<IBoard> boards, string boardName);
        /// <summary>
        /// Throws an error if a member already exists within a list.
        /// </summary>
        /// <param name="members">The list containing members.</param>
        /// <param name="memberName">The name of the Member.</param>
        public void ValidateDuplicate(IList<IMember> members, string memberName);
        /// <summary>
        /// Throws an error if a team already exists within a list.
        /// </summary>
        /// <param name="teams">The list containing members.</param>
        /// <param name="teamName">The name of the Team.</param>
        public void ValidateDuplicate(IList<ITeam> teams, string teamName);
        /// <summary>
        /// Validates the name of a Board.
        /// </summary>
        /// <param name="name">The name provided.</param>
        /// <returns>A string containing the name if it is valid or an error if it is invalid.</returns>
        public string ValidateBoardName(string name);
        /// <summary>
        /// Validates the name of a Member
        /// </summary>
        /// <param name="name">The name provided.</param>
        /// <returns>A string containing the name if it is valid or an error if it is invalid.</returns>
        public string ValidateMemberName(string name);
        /// <summary>
        /// Validates the name of a Team.
        /// </summary>
        /// <param name="name">The name provided.</param>
        /// <returns>A string containing the name if it is valid or an error if it is invalid.</returns>
        public string ValidateTeamName(string name);
    }
}
