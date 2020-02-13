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
        public Member CreateMember(string name, List<WorkItem> workItems, List<string> activityHistory)
        {
            return new Member(name, workItems, activityHistory);
        }

        public Board CreateBoard(string name, List<WorkItem> workItems, List<string> activityHistory)
        {
            return new Board(name, workItems, activityHistory);
        }

        public Team CreateTeam()
        {
            //TODO Implement this
            return new Team();
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
