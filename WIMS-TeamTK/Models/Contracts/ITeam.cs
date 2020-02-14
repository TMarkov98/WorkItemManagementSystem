using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Models.Contracts
{
    interface ITeam
    {
        public string Name { get; }
        public List<Member> Members { get; }
        public List<Board> Boards { get; }
        public string ToString();
    }
}
