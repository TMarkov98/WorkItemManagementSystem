using System;
using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Team : ITeam
    {
        /// <summary>Name of a team.</summary>
        private string _name;
        /// <summary>Members of the team.</summary>
        private List<IMember> _members = new List<IMember>();
        /// <summary>Boards of the team.</summary>
        private List<IBoard> _boards = new List<IBoard>();
        /// <summary>History of the team.</summary>
        private List<string> _activityHistory = new List<string>();

        /// <summary>
        /// Constructor of Team
        /// </summary>
        public Team(string name)
        {
            this.Name = name;
            this._activityHistory.Add($"[{DateTime.UtcNow}]: Created new team {this.Name}");
        }
        /// <summary>
        /// Property of Name
        /// </summary>
        public string Name
        {
            get => this._name;
            private set
            {
                this._name = value;
            }
        }

        /// <summary>
        /// Property of Members
        /// </summary>
        public List<IMember> Members
        {
            get => this._members;
            private set
            {
                this._members = value;
            }
        }
        /// <summary>
        /// Property of ActivityHistory
        /// </summary>

        public List<string> ActivityHistory
        {
            get => this._activityHistory;
            private set
            {
                this._activityHistory = value;
            }
        }

        /// <summary>
        /// Property of Boards
        /// </summary>
        public List<IBoard> Boards
        {
            get => this._boards;
            private set
            {
                this._boards = value;
            }
        }

        /// <summary>
        /// Method for adding a member the team.
        /// </summary>
        /// <param name="member">Member to add</param>
        public void AddMember(IMember member)
        {
            this.Members.Add(member);
            this.ActivityHistory.Add($"[{DateTime.UtcNow}]: Added Member {member.Name}");
        }

        /// <summary>
        /// Method for adding a board to the team.
        /// </summary>
        /// <param name="board"></param>
        public void AddBoard(IBoard board)
        {
            this.Boards.Add(board);
            this.ActivityHistory.Add($"[{DateTime.UtcNow}]: Added Board {board.Name}");
        }

        /// <summary>
        /// Turns class Team to string.
        /// </summary>
        /// <returns>class team as string.</returns>
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Name}";
        }
    }
}
