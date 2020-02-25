using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests.ModelsTests
{
    [TestClass]
    public class Team_Should
    {
        [TestMethod]
        public void SetCorrectName()
        {
            //Arrange
            string name = "TestTeam";
            //Act
            var sut = new Team(name);
            //Assert
            Assert.AreEqual(name, sut.Name);
        }
        [TestMethod]
        public void ContainMembers()
        {
            //Arrange
            string name = "TestTeam";
            string memberName = "TestMember";
            var member = new Member(memberName);
            //Act
            var sut = new Team(name);
            sut.AddMember(member);
            //Assert
            Assert.AreEqual(sut.Members.Count, 1);
        }
        [TestMethod]
        public void ContainBoards()
        {
            //Arrange
            string name = "TestTeam";
            string boardName = "TestBoard";
            var board = new Board(boardName);
            //Act
            var sut = new Team(name);
            sut.AddBoard(board);
            //Assert
            Assert.AreEqual(sut.Boards.Count, 1);
        }
        [TestMethod]
        public void AddToHistory()
        {
            //Arrange
            string name = "TestTeam";
            string boardName = "TestBoard";
            var board = new Board(boardName);
            //Act
            var sut = new Team(name);
            sut.AddBoard(board);
            //Assert
            Assert.AreEqual(sut.ActivityHistory.Count, 2);
        }
    }
}
