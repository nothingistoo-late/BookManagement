using BookManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repository
{
    public class UserRepository
    {
        private BookManagementDbContext _context;

        public UserAccount? GetUserByEmailAndPassword(string? email, string? password)
        {
            _context = new();
            return _context.UserAccounts.FirstOrDefault(x => x.Email.ToLower().Trim() == email.ToLower().Trim() && x.Password == password);
        }

    }
}
