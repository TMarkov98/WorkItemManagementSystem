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

        public Team CreateTeam(string name)
        {
            return new Team(name);
        }

        public IWorkItem CreateBug(string title)
        {
            return new Bug(title);
        }

        public IWorkItem CreateStory(string title)
        {
            return new Story(title);
        }

        public IWorkItem CreateFeedback(string title)
        {
            return new Feedback(title);
        }
    }
}
