using System;
using System.Collections.Generic;
using System.Text;
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
                this._status = value;
            }
        }
    }
}
