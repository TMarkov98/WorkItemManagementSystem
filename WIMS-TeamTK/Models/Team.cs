using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Team : ITeam
    {
        private string _name;
        private List<IMember> _members = new List<IMember>();
        private List<IBoard> _boards = new List<IBoard>();
        private List<string> _activityHistory = new List<string>();

        public Team(string name)
        {
            this.Name = name;
            this._activityHistory.Add($"[{DateTime.UtcNow}]: Created new team {this.Name}");
        }

        public string Name
        {
            get => this._name;
            set
            {
                this._name = value;
            }
        }
        public List<IMember> Members
        {
            get => this._members;
            private set
            {
                this._members = value;
            }
        }

        public List<string> ActivityHistory
        {
            get => this._activityHistory;
            private set
            {
                this._activityHistory = value;
            }
        }

        public void AddMember(IMember member)
        {
            this.Members.Add(member);
            this.ActivityHistory.Add($"[{DateTime.UtcNow}]: Added Member {member.Name}");
        }

        public void AddBoard(IBoard board)
        {
            this.Boards.Add(board);
            this.ActivityHistory.Add($"[{DateTime.UtcNow}]: Added Board {board.Name}");
        }

        public List<IBoard> Boards
        {
            get => this._boards;
            private set
            {
                this._boards = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name}";
        }
    }
}
