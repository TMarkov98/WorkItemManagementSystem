using System;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        /// <summary>Rating of Feedback</summary>
        private int _rating;
        /// <summary>Enum with status</summary>
        private FeedbackStatus _status;
        /// <summary>
        /// Constructor of Feedback
        /// </summary>
        /// <param name="title">Title of the feedback</param>
        /// <param name="description">Description of the feedback</param>
        /// <param name="rating">Rating of feedback</param>
        /// <param name="status">Status of the feedback</param>
        public Feedback(string title, string description, int rating, FeedbackStatus status) : base(title, description)
        {
            this.Rating = rating;
            this.Status = status;
        }

        /// <summary>
        /// Rating of Feedback
        /// </summary>
        public int Rating
        {
            get
            {
                return this._rating;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Rating to {value}.");
                this._rating = value;
            }
        }

        /// <summary>
        /// Status of Feedback
        /// </summary>
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

        /// <summary>
        /// Turns class feedback to string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString()
                + $"Rating: {this.Rating}{Environment.NewLine}"
                + $"Status: {this.Status}";
        }
    }
}
