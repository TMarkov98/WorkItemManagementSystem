using System.Collections.Generic;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; }
        public List<IMember> Members { get; }
        public List<IBoard> Boards { get; }
        public string ToString();
        public void AddBoard(IBoard board);
        public void AddMember(IMember member);
        public List<string> ActivityHistory { get; }
    }
}
