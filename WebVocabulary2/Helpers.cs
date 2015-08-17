using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using WebVocabulary2.Models;

namespace WebVocabulary2
{
    public static class Helpers
    {
        public static int GetCurrentLanguageID()
        {
            VocabularyContext context = new VocabularyContext();
            return context.Languages.SingleOrDefault(l => l.Name == CultureInfo.CurrentUICulture.Name).ID;
        }
        public const int EnLangID = 1;
        public const int BgLangID = 2;
    }
}