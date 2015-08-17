using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<VocabularyContext>
    {
        protected override void Seed(VocabularyContext context)
        {
            GetLanguages().ForEach(l => context.Languages.Add(l));
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetUsers().ForEach(u => context.Users.Add(u));
            base.Seed(context);
        }
        private List<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>();
            languages.Add(new Language { ID = 1, Name = "en-US" });
            languages.Add(new Language { ID = 2, Name = "bg-BG" });
            return languages;
        }
        private List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category { ID = 1, LanguageID = 1, Name = "Computer graphics" });
            categories.Add(new Category { ID = 2, LanguageID = 2, Name = "Компютърна графика" });
            categories.Add(new Category { ID = 3, LanguageID = 1, Name = "Artificial intelligence" });
            categories.Add(new Category { ID = 4, LanguageID = 2, Name = "Изкуствен интелект" });
            return categories;
        }
        private List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User { ID = 1, Name = "Admin", Password = "admin", Role = "admin" });
            return users;
        }
        
    }
}