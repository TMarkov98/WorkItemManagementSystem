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
            switch (parameter.ToLower())
            {
                case "create":
                    return
                        $"=== Create Commands:{Environment.NewLine}"
                        + $"- CreateTeam (TeamName){Environment.NewLine}"
                        + $"- CreateBoard (BoardName){Environment.NewLine}"
                        + $"- CreateMember (MemberName){Environment.NewLine}"
                        + $"- CreateBug (BugName){Environment.NewLine}"
                        + $"- CreateStory (StoryName){Environment.NewLine}"
                        + $"- CreateFeedback (FeedbackName)";
                case "change":
                    return
                        $"=== Change Commands:{Environment.NewLine}"
                        + $"- ChangeBugPriority (BugName){Environment.NewLine}"
                        + $"- ChangeBugSeverity (BugName){Environment.NewLine}"
                        + $"- ChangeBugStatus (BugName){Environment.NewLine}"
                        + $"- ChangeFeedbackRating (FeedbackName){Environment.NewLine}"
                        + $"- ChangeFeedbackStatus (FeedbackName){Environment.NewLine}"
                        + $"- ChangeStoryPriority (StoryName){Environment.NewLine}"
                        + $"- ChangeStorySize (StoryName){Environment.NewLine}"
                        + $"- ChangeStoryStatus (StoryName)";
                case "add":
                    return
                        $"=== Add Commands: {Environment.NewLine}"
                        + $"- AddComment (WorkItemName){Environment.NewLine}"
                        + $"- AddToTeam (TeamName){Environment.NewLine}"
                        + $"- AssignTo (MemberName)";
                case "list":
                    return
                        $"=== List Commands:{Environment.NewLine}"
                        + $"- ListAll{Environment.NewLine}"
                        + $"- ListBugs{Environment.NewLine}"
                        + $"- ListBugs (Sort/Filter){Environment.NewLine}"
                        + $"- ListFeedbacks{Environment.NewLine}"
                        + $"- ListFeedbacks (Sort/Filter){Environment.NewLine}"
                        + $"- ListStories{Environment.NewLine}"
                        + $"- ListStories (Sort/Filter)";
                case "show":
                    return
                        $"=== List Commands:{Environment.NewLine}"
                        + $"- ShowBoardActivity (BoardName){Environment.NewLine}"
                        + $"- ShowMemberActivity (MemberName){Environment.NewLine}"
                        + $"- ShowTeamActivity (TeamName){Environment.NewLine}"
                        + $"- ShowTeamBoards (TeamName){Environment.NewLine}"
                        + $"- ShowTeamMembers (TeamName){Environment.NewLine}"
                        + $"- ShowTeams{Environment.NewLine}"
                        + $"- ShowPeople{Environment.NewLine}"
                        + $"- ShowItemHistory (WorkItemName){Environment.NewLine}"
                        + $"- ShowBoardItems (BoardName){Environment.NewLine}"
                        + $"- ShowMemberComments (MemberName)";

                default:
                    return
                        $"Thank you for using our solution.{Environment.NewLine}"
                        + $"You can begin by creating a team and adding boards and members to it.{Environment.NewLine}"
                        + $"CreateTeam (TeamName){Environment.NewLine}"
                        + $"CreateBoard (BoardName) {Environment.NewLine}"
                        + $"CreateMember (MemberName) {Environment.NewLine}"
                        + $"Then, you can add items to the board. For a full list of commands, please type in:{Environment.NewLine}"
                        + $"help create - List all create commands.{Environment.NewLine}"
                        + $"help add - List all add/assign commands.{Environment.NewLine}"
                        + $"help change - List all change commands.{Environment.NewLine}"
                        + $"help list - List all list commands.{Environment.NewLine}"
                        + $"help show - List all show commands.";
            }
        }
    }
}
