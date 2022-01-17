using AspNetCorePrac.Data;
using AspNetCorePrac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext context;
        public LanguageRepository(BookStoreContext _context)
        {
            context = _context;
        }

        public List<LanguageModel> GetLanguage()
        {
            var data = context.Languages.Select(x => new LanguageModel { Id = x.Id, Text = x.Text }).ToList();
            return data;
        }
    }
}
