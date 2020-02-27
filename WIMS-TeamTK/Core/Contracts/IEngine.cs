using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IEngine
    {
        /// <summary>The actions to take when the engine starts./// </summary>
        void Start();
        /// <summary>The input reader.</summary>
        IReader Reader { get; set; }
        /// <summary>The output writer.</summary>
        IWriter Writer { get; set; }
        /// <summary>The command parser.</summary>
        IParser Parser { get; set; }
        /// <summary>A global list of all WorkItems.</summary>
        List<IWorkItem> WorkItems { get; }
        /// <summary>A global list of all Boards.</summary>
        IList<IBoard> Boards { get; }
        /// <summary>A global list of all Members.</summary>
        IList<IMember> Members { get; }
        /// <summary>A global list of all Teams.</summary>
        IList<ITeam> Teams { get; }
    }
}