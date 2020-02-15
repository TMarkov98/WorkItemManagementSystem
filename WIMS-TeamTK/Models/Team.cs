using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Team : ITeam
    {
        private string _name;
        private List<Member> _members = new List<Member>();
        private List<Board> _boards = new List<Board>();

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
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
        public List<Member> Members
        {
            get => this._members;
            set
            {
                this._members = value;
            }
        }
        public List<Board> Boards
        {
            get => this._boards;
            set
            {
                this._boards = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}{Environment.NewLine}";
        }
    }
}
