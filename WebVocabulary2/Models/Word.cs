using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class Word
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required, StringLength(90)]
        public string Name { get; set; }

        [StringLength(3500)]
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int LanguageID { get; set; }
        
    }
}