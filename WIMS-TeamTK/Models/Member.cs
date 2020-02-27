using System;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Member : Resource, IMember
    {
        /// <summary>
        /// Constructor of Member
        /// </summary>
        public Member(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Updates history of current member.
        /// </summary>
        public void AddCommentToHistory()
        {
            this._activityHistory.Add($"[{DateTime.UtcNow}]: {this.Name} added comment to item.");
        }
    }
}
