using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Factories
{
    public class Factory : IFactory
    {
        private static IFactory instanceHolder = new Factory();

        private Factory()
        {
        }

        public static IFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }
        public Member CreateMember(string name)
        {
            return new Member(name);
        }

        public Board CreateBoard(string name)
        {
            return new Board(name);
        }

        public Team CreateTeam(string name, List<Member> members, List<Board> boards)
        {
            return new Team(name, members, boards);
        }

        public IWorkItem CreateBug(string title, string description, List<string> stepsToReproduce)
        {
            return new Bug(title, description, stepsToReproduce);
        }

        public IWorkItem CreateStory(string title, string description, Priority priority, Size size, StoryStatus status)
        {
            return new Story(title, description, priority, size, status);
        }

        public IWorkItem CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            return new Feedback(title, description, rating, status);
        }
    }
}
