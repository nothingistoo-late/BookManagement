using BookManagement.DAL.Entities;
using BookManagement.DAL.Repository;
using Microsoft.IdentityModel.Tokens;
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

        public List<Book> SearchBookByNameAndDes(string bookname, string des) 
        {
            // tình huống hàm search kh có để cái gì, trả về full
            List<Book> result = _bookRepo.GetAllBook();
            if (bookname.IsNullOrEmpty() && des.IsNullOrEmpty())
                return result;
            if (!bookname.IsNullOrEmpty() && des.IsNullOrEmpty())
                result = result.Where(x => x.BookName.ToLower().Contains(bookname.ToLower())).ToList();
            if (!des.IsNullOrEmpty() && bookname.IsNullOrEmpty())
            {
                result = result.Where(x => x.Description.ToLower().Contains(des.ToLower())).ToList();
            }
            if (!bookname.IsNullOrEmpty() && !des.IsNullOrEmpty())
                result = result.Where(x => x.BookName.ToLower().Contains(bookname.ToLower()) || x.Description.ToLower().Contains(des.ToLower())).ToList();

            return result;
        }
    }
}
