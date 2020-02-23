using System;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        private int _rating;
        private FeedbackStatus _status;
        public Feedback(string title, string description, int rating, FeedbackStatus status) : base(title, description)
        {
            this.Rating = rating;
            this.Status = status;
        }

        public int Rating
        {
            get
            {
                return this._rating;
            }
            set
            {
                if (value < -10 || value > 10)
                {
                    throw new ArgumentException("Rating should be between -10 and 10");
                }
                this.History.Add($"[{DateTime.UtcNow}]: Changed Rating to {value}.");
                this._rating = value;
            }
        }

        public FeedbackStatus Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Status to {value}.");
                this._status = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()
                + $"Rating: {this.Rating}{Environment.NewLine}"
                + $"Status: {this.Status}";
        }
    }
}
