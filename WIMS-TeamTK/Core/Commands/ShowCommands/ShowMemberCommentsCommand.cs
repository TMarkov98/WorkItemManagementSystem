﻿using System;
using System.Collections.Generic;
using WIMS_TeamTK.Core.Contracts;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models.Contracts;

namespace WIMS_TeamTK.Core.Commands.ListCommands
{
    public class ShowMemberCommentsCommand : Command
    {
        public ShowMemberCommentsCommand(IFactory factory, IEngine engine, IValidator validator) : base(factory, engine, validator)
        {
        }
        /// <summary>
        /// Shows all Comments posted by a Member.
        /// </summary>
        /// <param name="parameter">The name of the Member.</param>
        /// <returns>A string with the Member's listed Comments.</returns>
        public override string Execute(string parameter)
        {
            string memberName = parameter;
            try
            {
                this._validator.ValidateExists(this._engine.Members, memberName);
                List<IComment> memberComments = new List<IComment>();
                string result = "";
                foreach (var item in this._engine.WorkItems)
                {
                    foreach (var comment in item.Comments)
                    {
                        if (comment.Author == memberName)
                        {
                            result += $"Comment on item {item.Title}:{Environment.NewLine}{comment}{Environment.NewLine}";
                        }
                    }
                }
                if (result == "")
                    return $"No comments by {memberName}";
                return result;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message} Unable to list member comments.");
            }
        }
    }
}
