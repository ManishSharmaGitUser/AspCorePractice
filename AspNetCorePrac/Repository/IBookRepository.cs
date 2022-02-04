using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCorePrac.Models;

namespace AspNetCorePrac.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel bookModel);
        Task<List<BookModel>> GetAllBooks();
    }
}