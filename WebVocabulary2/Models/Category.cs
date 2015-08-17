using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        public int LanguageID { get; set; }
    }
}