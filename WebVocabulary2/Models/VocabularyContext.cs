using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class VocabularyContext : DbContext
    {
        public VocabularyContext() : base("VocabularyDB")
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Word> Word { get; set; }
    }
}