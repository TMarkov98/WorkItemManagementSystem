using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }


        IList<Board> Boards { get; }

        IList<Member> Members { get; }

        IList<Team> Teams { get; }
    }
}