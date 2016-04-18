using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBookAuthor;

namespace BooksDBActions
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        int Add(Book book);
        Book Get(int id);
        Book Update(Book book);
        bool Delete(int id);
    }
}
