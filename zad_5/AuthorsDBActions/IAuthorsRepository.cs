using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBookAuthor;

namespace AuthorsDBActions
{
    public interface IAuthorsRepository
    {
        List<Author> GetAll();
        int Add(Author author);
        Author Get(int id);
        Author Update(Author author);
        bool Delete(int id);
    }
}
