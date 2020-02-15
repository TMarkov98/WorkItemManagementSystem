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
        public Member CreateMember(string name);
        public Board CreateBoard(string name);
        public Team CreateTeam(string name);
        public IWorkItem CreateBug(string title);
        public IWorkItem CreateStory(string title);
        public IWorkItem CreateFeedback(string title);
    }
}
