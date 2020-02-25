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
    public class Board_Should
    {
        [TestMethod]
        public void SetCorrectName()
        {
            //Arrange
            string name = "TestBoard";
            //Act
            var sut = new Board(name);
            //Assert
            Assert.AreEqual(name, sut.Name);
        }
        [TestMethod]
        public void ContainWorkItems()
        {
            //Arrange
            string name = "TestBoard";
            var sut = new Board(name);
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            IBug bug = new Bug(title, description, stepsToReproduce, priority, severity, status);
            //Act
            sut.AddWorkItem(bug);
            //Assert
            Assert.AreEqual(sut.WorkItems.Count, 1);
        }
        [TestMethod]
        public void AutoPopulateHistory()
        {
            //Arrange
            string name = "TestBoard";
            var sut = new Board(name);
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            IBug bug = new Bug(title, description, stepsToReproduce, priority, severity, status);
            //Act
            sut.AddWorkItem(bug);
            //Assert
            Assert.AreEqual(sut.ActivityHistory.Count, 2);
        }
    }
}
