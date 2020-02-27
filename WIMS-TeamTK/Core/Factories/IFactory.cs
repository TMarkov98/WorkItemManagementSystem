using System.Collections.Generic;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_TeamTK.Core.Factories
{
    public interface IFactory
    {
        /// <summary>
        /// Creates a member with the provided name.
        /// </summary>
        /// <param name="name">The name provided.</param>
        /// <returns>A new IMember instance with the provided name.</returns>
        public IMember CreateMember(string name);
        /// <summary>
        /// Creates a board with the provided name.
        /// </summary>
        /// <param name="name">The name provided.</param>
        /// <returns>A new IBoard instance with the provided name.</returns>
        public IBoard CreateBoard(string name);
        /// <summary>
        /// Creates a team with the provided name.
        /// </summary>
        /// <param name="name">The name provided.</param>
        /// <returns>A new ITeam instance with the provided name.</returns>
        public ITeam CreateTeam(string name);
        /// <summary>
        /// Creates a bug with the provided parameters.
        /// </summary>
        /// <param name="title">The title of the bug.</param>
        /// <param name="description">The description of the bug.</param>
        /// <param name="stepsToReproduce">The steps to reproduce the bug.</param>
        /// <param name="priority">The priority of the bug.</param>
        /// <param name="severity">The severity of the bug.</param>
        /// <param name="status">The status of the bug.</param>
        /// <returns>A new IBug instance with the provided parameters.</returns>
        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status);
        /// <summary>
        /// Creates a Story with the provided parameters.
        /// </summary>
        /// <param name="title">The title of the story.</param>
        /// <param name="description">The description of the story.</param>
        /// <param name="priority">The prioirty of the story.</param>
        /// <param name="size">The size of the story.</param>
        /// <param name="status">The status of the story.</param>
        /// <returns>A new IStory instance with the provided parameters.</returns>
        public IStory CreateStory(string title, string description, Priority priority, Size size, StoryStatus status);
        /// <summary>
        /// Creates a Feedback with the provided parameters.
        /// </summary>
        /// <param name="title">The title of the feedback.</param>
        /// <param name="description">The description of the feedback.</param>
        /// <param name="rating">The rating of the feedback.</param>
        /// <param name="status">The status of the feedback.</param>
        /// <returns>A new IFeedback instance with the provided parameters.</returns>
        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status);
        /// <summary>
        /// Creates a comment with the provided parameters.
        /// </summary>
        /// <param name="author">The author of the comment.</param>
        /// <param name="message">The message in the comment.</param>
        /// <returns>A new IComment instance with the provided parameters.</returns>
        public IComment CreateComment(string author, string message);
    }
}
