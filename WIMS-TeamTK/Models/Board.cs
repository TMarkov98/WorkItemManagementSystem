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

        public override string Name
        {
            get => this._name;
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Name must be between 5 and 10 symbols.");
                }
                this._name = value;
            }
        }
    }
}
