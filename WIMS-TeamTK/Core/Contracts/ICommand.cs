﻿namespace WIMS_TeamTK.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string parameter);
    }
}
