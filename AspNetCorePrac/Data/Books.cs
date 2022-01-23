using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public int TotalPages { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string CoverImageUrl { get; set; }

        public ICollection<BookGallery> Gallery { get; set; }
    }
}
