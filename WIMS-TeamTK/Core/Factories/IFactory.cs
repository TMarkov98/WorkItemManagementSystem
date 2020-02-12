using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Factories
{
    public interface IFactory
    {
        public Member CreateMember();
        public Board CreateBoard();
        public Team CreateTeam();
        public IWorkItem CreateBug();
        public IWorkItem CreateStory();
        public IWorkItem CreateFeedback();
    }
}
