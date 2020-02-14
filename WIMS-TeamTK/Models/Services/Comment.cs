using System;
using System.Collections.Generic;
using System.Text;

namespace WIMS_TeamTK.Models.Services
{
    public class Comment
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
