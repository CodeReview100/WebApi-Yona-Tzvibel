using ex01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IUserRepository
    {
        Task<User> getUserByUserNameAndPassword(string userName, string password);
        Task<User> CreateNewUser(User user);
        Task Put(int id, User userToUpdate);    }
}
