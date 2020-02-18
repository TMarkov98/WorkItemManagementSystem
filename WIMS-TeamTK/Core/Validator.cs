﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core
{
    public class Validator : IValidator
    {
        public void ValidateDuplicateBoard(IList<IBoard> boards, string boardName)
        {
            if (boards.Any(board => board.Name == boardName))
            {
                throw new ArgumentException($"Board {boardName} already exists in team.");
            }
        }

        public IBoard ValidateBoardExists(IList<IBoard> boards, string boardName)
        {
            if(!boards.Any(board => board.Name == boardName))
            {
                throw new ArgumentException($"Board {boardName} not found.");
            }
            return boards.First(board => board.Name == boardName);
        }

        public BugStatus ValidateBugStatus(string bugStatus)
        {
            return (BugStatus)Enum.Parse(typeof(BugStatus), bugStatus, true);
        }

        public string ValidateDescription(string description)
        {
            if (description.Length < 10 || description.Length > 500)
            {
                throw new ArgumentException("Description must be between 10 and 500 symbols.");
            }
            return description;
        }

        public FeedbackStatus ValidateFeedbackStatus(string feedbackStatus)
        {
            return (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), feedbackStatus, true);
        }

        public IMember ValidateMemberExists(IList<IMember> members, string memberName)
        {
            if(!members.Any(member => member.Name == memberName))
            {
                throw new ArgumentException($"Member {memberName} not found.");
            }
            return members.First(member => member.Name == memberName);
        }

        public IBoard ValidateMoreThanOneBoard(IList<IBoard> boards, string boardName)
        {
            if(boards.Count(board => board.Name == boardName) > 1)
            {
                Console.Write("More than one board found. Please use board ID: ");
                int id = int.Parse(Console.ReadLine());
                return boards[id];
            }
            else
            {
                return boards.First(board => board.Name == boardName);
            }
        }

        public IWorkItem ValidateMoreThanOneWorkItem(IList<IWorkItem> workItems, string workItemName)
        {
            if (workItems.Count(workItem => workItem.Title == workItemName) > 1)
            {
                Console.Write("More than one workItem found. Please use workItem ID: ");
                int id = int.Parse(Console.ReadLine());
                return workItems[id];
            }
            else
            {
                return workItems.First(workItem => workItem.Title == workItemName);
            }
        }

        public Priority ValidatePriority(string priority)
        {
            return (Priority)Enum.Parse(typeof(Priority), priority, true);
        }

        public Severity ValidateSeverity(string severity)
        {
            return (Severity)Enum.Parse(typeof(Severity), severity, true);
        }

        public Size ValidateSize(string size)
        {
            return (Size)Enum.Parse(typeof(Size), size, true);
        }

        public StoryStatus ValidateStoryStatus(string storyStatus)
        {
            return (StoryStatus)Enum.Parse(typeof(StoryStatus), storyStatus, true);
        }

        public ITeam ValidateTeamExists(IList<ITeam> teams, string teamName)
        {
            if (!teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException($"Team {teamName} not found.");
            }
            return teams.First(team => team.Name == teamName);
        }

        public string ValidateTitle(string title)
        {
            if (title.Length < 10 || title.Length > 50)
            {
                throw new ArgumentException("Title must be between 10 and 50 symbols.");
            }
            return title;
        }

        public IWorkItem ValidateWorkItemExists(IList<IWorkItem> workItems, string workItemName)
        {
            if (!workItems.Any(workItem => workItem.Title == workItemName))
            {
                throw new ArgumentException($"WorkItem {workItemName} not found.");
            }
            return workItems.First(workItem => workItem.Title == workItemName);
        }

        public void ValidateDuplicateMember(IList<IMember> members, string memberName)
        {
            if (members.Any(n => n.Name == memberName))
            {
                throw new ArgumentException($"Member with name {memberName} already exists.");
            }
        }

        public int ValidateRating(string rating)
        {
            try
            {
                int result = int.Parse(Console.ReadLine());
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
            if (teams.Any(n => n.Name == teamName))
            {
                throw new ArgumentException($"Team with name {teamName} already exists.");
            }
        }
    }
}