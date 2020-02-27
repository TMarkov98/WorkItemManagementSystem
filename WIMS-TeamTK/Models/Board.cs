using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Board : Resource, IBoard
    {
        /// <summary>
        /// Constructor of Board
        /// </summary>
        /// <param name="name"></param>
        public Board(string name)
            : base(name)
        {
        }
    }
}
