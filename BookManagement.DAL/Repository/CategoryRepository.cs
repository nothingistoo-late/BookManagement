using BookManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repository
{
    public class CategoryRepository
    {
        private BookManagementDbContext? _dbContext;

        public List<BookCategory> GetAll()
        {
            _dbContext = new BookManagementDbContext();
            return _dbContext.BookCategories.ToList();
        }
    }
}
