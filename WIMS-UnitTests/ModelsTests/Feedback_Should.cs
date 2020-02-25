using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests.ModelsTests
{ 
   [TestClass]
   public class Feedback_Should
    {
        [TestMethod]
        public void SetCorrectName()
        {
            //Arrange
            var customName = "FeedbackName";
            string customDescription = "Some right description.";
            int customRating = 2;
            FeedbackStatus customStatus = FeedbackStatus.Done;
            //Act
            var sut = new Feedback(customName, customDescription, customRating, customStatus);

            //Assert
            Assert.AreEqual(sut.Title, customName);
        }
        [TestMethod]
        public void SetCorrectDescription()
        {
            //Arrange
            var customName = "FeedbackName";
            string customDescription = "Some right description.";
            int customRating = 2;
            FeedbackStatus customStatus = FeedbackStatus.Done;
            //Act
            var sut = new Feedback(customName, customDescription, customRating, customStatus);

            //Assert
            Assert.AreEqual(sut.Description, customDescription);
        }
        [TestMethod]
        public void SetCorrectRating()
        {
            //Arrange
            var customName = "FeedbackName";
            string customDescription = "Some right description.";
            int customRating = 2;
            FeedbackStatus customStatus = FeedbackStatus.Done;
            //Act
            var sut = new Feedback(customName, customDescription, customRating, customStatus);

            //Assert
            Assert.AreEqual(sut.Rating, customRating);
        }
        [TestMethod]
        public void SetCorrectStatus()
        {
            //Arrange
            var customName = "FeedbackName";
            string customDescription = "Some right description.";
            int customRating = 2;
            FeedbackStatus customStatus = FeedbackStatus.Done;
            //Act
            var sut = new Feedback(customName, customDescription, customRating, customStatus);

            //Assert
            Assert.AreEqual(sut.Status, customStatus);
        }
        [TestMethod]
        public void AddToHistory()
        {
            //Arrange
            var customName = "FeedbackName";
            string customDescription = "Some right description.";
            int customRating = 2;
            FeedbackStatus customStatus = FeedbackStatus.Done;
            //Act
            var sut = new Feedback(customName, customDescription, customRating, customStatus);
            sut.Status = FeedbackStatus.New;
            //Assert
            Assert.AreEqual(sut.History.Count, 5);
        }
    }
}
