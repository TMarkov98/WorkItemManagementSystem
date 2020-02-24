using System;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Member : Resource, IMember
    {
        public Member(string name)
            : base(name)
        {
        }
        public void AddCommentToHistory()
        {
            this._activityHistory.Add($"[{DateTime.UtcNow}]: {this.Name} added comment to item.");
        }
    }
}
