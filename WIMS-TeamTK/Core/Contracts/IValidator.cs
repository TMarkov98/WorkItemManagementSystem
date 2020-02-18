using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Core.Contracts
{
    public interface IValidator
    {
        public string ValidateTitle(string title);
        public string ValidateDescription(string description);
    }
}
