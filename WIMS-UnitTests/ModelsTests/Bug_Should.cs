using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests.ModelsTests
{
    [TestClass]
    public class Bug_Should
    {
        [TestMethod]
        public void SetCorrectTitle()
        {
            //Arrange
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            //Act
            IBug sut = new Bug(title, description, stepsToReproduce, priority, severity, status);
            //Assert
            Assert.AreEqual(title, sut.Title);
        }
        [TestMethod]
        public void SetCorrectDescription()
        {
            //Arrange
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            //Act
            IBug sut = new Bug(title, description, stepsToReproduce, priority, severity, status);
            //Assert
            Assert.AreEqual(description, sut.Description);
        }
        [TestMethod]
        public void SetCorrectStepsToReproduce()
        {
            //Arrange
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            //Act
            IBug sut = new Bug(title, description, stepsToReproduce, priority, severity, status);
            //Assert
            Assert.AreEqual(stepsToReproduce, sut.StepsToReproduce);
        }
        [TestMethod]
        public void AutoPopulateHistory()
        {
            //Arrange
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            //Act
            IBug sut = new Bug(title, description, stepsToReproduce, priority, severity, status);
            //Assert
            Assert.AreEqual(sut.History.Count, 5);
        }
    }
}
