using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Models.Contracts
{
    public interface IComment
    {
        string Author { get; set; }
        string Message { get; set; }
        DateTime CreatedOn { get; }
        string ToString();
    }
}
