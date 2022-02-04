using System.Collections.Generic;
using AspNetCorePrac.Models;

namespace AspNetCorePrac.Repository
{
    public interface ILanguageRepository
    {
        List<LanguageModel> GetLanguage();
    }
}