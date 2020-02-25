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
    public class Member_Should
    {
        [TestMethod]
        public void SetCorrectName()
        {
            //Arrange
            string name = "TestMember";
            //Act
            var sut = new Member(name);
            //Assert
            Assert.AreEqual(name, sut.Name);
        }
        public void ContainWorkItems()
        {
            //Arrange
            string name = "TestMember";
            var sut = new Member(name);
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
    }
}
