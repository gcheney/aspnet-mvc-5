using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ControllersAndActions.Controllers;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            //Arrange - Create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.Home();

            //Assert
            Assert.AreEqual("Home", result.ViewName);
        }

        [TestMethod]
        public void ViewSelectionTest()
        {
            //Arrange - Create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.Index();

            //Assert
            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(System.DateTime));
        }

        [TestMethod]
        public void ControllerTest()
        {
            //Arrange - Create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            ViewResult result = target.Index();

            //Assert
            //Assert.AreEqual("Hello", result.ViewBag.Message);
        }

        [TestMethod]
        public void RedirectTest()
        {
            //Arrange - Create the controller
            ExampleController target = new ExampleController();

            //Act - call the action method
            RedirectResult result = target.RedirectToUrl();

            Assert.IsTrue(result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void StatusTest()
        {
            //Arrange
            ExampleController target = new ExampleController();

            //Act
            HttpStatusCodeResult result = target.StatusCode();

            //Assert
            Assert.AreEqual(401, result.StatusCode);
        }
    }
}
