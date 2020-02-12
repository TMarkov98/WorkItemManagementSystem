using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Factories
{
    public class Factory : IFactory
    {
        public Member CreateMember()
        {
            //TODO: Implement this
            return new Member();
        }

        public Board CreateBoard()
        {
            //TODO Implement this
            return new Board();
        }

        public Team CreateTeam()
        {
            //TODO Implement this
            return new Team();
        }

        public IWorkItem CreateBug()
        {
            //TODO: Implement this
            return new Bug();
        }

        public IWorkItem CreateStory()
        {
            //TODO: Implement this
            return new Story();
        }

        public IWorkItem CreateFeedback()
        {
            //TODO Implement this
            return new Feedback();
        }
    }
}
