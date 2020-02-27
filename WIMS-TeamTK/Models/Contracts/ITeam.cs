using System.Collections.Generic;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface ITeam
    {
        // Properties
        public string Name { get; }
        public List<IBoard> Boards { get; }
        public List<IMember> Members { get; }
        public List<string> ActivityHistory { get; }
        // Methods
        public string ToString();
        public void AddBoard(IBoard board);
        public void AddMember(IMember member);
    }
}
