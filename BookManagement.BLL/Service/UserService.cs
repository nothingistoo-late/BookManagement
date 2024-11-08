using BookManagement.DAL.Entities;
using BookManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Service
{
    public class UserService
    {

        private UserRepository _userRepository = new();


        public UserAccount GetUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetUserByEmailAndPassword(email, password);

        }
    }
}
