using BookManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repository
{
    public class BookRepo
    {
        private BookManagementDbContext? _dbContext;

        public List<Book> GetAllBook()
        {
            _dbContext = new();
            return _dbContext.Books.Include("BookCategory").ToList();   
        }

        public void Create(Book obj)
        {
            _dbContext = new();
            _dbContext.Books.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(Book obj)
        {
            _dbContext = new();
            _dbContext.Books.Update(obj);
            _dbContext.SaveChanges();
        }
        public void Delete(Book obj)
        {
            _dbContext = new();
            _dbContext.Remove(obj);
            _dbContext.SaveChanges();
        }


    }
}
