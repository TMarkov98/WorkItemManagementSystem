﻿using System;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Member : Resource, IMember
    {
        public Member(string name)
            : base(name)
        {
            this.Name = name;
        }

        public override string Name
        {
            get => this._name;
            set
            {
                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException("Name must be between 5 and 15 symbols.");
                }
                this._name = value;
            }
        }
    }
}
