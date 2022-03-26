using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.User;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        string AddBooks(BookPostModel addBook);
        bool UpdateBooks(int BookId, BookPostModel updateBook);
        bool DeleteBook(int BookId);
        List<BookModel> GetAllBooks();
        List<BookPostModel> GetBookByBookId(int BookId);
    }
}
