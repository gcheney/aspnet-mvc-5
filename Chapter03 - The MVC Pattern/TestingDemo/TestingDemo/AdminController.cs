using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestingDemo
{
    public class AdminController
    {
        private IUserRepository repository;

        public AdminController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public string ChangeLoginName(string oldName, string newName)
        {
            User user = repository.FetchByLoginName(oldName);
            user.LoginName = newName;
            repository.SubmitChanges();
            //render some sort of view
            return "Your Log in name has been changed";
        }
    }
}
