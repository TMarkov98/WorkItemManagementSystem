using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Core;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests.CoreTests
{
    [TestClass]
    public class Validator_Should
    {
        [TestMethod]
        public void ValidateDuplicateBoard_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<IBoard> boards = new List<IBoard>();
            string name = "TestBoard";
            var board = new Board(name);
            boards.Add(board);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateDuplicateBoard(boards, name));
        }
        [TestMethod]
        public void ValidateBoardExists_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            List<IBoard> boards = new List<IBoard>();
            string name = "TestBoard";
            var board = new Board(name);
            boards.Add(board);
            //Act
            var sut = validator.ValidateBoardExists(boards, name);
            //Assert
            Assert.AreEqual(board, sut);
        }
        [TestMethod]
        public void ValidateBoardExists_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<IBoard> boards = new List<IBoard>();
            string name = "TestBoard";
            string wrongName = "FakeBoard";
            var board = new Board(name);
            boards.Add(board);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateBoardExists(boards, wrongName));
        }
        [TestMethod]
        public void ValidateBugStatus_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string statusAsString = "Active";
            BugStatus expected = BugStatus.Active;
            //Act
            BugStatus sut = validator.ValidateBugStatus(statusAsString);
            //Assert
            Assert.AreEqual(expected, sut);
        }
        [TestMethod]
        public void ValidateBugStatus_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidStatus = "InvalidStatus";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateBugStatus(invalidStatus));
        }
        [TestMethod]
        public void ValidateDescrption_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string expected = "Valid Description";
            //Act
            string description = validator.ValidateDescription(expected);
            //Assert
            Assert.AreEqual(expected, description);
        }
        [TestMethod]
        public void ValidateDescrption_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidDescrption = "inv";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateDescription(invalidDescrption));
        }
        [TestMethod]
        public void ValidateFeedbackStatus_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string statusAsString = "Scheduled";
            FeedbackStatus status = FeedbackStatus.Scheduled;
            //Act
            FeedbackStatus sut = validator.ValidateFeedbackStatus(statusAsString);
            //Assert
            Assert.AreEqual(status, sut);
        }
        [TestMethod]
        public void ValidateFeedbackStatus_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidStatus = "InvalidStatus";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateFeedbackStatus(invalidStatus));
        }
        [TestMethod]
        public void ValidateMemberExists_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            List<IMember> members = new List<IMember>();
            string name = "TestMember";
            var member = new Member(name);
            members.Add(member);
            //Act
            var sut = validator.ValidateMemberExists(members, name);
            //Assert
            Assert.AreEqual(member, sut);
        }
        [TestMethod]
        public void ValidateMemberExists_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<IMember> members = new List<IMember>();
            string name = "TestMember";
            string wrongName = "FakeMember";
            var member = new Member(name);
            members.Add(member);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateMemberExists(members, wrongName));
        }
        [TestMethod]
        public void ValidateMoreThanOneBoard_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            List<IBoard> boards = new List<IBoard>();
            string name = "TestBoard";
            var board = new Board(name);
            boards.Add(board);
            //Act
            var sut = validator.ValidateMoreThanOneBoard(boards, name);
            //Assert
            Assert.AreEqual(board, sut);
        }
        [TestMethod]
        public void ValidateMoreThanOneWorkItem_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            var bug = new Bug(title, description, stepsToReproduce, priority, severity, status);
            string name = "TestBoard";
            var board = new Board(name);
            board.AddWorkItem(bug);
            //Act
            var sut = validator.ValidateMoreThanOneWorkItem(board.WorkItems, title);
            //Assert
            Assert.AreEqual(bug, sut);
        }
        [TestMethod]
        public void ValidatePriority_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string priorityAsString = "High";
            Priority expected = Priority.High;
            //Act
            Priority sut = validator.ValidatePriority(priorityAsString);
            //Assert
            Assert.AreEqual(expected, sut);
        }
        [TestMethod]
        public void ValidatePriority_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidPriority = "InvalidPriority";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidatePriority(invalidPriority));
        }
        [TestMethod]
        public void ValidateSeverity_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string severityAsString = "Critical";
            Severity expected = Severity.Critical;
            //Act
            Severity sut = validator.ValidateSeverity(severityAsString);
            //Assert
            Assert.AreEqual(expected, sut);
        }
        [TestMethod]
        public void ValidateSeverity_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidSeverity = "InvalidSeverity";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateSeverity(invalidSeverity));
        }
        [TestMethod]
        public void ValidateSize_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string sizeAsString = "Large";
            Size expected = Size.Large;
            //Act
            Size sut = validator.ValidateSize(sizeAsString);
            //Assert
            Assert.AreEqual(expected, sut);
        }
        [TestMethod]
        public void ValidateSize_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidSize = "InvalidSize";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateSize(invalidSize));
        }
        [TestMethod]
        public void ValidateStoryStatus_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string statusAsString = "InProgress";
            StoryStatus expected = StoryStatus.InProgress;
            //Act
            StoryStatus sut = validator.ValidateStoryStatus(statusAsString);
            //Assert
            Assert.AreEqual(expected, sut);
        }
        [TestMethod]
        public void ValidateStoryStatus_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidStatus = "InvalidStatus";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateStoryStatus(invalidStatus));
        }
        [TestMethod]
        public void ValidateTeamExists_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            List<ITeam> teams = new List<ITeam>();
            string name = "TestTeam";
            var team = new Team(name);
            teams.Add(team);
            //Act
            var sut = validator.ValidateTeamExists(teams, name);
            //Assert
            Assert.AreEqual(team, sut);
        }
        [TestMethod]
        public void ValidateTeamExists_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<ITeam> teams = new List<ITeam>();
            string name = "TestTeam";
            string wrongName = "FakeTeam";
            var team = new Team(name);
            teams.Add(team);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateTeamExists(teams, wrongName));
        }
        [TestMethod]
        public void ValidateTitle_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string expected = "Valid Title";
            //Act
            string title = validator.ValidateTitle(expected);
            //Assert
            Assert.AreEqual(expected, title);
        }
        [TestMethod]
        public void ValidateTitle_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidTitle = "inv";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateTitle(invalidTitle));
        }
        [TestMethod]
        public void ValidateWorkItemExists_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            var bug = new Bug(title, description, stepsToReproduce, priority, severity, status);
            string name = "TestBoard";
            var board = new Board(name);
            board.AddWorkItem(bug);
            //Act
            var sut = validator.ValidateWorkItemExists(board.WorkItems, title);
            //Assert
            Assert.AreEqual(bug, sut);
        }
        [TestMethod]
        public void ValidateWorkItemExists_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<IWorkItem> workItems = new List<IWorkItem>();
            string wrongTitle = "FakeWorkItem";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateWorkItemExists(workItems, wrongTitle));
        }
        [TestMethod]
        public void ValidateDuplicateMember_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<IMember> members = new List<IMember>();
            string name = "TestMember";
            var member = new Member(name);
            members.Add(member);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateDuplicateMember(members, name));
        }
        [TestMethod]
        public void ValidateRating_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string ratingAsString = "9";
            int expected = 9;
            //Act
            var sut = validator.ValidateRating(ratingAsString);
            //Assert
            Assert.AreEqual(expected, sut);
        }
        [TestMethod]
        public void ValidateRating_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string ratingAsString = "11";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateRating(ratingAsString));
        }
        [TestMethod]
        public void ValidateDuplicateTeam_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            List<ITeam> teams = new List<ITeam>();
            string name = "TestTeam";
            var team = new Team(name);
            teams.Add(team);
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateDuplicateTeam(teams, name));
        }
        [TestMethod]
        public void ValidateBoardName_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string expected = "BoardName";
            //Act
            string boardName = validator.ValidateBoardName(expected);
            //Assert
            Assert.AreEqual(expected, boardName);
        }
        [TestMethod]
        public void ValidateBoardName_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidBoardName = "inv";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateBoardName(invalidBoardName));
        }
        [TestMethod]
        public void ValidateMemberName_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string expected = "MemberName";
            //Act
            string memberName = validator.ValidateMemberName(expected);
            //Assert
            Assert.AreEqual(expected, memberName);
        }
        [TestMethod]
        public void ValidateMemberName_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidMemberName = "inv";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateBoardName(invalidMemberName));
        }
        [TestMethod]
        public void ValidateTeamName_WithValidData()
        {
            //Arrange
            Validator validator = new Validator();
            string expected = "TeamName";
            //Act
            string teamName = validator.ValidateTeamName(expected);
            //Assert
            Assert.AreEqual(expected, teamName);
        }
        [TestMethod]
        public void ValidateTeamName_ThrowsException()
        {
            //Arrange
            Validator validator = new Validator();
            string invalidTeamName = "inv";
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() => validator.ValidateTeamName(invalidTeamName));
        }
    }
}
