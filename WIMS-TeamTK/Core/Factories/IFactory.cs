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
        public IMember CreateMember(string name);
        public IBoard CreateBoard(string name);
        public ITeam CreateTeam(string name);
        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status);
        public IStory CreateStory(string title, string description, Priority priority, Size size, StoryStatus status);
        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status);
        public IComment CreateComment(string author, string message);
    }
}
