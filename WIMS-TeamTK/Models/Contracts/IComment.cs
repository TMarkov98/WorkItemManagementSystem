using System;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IComment
    {
        // Properties
        string Author { get; set; }
        string Message { get; set; }
        DateTime CreatedOn { get; }
        // Methods
        string ToString();
    }
}
