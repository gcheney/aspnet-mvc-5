using System;
using System.Collections.Generic;
using System.Linq;
using TestingDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void CanChangeLoginName()
        {
            //Arrange (set up a scenario)
            User user = new User() { LoginName = "Bob" };
            FakeRepository repo = new FakeRepository();
            repo.Add(user);
            AdminController target = new AdminController(repo);
            string oldLogin = user.LoginName;
            string newLogin = "Joe";

            //Act (attempt the operation)
            target.ChangeLoginName(oldLogin, newLogin);

            //Assert (verify the results)
            Assert.AreEqual(newLogin, user.LoginName);
            Assert.IsTrue(repo.ChangesSubmitted);
        }
    }

    class FakeRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public bool ChangesSubmitted { get; set; }

        public FakeRepository()
        {
            ChangesSubmitted = false;
        }

        public void Add(User newUser)
        {
            users.Add(newUser);
        }

        public User FetchByLoginName(string loginName)
        {
            return users.First(u => u.LoginName == loginName);
        }

        public void SubmitChanges()
        {
            ChangesSubmitted = true;
        }
    }
}
