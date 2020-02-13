using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Factories
{
    public interface IFactory
    {
        public Member CreateMember(string name, List<WorkItem> workItems, List<string> activityHistory);
        public Board CreateBoard(string name, List<WorkItem> workItems, List<string> activityHistory);
        public Team CreateTeam(string name, List<Member> members, List<Board> boards);
        public IWorkItem CreateBug(string title, string description, List<string> stepsToReproduce);
        public IWorkItem CreateStory(string title, string description, Priority priority, Size size, StoryStatus status);
        public IWorkItem CreateFeedback(string title, string description, int rating, FeedbackStatus status);
    }
}
