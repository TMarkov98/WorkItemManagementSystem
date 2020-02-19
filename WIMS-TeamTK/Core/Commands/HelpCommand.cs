using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;

namespace WIMS_TeamTK.Core.Commands
{
    class HelpCommand : Command
    {
        public HelpCommand(IFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(string parameter)
        {
            string result = "";
            result += $"### Commands List ###:{Environment.NewLine}"
            + $"=== Create Commands:{Environment.NewLine}"
            + $"- CreateTeam (TeamName){Environment.NewLine}"
            + $"- CreateBoard (BoardName){Environment.NewLine}"
            + $"- CreateMember (MemberName){Environment.NewLine}"
            + $"- CreateBug (BugName){Environment.NewLine}"
            + $"- CreateStory (StoryName){Environment.NewLine}"
            + $"- CreateFeedback (FeedbackName){Environment.NewLine}"
            + $"=== Change Commands:{Environment.NewLine}"
            + $"- ChangeBugPriority (BugName){Environment.NewLine}"
            + $"- ChangeBugSeverity (BugName){Environment.NewLine}"
            + $"- ChangeBugStatus (BugName){Environment.NewLine}"
            + $"- ChangeFeedbackRating (FeedbackName){Environment.NewLine}"
            + $"- ChangeFeedbackStatus (FeedbackName){Environment.NewLine}"
            + $"- ChangeStoryPriority (StoryName){Environment.NewLine}"
            + $"- ChangeStorySize (StoryName){Environment.NewLine}"
            + $"- ChangeStoryStatus (StoryName){Environment.NewLine}"
            + $"=== Add Commands: {Environment.NewLine}"
            + $"- AddComment (WorkItemName){Environment.NewLine}"
            + $"- AddToTeam (TeamName){Environment.NewLine}"
            + $"- AssignTo (MemberName){Environment.NewLine}"
            + $"=== List and Show Commands:{Environment.NewLine}"
            + $"- ListAll{Environment.NewLine}"
            + $"- ListBugs{Environment.NewLine}"
            + $"- ListBugs (Sort/Filter){Environment.NewLine}"
            + $"- ListFeedbacks{Environment.NewLine}"
            + $"- ListFeedbacks (Sort/Filter){Environment.NewLine}"
            + $"- ListStories{Environment.NewLine}"
            + $"- ListStories (Sort/Filter){Environment.NewLine}"
            + $"- ShowBoardActivity (BoardName){Environment.NewLine}"
            + $"- ShowMemberActivity (MemberName){Environment.NewLine}"
            + $"- ShowTeamActivity (TeamName){Environment.NewLine}"
            + $"- ShowTeamBoards (TeamName){Environment.NewLine}"
            + $"- ShowTeamMembers (TeamName){Environment.NewLine}"
            + $"- ShowTeams{Environment.NewLine}"
            + $"- ShowPeople{Environment.NewLine}";
            return result;
        }
    }
}
