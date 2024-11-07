using BookManagement.DAL.Entities;
using BookManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Service
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepo = new();

        public List<BookCategory> GetAll()
        {
            return _categoryRepo.GetAll();
        }
    }
}
