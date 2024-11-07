using BookManagement.DAL.Entities;
using BookManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Service
{
    public class BookService
    {
        private BookRepo _bookRepo = new();

        public List<Book> GetAllBook()
        {
            return _bookRepo.GetAllBook();
        }

        public void CreateBook(Book obj)
        {
            _bookRepo.Create(obj);
        }

        public void UpdateBook(Book obj) => _bookRepo.Update(obj);
       

        public void DeleteBook(Book obj) => _bookRepo.Delete(obj);
    }
}
