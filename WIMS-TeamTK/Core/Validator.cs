using System;
using System.Collections.Generic;
using System.Linq;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core
{
    public class Validator : IValidator
    {
        public void ValidateDuplicateBoard(IList<IBoard> boards, string boardName)
        {
            if (boards.Any(board => board.Name == boardName.Trim()))
            {
                throw new ArgumentException($"Board {boardName.Trim()} already exists in team.");
            }
        }

        public IBoard ValidateBoardExists(IList<IBoard> boards, string boardName)
        {
            if(!boards.Any(board => board.Name == boardName.Trim()))
            {
                throw new ArgumentException($"Board {boardName} not found.");
            }
            return boards.First(board => board.Name == boardName.Trim());
        }

        public BugStatus ValidateBugStatus(string bugStatus)
        {
            return (BugStatus)Enum.Parse(typeof(BugStatus), bugStatus.Trim(), true);
        }

        public string ValidateDescription(string description)
        {
            if (description.Trim().Length < 10 || description.Trim().Length > 500)
            {
                throw new ArgumentException("Description must be between 10 and 500 symbols.");
            }
            return description;
        }

        public FeedbackStatus ValidateFeedbackStatus(string feedbackStatus)
        {
            return (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), feedbackStatus.Trim(), true);
        }

        public IMember ValidateMemberExists(IList<IMember> members, string memberName)
        {
            if(!members.Any(member => member.Name == memberName.Trim()))
            {
                throw new ArgumentException($"Member {memberName.Trim()} not found.");
            }
            return members.First(member => member.Name == memberName.Trim());
        }

        public IBoard ValidateMoreThanOneBoard(IList<IBoard> boards, string boardName)
        {
            if(boards.Count(board => board.Name == boardName.Trim()) > 1)
            {
                Console.Write("More than one board found. Please use board ID: ");
                int id = int.Parse(Console.ReadLine());
                return boards[id];
            }
            else
            {
                return boards.First(board => board.Name == boardName.Trim());
            }
        }

        public IWorkItem ValidateMoreThanOneWorkItem(IList<IWorkItem> workItems, string workItemName)
        {
            if (workItems.Count(workItem => workItem.Title == workItemName.Trim()) > 1)
            {
                Console.Write("More than one workItem found. Please use workItem ID: ");
                int id = int.Parse(Console.ReadLine());
                return workItems[id];
            }
            else
            {
                return workItems.First(workItem => workItem.Title == workItemName.Trim());
            }
        }

        public Priority ValidatePriority(string priority)
        {
            return (Priority)Enum.Parse(typeof(Priority), priority.Trim(), true);
        }

        public Severity ValidateSeverity(string severity)
        {
            return (Severity)Enum.Parse(typeof(Severity), severity.Trim(), true);
        }

        public Size ValidateSize(string size)
        {
            return (Size)Enum.Parse(typeof(Size), size.Trim(), true);
        }

        public StoryStatus ValidateStoryStatus(string storyStatus)
        {
            return (StoryStatus)Enum.Parse(typeof(StoryStatus), storyStatus.Trim(), true);
        }

        public ITeam ValidateTeamExists(IList<ITeam> teams, string teamName)
        {
            if (!teams.Any(team => team.Name == teamName.Trim()))
            {
                throw new ArgumentException($"Team {teamName.Trim()} not found.");
            }
            return teams.First(team => team.Name == teamName.Trim());
        }

        public string ValidateTitle(string title)
        {
            if (title.Trim().Length < 10 || title.Trim().Length > 50)
            {
                throw new ArgumentException("Title must be between 10 and 50 symbols.");
            }
            return title.Trim();
        }

        public IWorkItem ValidateWorkItemExists(IList<IWorkItem> workItems, string workItemName)
        {
            if (!workItems.Any(workItem => workItem.Title == workItemName.Trim()))
            {
                throw new ArgumentException($"WorkItem {workItemName.Trim()} not found.");
            }
            return workItems.First(workItem => workItem.Title == workItemName.Trim());
        }

        public void ValidateDuplicateMember(IList<IMember> members, string memberName)
        {
            if (members.Any(n => n.Name == memberName.Trim()))
            {
                throw new ArgumentException($"Member with name {memberName.Trim()} already exists.");
            }
        }

        public int ValidateRating(string rating)
        {
            try
            {
                int result = int.Parse(rating.Trim());
                if(result > 10 || result < -10)
                {
                    throw new ArgumentException();
                }
                return result;
            }
            catch
            {
                throw new ArgumentException("Rating was not passed in a correct format. Please provide an integer between -10 and 10.");
            }
        }
        public void ValidateDuplicateTeam(IList<ITeam> teams, string teamName)
        {
            if (teams.Any(n => n.Name == teamName.Trim()))
            {
                throw new ArgumentException($"Team with name {teamName.Trim()} already exists.");
            }
        }

        public string ValidateBoardName(string name)
        {
            if(name.Trim().Length < 5 || name.Trim().Length > 10)
            {
                throw new ArgumentException("Board name should be between 5 and 10 symbols.");
            }
            return name.Trim();
        }

        public string ValidateMemberName(string name)
        {
            if (name.Trim().Length < 5 || name.Trim().Length > 15)
            {
                throw new ArgumentException("Member name should be between 5 and 15 symbols.");
            }
            return name.Trim();
        }
        public string ValidateTeamName(string name)
        {
            if(name.Trim().Length < 5 || name.Trim().Length > 15)
            {
                throw new ArgumentException("Team name should be between 5 and 15 symbols.");
            }
            return name.Trim();
        }
    }
}
