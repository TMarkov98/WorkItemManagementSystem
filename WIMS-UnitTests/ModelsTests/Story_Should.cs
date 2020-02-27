using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Contracts;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests.ModelsTests
{
    [TestClass]
    public class Story_Should
    {
        [TestMethod]
        public void SetCorrectTitle()
        {
            //Arrange
            string title = "StoryTitle";
            string description = "valid description";
            Priority priority = Priority.High;
            Size size = Size.Large;
            StoryStatus status = StoryStatus.Done;
            //Act
            IStory sut = new Story(title, description, priority, size, status);
            //Assert
            Assert.AreEqual(title, sut.Title);
        }
        [TestMethod]
        public void SetCorrectDescription()
        {
            //Arrange
            string title = "StoryTitle";
            string description = "valid description";
            Priority priority = Priority.High;
            Size size = Size.Large;
            StoryStatus status = StoryStatus.Done;
            //Act
            IStory sut = new Story(title, description, priority, size, status);
            //Assert
            Assert.AreEqual(description, sut.Description);
        }
        [TestMethod]
        public void AutoPopulateHistory()
        {
            //Arrange
            string title = "StoryTitle";
            string description = "valid description";
            Priority priority = Priority.High;
            Size size = Size.Large;
            StoryStatus status = StoryStatus.Done;
            //Act
            IStory sut = new Story(title, description, priority, size, status);
            //Assert
            Assert.AreEqual(sut.History.Count, 5);
        }
    }
}
