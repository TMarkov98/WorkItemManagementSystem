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

        public Comment(string author, string message)
        {

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

        public override string ToString()
        {
            return $"{this.Author}: {this.Message}";
        }
    }
}
