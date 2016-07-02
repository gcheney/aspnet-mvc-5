using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDemo
{
    public class User
    {
        public string LoginName { get; set; }
    }

    public interface IUserRepository
    {
        void Add(User newUser);
        User FetchByLoginName(string loginName);
        void SubmitChanges();
    }

    public class DeafultUserRepository : IUserRepository
    {
        public void Add(User newUser)
        {
            //TODO
        }

        public User FetchByLoginName(string loginName)
        {
            //TODO
            return new User() { LoginName = loginName };
        }

        public void SubmitChanges()
        {
            //TODO
        }
    }
}
