using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Models
{
    public class Comment : IComment
    {
        private string _author;
        private string _message;
        private DateTime _createdOn;

        public Comment(string author, string message)
        {
            this.Author = author;
            this.Message = message;
            this.CreatedOn = DateTime.UtcNow;
        }

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

        public override string ToString()
        {
            return $"[{this.CreatedOn}] {this.Author}: {this.Message}";
        }
    }
}
