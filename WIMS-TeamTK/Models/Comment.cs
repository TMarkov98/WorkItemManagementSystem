using System;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Comment : IComment
    {
        /// <summary>Author of comment</summary>
        private string _author;
        /// <summary>Message</summary>
        private string _message;
        /// <summary>Date and time of creation</summary>
        private DateTime _createdOn;
        
        /// <summary>
        /// Constructor of Comment
        /// </summary>
        public Comment(string author, string message)
        {
            this.Author = author;
            this.Message = message;
            this.CreatedOn = DateTime.UtcNow;
        }
        /// <summary>
        /// Property of Autor
        /// </summary>
        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                this._author = value;
            }
        }
        /// <summary>
        /// Property of Message
        /// </summary>
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }
        /// <summary>
        /// Property of CreatedOn
        /// </summary>
        public DateTime CreatedOn
        {
            get
            {
                return this._createdOn;
            }
            private set
            {
                this._createdOn = value;
            }
        }

        /// <summary>
        /// Turns class Comment to string.
        /// </summary>
        /// <returns>class to string</returns>
        public override string ToString()
        {
            return $"[{this.CreatedOn}] {this.Author}: {this.Message}";
        }
    }
}
