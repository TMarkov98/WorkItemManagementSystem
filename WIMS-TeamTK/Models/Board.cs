using System;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Board : Resource, IBoard
    {
        public Board(string name)
            : base(name)
        {
        }
    }
}
