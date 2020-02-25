using System.Collections.Generic;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Factories
{
    public class Factory : IFactory
    {
        private static IFactory instanceHolder = new Factory();

        public Factory()
        {
        }

        public static IFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }

        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status)
        {
            return new Bug(title, description, stepsToReproduce, priority, severity, status);
        }

        public IStory CreateStory(string title, string description, Priority priority, Size size, StoryStatus status)
        {
            return new Story(title, description, priority, size, status);
        }

        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            return new Feedback(title, description, rating, status);
        }
        public IComment CreateComment(string author, string message)
        {
            return new Comment(author, message);
        }
    }
}
