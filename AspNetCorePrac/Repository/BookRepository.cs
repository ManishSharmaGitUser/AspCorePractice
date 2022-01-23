using AspNetCorePrac.Data;
using AspNetCorePrac.Models;
using Microsoft.EntityFrameworkCore;
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
                LanguageId = bookModel.LanguageId.Value,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0,
                CoverImageUrl = bookModel.CoverImageUrl

            };
            newbook.Gallery = new List<BookGallery>();
            foreach (var detailofImg in bookModel.Gallery)
            {
                newbook.Gallery.Add(new BookGallery { 
                      Name= detailofImg.Name,
                      URL= detailofImg.Url
                });
            }

           await bookRepository.Books.AddAsync(newbook);
           await bookRepository.SaveChangesAsync();
            return newbook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
          return await bookRepository.Books.Select(x=> new BookModel { 
             Id =x.Id,
             Author = x.Author,
             CoverImageUrl =x.CoverImageUrl,
             Title =x.Title,
             Description = x.Description,
             TotalPages = x.TotalPages,
             LanguageId = x.LanguageId,
             Language = x.Language.Text
            }).ToListAsync();
        }
    }
}
