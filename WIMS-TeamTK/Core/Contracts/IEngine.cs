using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }

        List<IWorkItem> WorkItems { get; }

        IList<IBoard> Boards { get; }

        IList<IMember> Members { get; }

        IList<ITeam> Teams { get; }
    }
}