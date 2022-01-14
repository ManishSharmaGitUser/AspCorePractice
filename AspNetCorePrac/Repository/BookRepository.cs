using AspNetCorePrac.Data;
using AspNetCorePrac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext bookRepository;

        public BookRepository(BookStoreContext _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newbook = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0


            };

           await bookRepository.Books.AddAsync(newbook);
           await bookRepository.SaveChangesAsync();
            return newbook.Id;
        }
    }
}
