using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WIMS_TeamTK.Core.Factories;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests.CoreTests
{
    [TestClass]
    public class Factory_Should
    {
        [TestMethod]
        public void CreateBug()
        {
            //Arrange
            IFactory factory = new Factory();
            string title = "TestBug";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            //Act
            var sut = factory.CreateBug(title, description, stepsToReproduce, priority, severity, status);
            //Assert
            Assert.IsInstanceOfType(sut, typeof(Bug));
        }
        [TestMethod]
        public void CreateStory()
        {
            //Arrange
            IFactory factory = new Factory();
            string title = "TestStory";
            string description = "valid description";
            Priority priority = Priority.High;
            Size size = Size.Large;
            StoryStatus status = StoryStatus.Done;
            //Act
            var sut = factory.CreateStory(title, description, priority, size, status);
            //Assert
            Assert.IsInstanceOfType(sut, typeof(Story));
        }
        public void CreateFeedback()
        {
            //Arrange
            IFactory factory = new Factory();
            string title = "TestFeedback";
            string description = "valid description";
            int rating = 2;
            FeedbackStatus status = FeedbackStatus.New;
            //Act
            var sut = new Feedback(title, description, rating, status);
            //Assert
            Assert.IsInstanceOfType(sut, typeof(Feedback));
        }
        [TestMethod]
        public void CreateMember()
        {
            //Arrange
            IFactory factory = new Factory();
            string name = "TestMember";
            //Act
            var sut = factory.CreateMember(name);
            //Assert
            Assert.IsInstanceOfType(sut, typeof(Member));
        }
        [TestMethod]
        public void CreateBoard()
        {
            //Arrange
            IFactory factory = new Factory();
            string name = "TestMember";
            //Act
            var sut = factory.CreateBoard(name);
            //Assert
            Assert.IsInstanceOfType(sut, typeof(Board));
        }
        [TestMethod]
        public void CreateTeam()
        {
            //Arrange
            IFactory factory = new Factory();
            string name = "TestMember";
            //Act
            var sut = factory.CreateTeam(name);
            //Assert
            Assert.IsInstanceOfType(sut, typeof(Team));
        }
    }

}
