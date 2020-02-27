using System;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Models
{
    public class Story : WorkItem, IStory, IAssignable
    {
        /// <summary>Enum with priorities</summary>
        private Priority _priority;
        /// <summary>Enum with size</summary>
        private Size _size;
        /// <summary>Enum with status</summary>
        private StoryStatus _status;
        /// <summary>Name of the member assigned to this story</summary>
        private string _assignee = string.Empty;

        /// <summary>
        /// Constructor of Story
        /// </summary>
        /// <param name="title">Title of the story</param>
        /// <param name="description">Description of the story</param>
        /// <param name="priority">Priority of the story</param>
        /// <param name="size">Size of the story</param>
        /// <param name="status">Status of the story</param>
        public Story(string title, string description, Priority priority, Size size, StoryStatus status) : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
        }

        /// <summary>
        /// Property of Priority
        /// </summary>
        public Priority Priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Priority to {value}.");
                this._priority = value;
            }
        }

        /// <summary>
        /// Property of Size
        /// </summary>
        public Size Size
        {
            get
            {
                return this._size;
            }
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Size to {value}.");
                this._size = value;
            }
        }

        /// <summary>
        /// Property of Status
        /// </summary>
        public StoryStatus Status
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
        /// Property of Assignee
        /// </summary>
        public string Assignee
        {
            get => this._assignee;
            set
            {
                this.History.Add($"[{DateTime.UtcNow}]: Changed Assignee to {value}.");
                this._assignee = value;
            }
        }

        /// <summary>
        /// Property of StoryStatus
        /// </summary>
        public StoryStatus StoryStatus { get; internal set; }

        /// <summary>
        /// Turns class Story to string.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string result = base.ToString()
                + $"Priority: {this.Priority}{Environment.NewLine}"
                + $"Size: {this.Size}{Environment.NewLine}"
                + $"Status: {this.Status}{Environment.NewLine}";
            if (this.Assignee == string.Empty)
            {
                result += "Not assigned.";
            }
            else
            {
                result += $"Assignee: {this.Assignee}";
            }
            return result;
        }
    }
}
