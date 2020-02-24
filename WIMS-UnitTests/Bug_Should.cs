using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WIMS_TeamTK.Models;
using WIMS_TeamTK.Models.Enums;

namespace WIMS_UnitTests
{
    [TestClass]
    class Bug_Should
    {
        [TestMethod]
        public void ConstructWithCorrectData()
        {
            //Arrange
            string title = "BugTitle";
            string description = "valid description";
            List<string> stepsToReproduce = new List<string> { "step1", "step2", "step3" };
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            BugStatus status = BugStatus.Active;
            //Act
            var sut = new Bug(title, description, stepsToReproduce, priority, severity, status);

            //Assert
            Assert.IsInstanceOfType(sut.GetType(), typeof(Bug));
        }
    }
}
